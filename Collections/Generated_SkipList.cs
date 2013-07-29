// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################





// ReSharper disable PartialTypeWithSinglePart


namespace Source.Collections
{
    using System;

    partial class SkipList<TKey, TValue>
    {
        public int MaxLevel = 30;

        static BaseNode CreateNode (int size)
        {
            switch (size)
            {
            case 1: return new Node1 ();
            case 2: return new Node2 ();
            case 3: return new Node3 ();
            case 4: return new Node4 ();
            case 5: return new Node5 ();
            case 6: return new Node6 ();
            case 7: return new Node7 ();
            case 8: return new Node8 ();
            case 9: return new Node9 ();
            case 10: return new Node10 ();
            case 11: return new Node11 ();
            case 12: return new Node12 ();
            case 13: return new Node13 ();
            case 14: return new Node14 ();
            case 15: return new Node15 ();
            case 16: return new Node16 ();
            case 17: return new Node17 ();
            case 18: return new Node18 ();
            case 19: return new Node19 ();
            case 20: return new Node20 ();
            case 21: return new Node21 ();
            case 22: return new Node22 ();
            case 23: return new Node23 ();
            case 24: return new Node24 ();
            case 25: return new Node25 ();
            case 26: return new Node26 ();
            case 27: return new Node27 ();
            case 28: return new Node28 ();
            case 29: return new Node29 ();
            case 30: return new Node30 ();
        
            default: throw new IndexOutOfRangeException ();
            }
        }
    

        sealed partial class Node1 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 1; }
            }

            BaseNode m_0;
        }


        sealed partial class Node2 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 2; }
            }

            BaseNode m_0;
            BaseNode m_1;
        }


        sealed partial class Node3 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 3; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
        }


        sealed partial class Node4 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 4; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
        }


        sealed partial class Node5 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 5; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
        }


        sealed partial class Node6 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 6; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
        }


        sealed partial class Node7 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 7; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
        }


        sealed partial class Node8 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 8; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
        }


        sealed partial class Node9 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 9; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
        }


        sealed partial class Node10 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 10; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
        }


        sealed partial class Node11 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 11; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
        }


        sealed partial class Node12 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 12; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
        }


        sealed partial class Node13 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 13; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
        }


        sealed partial class Node14 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 14; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
        }


        sealed partial class Node15 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 15; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
        }


        sealed partial class Node16 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 16; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
        }


        sealed partial class Node17 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 17; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
        }


        sealed partial class Node18 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 18; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
        }


        sealed partial class Node19 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 19; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
        }


        sealed partial class Node20 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    case 19: return m_19;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    case 19: m_19 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 20; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
            BaseNode m_19;
        }


        sealed partial class Node21 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    case 19: return m_19;
                    case 20: return m_20;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    case 19: m_19 = value; break;
                    case 20: m_20 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 21; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
            BaseNode m_19;
            BaseNode m_20;
        }


        sealed partial class Node22 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    case 19: return m_19;
                    case 20: return m_20;
                    case 21: return m_21;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    case 19: m_19 = value; break;
                    case 20: m_20 = value; break;
                    case 21: m_21 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 22; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
            BaseNode m_19;
            BaseNode m_20;
            BaseNode m_21;
        }


        sealed partial class Node23 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    case 19: return m_19;
                    case 20: return m_20;
                    case 21: return m_21;
                    case 22: return m_22;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    case 19: m_19 = value; break;
                    case 20: m_20 = value; break;
                    case 21: m_21 = value; break;
                    case 22: m_22 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 23; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
            BaseNode m_19;
            BaseNode m_20;
            BaseNode m_21;
            BaseNode m_22;
        }


        sealed partial class Node24 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    case 19: return m_19;
                    case 20: return m_20;
                    case 21: return m_21;
                    case 22: return m_22;
                    case 23: return m_23;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    case 19: m_19 = value; break;
                    case 20: m_20 = value; break;
                    case 21: m_21 = value; break;
                    case 22: m_22 = value; break;
                    case 23: m_23 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 24; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
            BaseNode m_19;
            BaseNode m_20;
            BaseNode m_21;
            BaseNode m_22;
            BaseNode m_23;
        }


        sealed partial class Node25 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    case 19: return m_19;
                    case 20: return m_20;
                    case 21: return m_21;
                    case 22: return m_22;
                    case 23: return m_23;
                    case 24: return m_24;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    case 19: m_19 = value; break;
                    case 20: m_20 = value; break;
                    case 21: m_21 = value; break;
                    case 22: m_22 = value; break;
                    case 23: m_23 = value; break;
                    case 24: m_24 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 25; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
            BaseNode m_19;
            BaseNode m_20;
            BaseNode m_21;
            BaseNode m_22;
            BaseNode m_23;
            BaseNode m_24;
        }


        sealed partial class Node26 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    case 19: return m_19;
                    case 20: return m_20;
                    case 21: return m_21;
                    case 22: return m_22;
                    case 23: return m_23;
                    case 24: return m_24;
                    case 25: return m_25;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    case 19: m_19 = value; break;
                    case 20: m_20 = value; break;
                    case 21: m_21 = value; break;
                    case 22: m_22 = value; break;
                    case 23: m_23 = value; break;
                    case 24: m_24 = value; break;
                    case 25: m_25 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 26; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
            BaseNode m_19;
            BaseNode m_20;
            BaseNode m_21;
            BaseNode m_22;
            BaseNode m_23;
            BaseNode m_24;
            BaseNode m_25;
        }


        sealed partial class Node27 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    case 19: return m_19;
                    case 20: return m_20;
                    case 21: return m_21;
                    case 22: return m_22;
                    case 23: return m_23;
                    case 24: return m_24;
                    case 25: return m_25;
                    case 26: return m_26;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    case 19: m_19 = value; break;
                    case 20: m_20 = value; break;
                    case 21: m_21 = value; break;
                    case 22: m_22 = value; break;
                    case 23: m_23 = value; break;
                    case 24: m_24 = value; break;
                    case 25: m_25 = value; break;
                    case 26: m_26 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 27; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
            BaseNode m_19;
            BaseNode m_20;
            BaseNode m_21;
            BaseNode m_22;
            BaseNode m_23;
            BaseNode m_24;
            BaseNode m_25;
            BaseNode m_26;
        }


        sealed partial class Node28 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    case 19: return m_19;
                    case 20: return m_20;
                    case 21: return m_21;
                    case 22: return m_22;
                    case 23: return m_23;
                    case 24: return m_24;
                    case 25: return m_25;
                    case 26: return m_26;
                    case 27: return m_27;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    case 19: m_19 = value; break;
                    case 20: m_20 = value; break;
                    case 21: m_21 = value; break;
                    case 22: m_22 = value; break;
                    case 23: m_23 = value; break;
                    case 24: m_24 = value; break;
                    case 25: m_25 = value; break;
                    case 26: m_26 = value; break;
                    case 27: m_27 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 28; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
            BaseNode m_19;
            BaseNode m_20;
            BaseNode m_21;
            BaseNode m_22;
            BaseNode m_23;
            BaseNode m_24;
            BaseNode m_25;
            BaseNode m_26;
            BaseNode m_27;
        }


        sealed partial class Node29 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    case 19: return m_19;
                    case 20: return m_20;
                    case 21: return m_21;
                    case 22: return m_22;
                    case 23: return m_23;
                    case 24: return m_24;
                    case 25: return m_25;
                    case 26: return m_26;
                    case 27: return m_27;
                    case 28: return m_28;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    case 19: m_19 = value; break;
                    case 20: m_20 = value; break;
                    case 21: m_21 = value; break;
                    case 22: m_22 = value; break;
                    case 23: m_23 = value; break;
                    case 24: m_24 = value; break;
                    case 25: m_25 = value; break;
                    case 26: m_26 = value; break;
                    case 27: m_27 = value; break;
                    case 28: m_28 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 29; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
            BaseNode m_19;
            BaseNode m_20;
            BaseNode m_21;
            BaseNode m_22;
            BaseNode m_23;
            BaseNode m_24;
            BaseNode m_25;
            BaseNode m_26;
            BaseNode m_27;
            BaseNode m_28;
        }


        sealed partial class Node30 : BaseNode
        {
            public override BaseNode this[int idx]
            {
                get 
                {
                    switch (idx)
                    {
                    case 0: return m_0;
                    case 1: return m_1;
                    case 2: return m_2;
                    case 3: return m_3;
                    case 4: return m_4;
                    case 5: return m_5;
                    case 6: return m_6;
                    case 7: return m_7;
                    case 8: return m_8;
                    case 9: return m_9;
                    case 10: return m_10;
                    case 11: return m_11;
                    case 12: return m_12;
                    case 13: return m_13;
                    case 14: return m_14;
                    case 15: return m_15;
                    case 16: return m_16;
                    case 17: return m_17;
                    case 18: return m_18;
                    case 19: return m_19;
                    case 20: return m_20;
                    case 21: return m_21;
                    case 22: return m_22;
                    case 23: return m_23;
                    case 24: return m_24;
                    case 25: return m_25;
                    case 26: return m_26;
                    case 27: return m_27;
                    case 28: return m_28;
                    case 29: return m_29;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
                set 
                { 
                    switch (idx)
                    {
                    case 0: m_0 = value; break;
                    case 1: m_1 = value; break;
                    case 2: m_2 = value; break;
                    case 3: m_3 = value; break;
                    case 4: m_4 = value; break;
                    case 5: m_5 = value; break;
                    case 6: m_6 = value; break;
                    case 7: m_7 = value; break;
                    case 8: m_8 = value; break;
                    case 9: m_9 = value; break;
                    case 10: m_10 = value; break;
                    case 11: m_11 = value; break;
                    case 12: m_12 = value; break;
                    case 13: m_13 = value; break;
                    case 14: m_14 = value; break;
                    case 15: m_15 = value; break;
                    case 16: m_16 = value; break;
                    case 17: m_17 = value; break;
                    case 18: m_18 = value; break;
                    case 19: m_19 = value; break;
                    case 20: m_20 = value; break;
                    case 21: m_21 = value; break;
                    case 22: m_22 = value; break;
                    case 23: m_23 = value; break;
                    case 24: m_24 = value; break;
                    case 25: m_25 = value; break;
                    case 26: m_26 = value; break;
                    case 27: m_27 = value; break;
                    case 28: m_28 = value; break;
                    case 29: m_29 = value; break;
                    default: throw new IndexOutOfRangeException ();
                    } 
                }
            }

            public override int Length
            {
                get { return 30; }
            }

            BaseNode m_0;
            BaseNode m_1;
            BaseNode m_2;
            BaseNode m_3;
            BaseNode m_4;
            BaseNode m_5;
            BaseNode m_6;
            BaseNode m_7;
            BaseNode m_8;
            BaseNode m_9;
            BaseNode m_10;
            BaseNode m_11;
            BaseNode m_12;
            BaseNode m_13;
            BaseNode m_14;
            BaseNode m_15;
            BaseNode m_16;
            BaseNode m_17;
            BaseNode m_18;
            BaseNode m_19;
            BaseNode m_20;
            BaseNode m_21;
            BaseNode m_22;
            BaseNode m_23;
            BaseNode m_24;
            BaseNode m_25;
            BaseNode m_26;
            BaseNode m_27;
            BaseNode m_28;
            BaseNode m_29;
        }

    }
}
