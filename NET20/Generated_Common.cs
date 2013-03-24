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

// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################






namespace System
{
    public delegate TResult Func<out TResult> ();
    public delegate TResult Func<in T0, out TResult> (T0 v0);

    public delegate void Action<
            in T0
        ,   in T1   
        > (
            T0 v0
        ,   T1 v1  
        );

    public delegate TResult Func<
            in T0
        ,   in T1   
        ,   out TResult
        > (
            T0 v0
        ,   T1 v1  
        );

    public delegate void Action<
            in T0
        ,   in T1   
        ,   in T2   
        > (
            T0 v0
        ,   T1 v1  
        ,   T2 v2  
        );

    public delegate TResult Func<
            in T0
        ,   in T1   
        ,   in T2   
        ,   out TResult
        > (
            T0 v0
        ,   T1 v1  
        ,   T2 v2  
        );

    public delegate void Action<
            in T0
        ,   in T1   
        ,   in T2   
        ,   in T3   
        > (
            T0 v0
        ,   T1 v1  
        ,   T2 v2  
        ,   T3 v3  
        );

    public delegate TResult Func<
            in T0
        ,   in T1   
        ,   in T2   
        ,   in T3   
        ,   out TResult
        > (
            T0 v0
        ,   T1 v1  
        ,   T2 v2  
        ,   T3 v3  
        );


}
