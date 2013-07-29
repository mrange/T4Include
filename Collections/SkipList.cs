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

// ReSharper disable PartialTypeWithSinglePart

// ### INCLUDE: Generated_SkipList.cs

namespace Source.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    sealed partial class SkipList<TKey, TValue> : IEnumerable<SkipList<TKey,TValue>.INode> 
    {
        const double PLimit = 0.125;

        public interface INode
        {
            TKey    Key     { get; }
            TValue  Value   { get; set; }
        }

        abstract partial class BaseNode : INode
        {
            public TKey     Key         { get; set; }
            public TValue   Value       { get; set; }

            public abstract BaseNode this[int idx]
            {
                get;
                set;
            }

            public abstract int Length { get; }

            public override string ToString()
            {
                var sb = new StringBuilder ();

                sb.Append ("{ Key = ");
                sb.Append (Key);
                sb.Append (", Value = ");
                sb.Append (Value);
                sb.Append ("}");

                return sb.ToString ();
            }
        }

        sealed partial class RootNode : BaseNode
        {
            // Invariant: Always != null
            // Invariant: Always .Length > 0
            BaseNode[]   m_levels = new BaseNode[1];

            public override BaseNode this[int idx]
            {
                get { return m_levels[idx]; }
                set { m_levels[idx] = value; }
            }

            public override int Length
            {
                get { return m_levels.Length; }
            }

            public void Resize (int levels, bool allowShrink = false)
            {
                if (!allowShrink && levels < m_levels.Length)
                {
                    return;
                }

                Array.Resize (ref m_levels, levels);
            }
        }

        readonly IComparer<TKey>    m_comparer                          ;
        readonly RootNode           m_head          = new RootNode ()   ;
        readonly Random             m_random        = new Random ()     ;
        readonly double             m_probability                       ;

        int      m_count                                                ;

        public SkipList ()
            :   this (null)
        {
        }

        public SkipList (IComparer<TKey> comparer)
            :   this (0.5, comparer)
        {
        }

        public SkipList (double probability)
            :   this (probability, null)
        {
        }

        public SkipList (double probability, IComparer<TKey> comparer)
        {
            m_probability   = Math.Min (Math.Max (probability, PLimit), 1 - PLimit);
            m_comparer      = comparer ?? Comparer<TKey>.Default;
        }

        BaseNode[] FindInsertionPoint (TKey key)
        {
            var insertionPoint = new BaseNode[m_head.Length];
            BaseNode previous = m_head;

            for (var level = insertionPoint.Length - 1; level >= 0; --level)
            {
                var node    = previous[level];

                while (node != null && (m_comparer.Compare (key, node.Key)) > 0)
                {
                    previous = node;
                    node = node[level];
                }

                insertionPoint[level] = previous;
            }

            return insertionPoint;
        }

        BaseNode FindMatch (TKey key)
        {
            var insertionPoint = new BaseNode[m_head.Length];
            BaseNode previous = m_head;

            for (var level = insertionPoint.Length - 1; level >= 0; --level)
            {
                var node    = previous[level];
                var result  = int.MinValue;

                while (node != null && (result = m_comparer.Compare (key, node.Key)) > 0)
                {
                    previous = node;
                    node = node[level];
                }

                if (result == 0)
                {
                    return node;
                }
            }

            return null;
        }

        int ComputeLevelCount ()
        {
            var level = 1;

            while (level < MaxLevel && m_random.NextDouble () < m_probability)
            {
                ++level;
            }

            return level;
        }

        public INode Find (TKey key)
        {
            return FindMatch (key);

        }

        public bool TryAdd (TKey key, TValue value)
        {
            var insertionPoint = FindInsertionPoint (key);

            var existingNode = insertionPoint[0][0];
            if (
                    existingNode != null
                &&  m_comparer.Compare (existingNode.Key, key) == 0)
            {
                return false;
            }

            var levelCount = ComputeLevelCount ();

            var node = CreateNode (levelCount);
            node.Key = key;
            node.Value = value;

            var oldLevelCount = m_head.Length;

            if (levelCount > oldLevelCount)
            {
                m_head.Resize (levelCount);
                Array.Resize (ref insertionPoint, levelCount);
                
                for (var iter = oldLevelCount; iter < levelCount; ++iter)
                {
                    insertionPoint[iter] = m_head;
                }
            }

            for (var iter = 0; iter < levelCount; ++iter)
            {
                node[iter] = insertionPoint[iter][iter];
                insertionPoint[iter][iter] = node;
            }

            ++m_count;

            return true;
        }

        public bool TryRemove (TKey key)
        {
            var insertionPoint = FindInsertionPoint (key);

            var node = insertionPoint[0][0];

            if (node == null)
            {
                return false;
            }

            if (m_comparer.Compare (node.Key, key) != 0)
            {
                return false;
            }

            for (var iter = 0; iter < node.Length; ++iter)
            {
                insertionPoint[iter][iter] = node[iter];
            }

            --m_count;

            return true;
        }

        public void Clear ()
        {
            m_head.Resize (1, allowShrink:true);
            m_count = 0;
            m_head[0] = null;
        }

        public int Count { get {return m_count;}}

        public IEnumerator<INode> GetEnumerator()
        {
            var node = m_head[0];

            while (node != null)
            {
                yield return node;
                node = node[0];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
