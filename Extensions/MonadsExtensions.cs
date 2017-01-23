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



namespace Source.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Common;

    // Inspired by the great blog: http://blogs.claritycon.com/blog/2013/08/functional-concepts-c/

    static partial class MonadsExtensions
    {
        public static TResult With<TSource, TResult> (this TSource source, Func<TSource, TResult> action) 
            where TSource : class
        {
            return action != null && source != null ? action (source) : default (TResult);
        }

        public static TResult Return<TSource, TResult> (this TSource source, Func<TSource, TResult> action, TResult defaultValue) 
            where TSource : class
        {
            return action != null && source != null ? action (source) : defaultValue;
        }

        public static TSource Do<TSource> (this TSource source, Action<TSource> action) 
            where TSource : class
        {
            if (action != null && source != null)
            {
                action (source);
            }

            return source;
        }

        public static TSource If<TSource> (this TSource source, Func<TSource,bool> predicate) 
            where TSource : class
        {
            return predicate != null && source != null && predicate (source) ? source : null;
        }

        public static TSource IfNot<TSource> (this TSource source, Func<TSource,bool> predicate) 
            where TSource : class
        {
            return predicate != null && source != null && !predicate (source) ? source : null;
        }

        public static TSource LogInfo<TSource> (this TSource source, string format) 
            where TSource : class
        {
            if (source != null)
            {
                Log.Info (format, source);
            }

            return source;
        }

        public static TSource Recover<TSource> (this TSource source, Func<TSource> action) 
            where TSource : class
        {
            return source ?? action ();
        }

        public static TTo OfType<TTo> (this object source, TTo defaultValue = default (TTo))
        {
            return source is TTo ? (TTo) source : default (TTo);
        }


        public static TResult With<TSource, TResult> (this TSource? source, Func<TSource, TResult> action) 
            where TSource : struct
        {
            return action != null && source != null ? action (source.Value) : default (TResult);
        }

        public static TResult Return<TSource, TResult> (this TSource? source, Func<TSource, TResult> action, TResult defaultValue) 
            where TSource : struct
        {
            return action != null && source != null ? action (source.Value) : defaultValue;
        }

        public static TSource? Do<TSource> (this TSource? source, Action<TSource> action) 
            where TSource : struct
        {
            if (action != null && source != null)
            {
                action (source.Value);
            }

            return source;
        }

        public static TSource? If<TSource> (this TSource? source, Func<TSource,bool> predicate) 
            where TSource : struct
        {
            return predicate != null && source != null && predicate (source.Value) ? source : null;
        }

        public static TSource? IfNot<TSource> (this TSource? source, Func<TSource,bool> predicate) 
            where TSource : struct
        {
            return predicate != null && source != null && !predicate (source.Value) ? source : null;
        }

        public static TSource? LogInfo<TSource> (this TSource? source, string format) 
            where TSource : struct
        {
            if (source != null)
            {
                Log.Info (format, source.Value);
            }

            return source;
        }

        public static TSource? Recover<TSource> (this TSource? source, Func<TSource> action) 
            where TSource : struct
        {
            return source ?? action ();
        }

        public static IEnumerable Do (this IEnumerable source, Action<object> action) 
        {
            if (source != null && action != null)
            {
                foreach (var o in source)
                {
                    if (o != null)
                    {
                        action (o);
                    }
                    yield return o;
                }
            }
        }
    
        public static IEnumerable<TSource> Do<TSource> (this IEnumerable<TSource> source, Action<TSource> action) 
            where TSource : class
        {
            if (source != null && action != null)
            {
                foreach (var o in source)
                {
                    if (o != null)
                    {
                        action (o);
                    }
                    yield return o;
                }
            }
        }
    
        public static IEnumerable<TResult> With<TSource, TResult> (this IEnumerable<TSource> source, Func<TSource, TResult> action) 
            where TSource : class
        {
            if (source != null && action != null)
            {
                foreach (var o in source)
                {
                    if (o != null)
                    {
                        yield return action (o);
                    }
                    else
                    {
                        yield return default (TResult);
                    }
                }
            }
        }
    
        public static IEnumerable<TSource?> Do<TSource> (this IEnumerable<TSource?> source, Action<TSource> action) 
            where TSource : struct
        {
            if (source != null && action != null)
            {
                foreach (var o in source)
                {
                    if (o != null)
                    {
                        action (o.Value);
                    }
                    yield return o;
                }
            }
        }
    
        public static IEnumerable<TResult> With<TSource, TResult> (this IEnumerable<TSource?> source, Func<TSource, TResult> action) 
            where TSource : struct
        {
            if (source != null && action != null)
            {
                foreach (var o in source)
                {
                    if (o != null)
                    {
                        yield return action (o.Value);
                    }
                    else
                    {
                        yield return default (TResult);
                    }
                }
            }
        }
    
        public static IDictionary<TKey, TValue> Do<TKey, TValue> (this IDictionary<TKey, TValue> source, Action<TKey, TValue> action) 
        {
            if (source != null && action != null)
            {
                foreach (var o in source)
                {
                    action (o.Key, o.Value);
                }
            }

            return source;
        }
    
        public static TValue With<TKey, TValue> (this IDictionary<TKey, TValue> source, TKey key, TValue defaultValue) 
        {
            if (source != null)
            {
                TValue value;
                return source.TryGetValue (key, out value) ? value : defaultValue;
            }
            else
            {
                return defaultValue;
            }
        }
    
    }
}
