// ----------------------------------------------------------------------------------------------
// Copyright (c) Mårten Rånge.
// ----------------------------------------------------------------------------------------------
// This source code is subject to terms and conditions of the Microsoft Public License. A
// copy of the license can be found in the License.html file at the root of this distribution.
// If you cannot locate the  Microsoft Public License, please send an email to
// dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound
//  by the terms of the Microsoft Public License.
// ----------------------------------------------------------------------------------------------
// You must not remove this notice, or any other, from this software.
// ----------------------------------------------------------------------------------------------

module PersistentHashMapProperties

open FsCheck
open Source.Collections

open System
open System.Collections.Generic

module FsCheckConfig =
  open FsCheck
#if DEBUG
  let testCount = 100
#else
  let testCount = 1000
#endif
  let config = { Config.Quick with MaxTest = testCount; MaxFail = testCount }

module FsLinq =
  open System.Linq

  let inline first    source                        = Enumerable.First    (source)
  let inline groupBy  (selector : 'T -> 'U) source  = Enumerable.GroupBy  (source, Func<'T, 'U> selector)
  let inline last     source                        = Enumerable.Last     (source)
  let inline map      (selector : 'T -> 'U) source  = Enumerable.Select   (source, Func<'T, 'U> selector)
  let inline sortBy   (selector : 'T -> 'U) source  = Enumerable.OrderBy  (source, Func<'T, 'U> selector)
  let inline toArray  source                        = Enumerable.ToArray  (source)

module Common =
  let makeRandom (seed : int) =
    let mutable state = int64 seed
    let m = 0x7FFFFFFFL // 2^31 - 1
    let d = 1. / float m
    let a = 48271L      // MINSTD
    let c = 0L
    fun (b : int) (e : int) ->
      state <- (a*state + c) % m
      let r = float state * d
      let v = float (e - b)*r + float b |> int
      v

  let shuffle random vs =
    let a = Array.copy vs
    for i in 0..(vs.Length - 2) do
      let s =  random i vs.Length
      let t =  a.[s]
      a.[s] <- a.[i]
      a.[i] <- t
    a

  let notIdentical<'T when 'T : not struct> (f : 'T) (s : 'T) = obj.ReferenceEquals (f, s) |> not

  let popCount v =
    let rec loop c v =
      if v <> 0u then
        loop (c + 1) (v &&& (v - 1u))
      else
        c
    loop 0 v

  let copyArrayMakeHole at (vs : 'T []) hole =
    let nvs = Array.zeroCreate (vs.Length + 1)
    let rec idLoop c i =
      if i < vs.Length then
        if c = 0 then
          skipLoop i
        else
          nvs.[i] <- vs.[i]
          idLoop (c - 1) (i + 1)
    and skipLoop i =
      if i < vs.Length then
        nvs.[i + 1] <- vs.[i]
        skipLoop (i + 1)
    idLoop at 0
    nvs.[at] <- hole
    nvs

  let empty () = PersistentHashMap.Empty<_, _> ()

  let set k v (phm : PersistentHashMap<_, _>) = phm.Set (k, v)

  let length (phm : PersistentHashMap<_, _>) =
    let mutable l = 0
    let visitor _ _ = l <- l + 1; true
    phm.Visit (System.Func<_, _, _> visitor) |> ignore
    l

  let mapValues (m : 'K -> 'V -> 'U) (phm : PersistentHashMap<_, _>) =
    phm.MapValues (System.Func<_, _, _> m)

  let uniqueKey vs =
    vs
    |> FsLinq.groupBy fst
    |> FsLinq.map (fun g -> g.Key, (g |> FsLinq.map snd |> FsLinq.last))
    |> FsLinq.sortBy fst
    |> FsLinq.toArray

  let fromArray kvs =
    Array.fold
      (fun s (k, v) -> set k v s)
      (empty ())
      kvs

  let toArray (phm : PersistentHashMap<'K, 'V>) =
    phm
    |> FsLinq.map (fun kv -> kv.Key, kv.Value)
    |> FsLinq.toArray

  let toSortedKeyArray phm =
    let vs = phm |> toArray
    vs |> Array.sortInPlaceBy fst
    vs

  let checkInvariant (phm : PersistentHashMap<'K, 'V>) = phm.CheckInvariant ()

open Common

[<AllowNullLiteral>]
type Empty () =
  inherit obj ()

type ComplexType =
  | IntKey    of  int
  | StringKey of  int
  | TupleKey  of  int*string

type HalfHash(v : int) =
  member x.Value = v

  interface IComparable<HalfHash> with
    member x.CompareTo(o : HalfHash)  = v.CompareTo o.Value

  interface IEquatable<HalfHash> with
    member x.Equals(o : HalfHash)  = v = o.Value

  override x.Equals(o : obj)  =
    match o with
    | :? HalfHash as k -> v = k.Value
    | _                -> false
  override x.GetHashCode()    = (v.GetHashCode ()) >>> 16 // In order to get a fair bunch of duplicated hashes
  override x.ToString()       = sprintf "%d" v

type Action =
  | Add     of int*string
  | Remove  of int

type Properties () =
  static member ``PopCount returns number of set bits`` (i : uint32) =
    let expected  = popCount i
    let actual    = PersistentHashMap.PopCount i

    expected      = actual

  static member ``CopyArray copies the array`` (vs : int []) =
    let expected  = vs
    let actual    = PersistentHashMap.CopyArray vs

    notIdentical expected actual
    && expected = actual

  static member ``CopyArrayMakeHoleLast copies the array and leaves a hole in last pos`` (vs : Empty []) (hole : Empty)=
    let expected  = Array.append vs [| hole |]
    let actual    = PersistentHashMap.CopyArrayMakeHoleLast (vs, hole)

    notIdentical expected actual
    && expected = actual

  static member ``CopyArrayMakeHole copies the array and leaves a hole at pos`` (at : int) (vs : Empty []) (hole : Empty)=
    let at        = abs at % (vs.Length + 1)
    let expected  = copyArrayMakeHole at vs hole
    let actual    = PersistentHashMap.CopyArrayMakeHole (at, vs, hole)

    notIdentical expected actual
    && expected = actual

  static member ``PHM toArray must contain all added values`` (vs : (int*string) []) =
    let expected  = uniqueKey vs
    let phm       = vs |> fromArray
    let actual    = phm |> toSortedKeyArray

    notIdentical expected actual
    && checkInvariant phm
    && expected = actual

  static member ``PHM TryFind must return all added values`` (vs : (ComplexType*ComplexType) []) =
    let unique    = uniqueKey vs
    let phm       = unique |> fromArray

    let rec loop i =
      if i < unique.Length then
        let k, v = unique.[i]
        match phm.TryFind k with
        | true, fv when fv = v  -> loop (i + 1)
        | _   , _               -> false
      else
        true

    checkInvariant phm
    && loop 0

  static member ``PHM Unset on all added values must yield empty map`` (vs : (HalfHash*Empty) []) =
    let unique    = uniqueKey vs
    let phm       = unique |> fromArray

    let rec loop (phm : PersistentHashMap<_, _>) i =
      if checkInvariant phm |> not then
        None
      elif i < unique.Length then
        if phm.IsEmpty then
          None
        else
          let k, v = unique.[i]
          loop (phm.Unset k) (i + 1)
      else
        Some phm

    match loop phm 0 with
    | Some phm  -> phm.IsEmpty
    | None      -> false

  static member ``PHM should behave as Map`` (vs : Action []) =
    let compare map (phm : PersistentHashMap<_, _>) =
      let empty =
        match map |> Map.isEmpty, phm.IsEmpty with
        | true  , true
        | false , false -> true
        | _     , _     -> false

      let visitor k v =
        match map |> Map.tryFind k with
        | Some fv -> v = fv
        | _       -> false

      checkInvariant phm && (length phm = map.Count) && empty && phm.Visit (System.Func<_, _, _> visitor)

    let ra = ResizeArray<int> ()

    let rec loop map (phm : PersistentHashMap<_, _>) i =
      if i < vs.Length then
        match vs.[i] with
        | Add (k, v)  ->
          ra.Add k
          let map = map |> Map.add k v
          let phm = phm.Set (k, v)
          compare map phm && loop map phm (i + 1)
        | Remove r    ->
          if ra.Count > 0 then
            let r   = abs r % ra.Count
            let k   = ra.[r]
            ra.RemoveAt r
            let map = map |> Map.remove k
            let phm = phm.Unset k
            compare map phm && loop map phm (i + 1)
          else
            loop map phm (i + 1)
      else
        true

    loop Map.empty (empty ()) 0

  static member ``PHM mapValues must contain all added and mapped values`` (vs : (int*int) []) =
    let expected    = uniqueKey vs |> Array.map (fun (k, v) -> k, int64 k + int64 v + 1L)
    let phm         = vs |> fromArray |> mapValues (fun k v -> int64 k + int64 v + 1L)
    let actualArray = phm |> toSortedKeyArray

    notIdentical expected  actualArray
    && checkInvariant phm
    && expected = actualArray

let testLongInsert () =
#if DEBUG
  let count       = 1000
#else
  let count       = 1000000
#endif
  let multiplier  = 8
  printfn "testLongInsert: count:%d, multiplier:%d" count multiplier
  let random      = makeRandom 19740531
  let inserts     = [| for x in 1..count -> random 0 (count * multiplier) |]
  let lookups     = shuffle random inserts
  let removals    = shuffle random inserts

  let mutable phm = empty ()

  for i in inserts do
    phm <- phm.Set (i, i)
    match phm.TryFind i with
    | true, v when v = i  -> ()
    | _                   -> failwith "testLongInsert/insert/tryFind failed"

#if DEBUG
    if phm |> checkInvariant |> not then
      failwith "testLongInsert/insert/checkInvariant failed"
#endif

  if phm.IsEmpty then
    failwith "testLongInsert/postInsert/checkEmpty failed"

  if phm |> checkInvariant |> not then
    failwith "testLongInsert/postInsert/checkInvariant failed"

  for l in lookups do
    match phm.TryFind l with
    | true, v when v = l  -> ()
    | _                   -> failwith "testLongInsert/lookup/tryFind failed"

  if phm |> checkInvariant |> not then
    failwith "testLongInsert/postLookup/checkInvariant failed"

  for r in removals do
    phm <- phm.Unset r
    match phm.TryFind r with
    | false , _ -> ()
    | _         -> failwith "testLongInsert/remove/tryFind failed"

#if DEBUG
    if phm |> checkInvariant |> not then
      failwith "testLongInsert/remove/checkInvariant failed"
#endif

  if phm |> checkInvariant |> not then
    failwith "testLongInsert/postRemove/checkInvariant failed"

  if phm.IsEmpty |> not then
    failwith "testLongInsert/postRemove/checkEmpty failed"

  printfn "  Done"

let run () =
  Check.All<Properties> FsCheckConfig.config
  testLongInsert ()

