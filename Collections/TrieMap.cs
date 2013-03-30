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

// ReSharper disable InconsistentNaming

namespace Source.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    sealed partial class TrieMap<TValue>
    {
        sealed partial class CaseInsensitiveCharComparer : IEqualityComparer<char>
        {
            public bool Equals(char x, char y)
            {
                return char.ToUpperInvariant(x) == char.ToUpperInvariant(y);
            }

            public int GetHashCode(char obj)
            {
                return char.ToUpperInvariant(obj).GetHashCode();
            }
        }

        sealed partial class Node
        {
            readonly Dictionary<char, Node> m_edges = new Dictionary<char, Node>(new CaseInsensitiveCharComparer());
            readonly Func<char, Node> m_defaultFindEdge;

            public bool HasValue;
            public TValue Value;

            public Func<char, Node> FindEdge;

            public Node ()
            {
                m_defaultFindEdge = Impl_FindEdge;
                FindEdge = m_defaultFindEdge;
            }

            public Node AddEdge (char ch)
            {
                var node = new Node ();
                m_edges.Add(ch, node);
                FindEdge = m_defaultFindEdge;
                return node;
            }

            public void Recursive_Optimize ()
            {
                Optimize();

                foreach (var edge in m_edges)
                {
                    edge.Value.Recursive_Optimize();
                }
            }

            static bool HasCases (char ch)
            {
                var lowerCase = char.ToLowerInvariant(ch);
                var upperCase = char.ToUpperInvariant(ch);

                return lowerCase != upperCase;
            }

            static char[] GetTestCases (char ch)
            {
                var lowerCase = char.ToLowerInvariant(ch);
                var upperCase = char.ToUpperInvariant(ch);

                if (lowerCase != upperCase)
                {
                    return
                        new[]
                            {
                                lowerCase, 
                                upperCase,
                            };
                }
                else
                {
                    return
                        new[]
                            {
                                ch,
                            };
                }
            }

            static ConstantExpression[] GetTestCaseExpressions(Type charType, KeyValuePair<char, Node> kv)
            {
                var expressions = GetTestCases(kv.Key).Select(ch => Expression.Constant(ch, charType)).ToArray();
                return expressions;
            }
            void Optimize()
            {
                if (ReferenceEquals(m_defaultFindEdge, FindEdge))
                {
                    var charType = typeof (char);
                    var nodeType = typeof (Node);
                    var nullExpression = Expression.Constant(null, nodeType);
                    var inputExpression = Expression.Parameter(charType, "input");

                    Expression body;

                    if (m_edges.Count == 1 && !HasCases(m_edges.First().Key))
                    {
                        var kv = m_edges.First();
                        body = Expression.Condition(
                            Expression.Equal(Expression.Constant(kv.Key, charType), inputExpression),
                            Expression.Constant(kv.Value, nodeType),
                            nullExpression
                            );
                    }
                    else if (m_edges.Count > 0)
                    {
                        body = Expression.Switch(
                            inputExpression,
                            nullExpression,
                            m_edges
                                .Select(kv =>
                                        Expression
                                            .SwitchCase(
                                                Expression.Constant(kv.Value, nodeType),
                                                GetTestCaseExpressions(charType, kv)
                                                ))
                                .ToArray()
                            );
                    }
                    else
                    {
                        body = nullExpression;
                    }

                    var lambda = Expression.Lambda<Func<char, Node>>(
                        body,
                        inputExpression
                        );

                    FindEdge = lambda.Compile();
                }
            }


            Node Impl_FindEdge (char ch)
            {
                Node value;
                return m_edges.TryGetValue(ch, out value) ? value : null;
            }

        }

        readonly Node m_root = new Node();

        public bool AddOrReplace (string key, TValue value)
        {
            key = key ?? "";
            var length = key.Length;
            var node = m_root;
            for (var iter = 0 ; iter < length; ++iter)
            {
                var ch = key[iter];

                var edge = node.FindEdge(ch);
                if (edge == null)
                {
                    edge = node.AddEdge(ch);
                }
                node = edge;
            }

            var replaced = !node.HasValue;

            node.Value = value;
            node.HasValue = true;

            return replaced;
        }

        public bool Remove (string key, TValue value)
        {
            key = key ?? "";
            var length = key.Length;
            var node = m_root;
            for (var iter = 0; iter < length; ++iter)
            {
                var ch = key[iter];

                var edge = node.FindEdge(ch);
                if (edge == null)
                {
                    return false;
                }
                node = edge;
            }

            node.Value = default(TValue);
            node.HasValue = false;

            return true;

        }

        public bool TryGetPartialMatch (
            string match,
            out int depth,
            out TValue value
            )
        {
            match = match ?? "";
            depth = 0;
            value = default(TValue);
            var length = match.Length;
            var node = m_root;
            for (var iter = 0; iter < length; ++iter)
            {
                var ch = match[iter];

                var edge = node.FindEdge(ch);
                if (edge == null)
                {
                    return false;
                }

                if (edge.HasValue)
                {
                    depth = iter; 
                    value = edge.Value;
                    return true;
                }

                node = edge;
            }

            return false;
        }

        public bool TryGetMostSpecificPartialMatch(
            string match,
            out int depth,
            out TValue value
            )
        {
            match = match ?? "";
            depth = 0;
            value = default(TValue);
            var length = match.Length;
            var node = m_root;

            Node currentBestMatch = null;

            for (var iter = 0; iter < length; ++iter)
            {
                var ch = match[iter];

                var edge = node.FindEdge(ch);
                if (edge == null)
                {
                    if (currentBestMatch != null)
                    {
                        depth = iter;
                        value = currentBestMatch.Value;
                        return true;
                    }

                    return false;
                }

                if (edge.HasValue)
                {
                    currentBestMatch = edge;
                }

                node = edge;
            }


            if (currentBestMatch != null)
            {
                depth = length;
                value = currentBestMatch.Value;
                return true;
            }

            return false;
        }

        public bool TryGetExactMatch(
            string match,
            out TValue value
            )
        {
            match = match ?? "";
            value = default(TValue);
            var length = match.Length;
            var node = m_root;

            for (var iter = 0; iter < length; ++iter)
            {
                var ch = match[iter];

                var edge = node.FindEdge(ch);
                if (edge == null)
                {
                    return false;
                }

                node = edge;
            }

            if (node.HasValue)
            {
                value = node.Value;
                return true;
            }
            
            return false;
        }

        public void Optimize()
        {
            m_root.Recursive_Optimize();
        }
    }
}