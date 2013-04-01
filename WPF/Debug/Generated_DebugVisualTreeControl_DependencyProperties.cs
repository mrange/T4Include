
// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################



                                   

// ReSharper disable CompareOfFloatsByEqualityOperator
// ReSharper disable InconsistentNaming
// ReSharper disable InvocationIsSkipped
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PossibleUnintendedReferenceComparison
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast
// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedMember.Local

namespace Source.WPF.Debug
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    using System.Windows;
    using System.Windows.Media;

    // ------------------------------------------------------------------------
    // DebugVisualTreeControl
    // ------------------------------------------------------------------------
    partial class DebugVisualTreeControl
    {
        #region Uninteresting generated code
        static readonly DependencyPropertyKey VisualTreePropertyKey = DependencyProperty.RegisterReadOnly (
            "VisualTree",
            typeof (ObservableCollection<VisualTreeNode>),
            typeof (DebugVisualTreeControl),
            new FrameworkPropertyMetadata (
                null,
                FrameworkPropertyMetadataOptions.None,
                Changed_VisualTree,
                Coerce_VisualTree          
            ));

        public static readonly DependencyProperty VisualTreeProperty = VisualTreePropertyKey.DependencyProperty;

        static void Changed_VisualTree (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as DebugVisualTreeControl;
            if (instance != null)
            {
                var oldValue = (ObservableCollection<VisualTreeNode>)eventArgs.OldValue;
                var newValue = (ObservableCollection<VisualTreeNode>)eventArgs.NewValue;

                if (oldValue != null)
                {
                    oldValue.CollectionChanged -= instance.CollectionChanged_VisualTree;
                }

                if (newValue != null)
                {
                    newValue.CollectionChanged += instance.CollectionChanged_VisualTree;
                }

                instance.Changed_VisualTree (oldValue, newValue);
            }
        }

        void CollectionChanged_VisualTree(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged_VisualTree (
                sender, 
                e.Action,
                e.OldStartingIndex,
                e.OldItems,
                e.NewStartingIndex,
                e.NewItems
                );
        }

        static object Coerce_VisualTree (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as DebugVisualTreeControl;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (ObservableCollection<VisualTreeNode>)basevalue;

            instance.Coerce_VisualTree (ref value);

            if (value == null)
            {
               value = new ObservableCollection<VisualTreeNode> ();
            }

            return value;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public DebugVisualTreeControl ()
        {
            CoerceAllProperties ();
            Constructed__DebugVisualTreeControl ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__DebugVisualTreeControl ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (VisualTreeProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public ObservableCollection<VisualTreeNode> VisualTree
        {
            get
            {
                return (ObservableCollection<VisualTreeNode>)GetValue (VisualTreeProperty);
            }
            private set
            {
                if (VisualTree != value)
                {
                    SetValue (VisualTreePropertyKey, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_VisualTree (ObservableCollection<VisualTreeNode> oldValue, ObservableCollection<VisualTreeNode> newValue);
        partial void Coerce_VisualTree (ref ObservableCollection<VisualTreeNode> coercedValue);
        partial void CollectionChanged_VisualTree (object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}
                                   
