
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
    // BaseDebugTreeControl
    // ------------------------------------------------------------------------
    partial class BaseDebugTreeControl
    {
        #region Uninteresting generated code
        static readonly DependencyPropertyKey TreePropertyKey = DependencyProperty.RegisterReadOnly (
            "Tree",
            typeof (ObservableCollection<TreeNode>),
            typeof (BaseDebugTreeControl),
            new FrameworkPropertyMetadata (
                null,
                FrameworkPropertyMetadataOptions.None,
                Changed_Tree,
                Coerce_Tree          
            ));

        public static readonly DependencyProperty TreeProperty = TreePropertyKey.DependencyProperty;

        static void Changed_Tree (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as BaseDebugTreeControl;
            if (instance != null)
            {
                var oldValue = (ObservableCollection<TreeNode>)eventArgs.OldValue;
                var newValue = (ObservableCollection<TreeNode>)eventArgs.NewValue;

                if (oldValue != null)
                {
                    oldValue.CollectionChanged -= instance.CollectionChanged_Tree;
                }

                if (newValue != null)
                {
                    newValue.CollectionChanged += instance.CollectionChanged_Tree;
                }

                instance.Changed_Tree (oldValue, newValue);
            }
        }

        void CollectionChanged_Tree(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged_Tree (
                sender, 
                e.Action,
                e.OldStartingIndex,
                e.OldItems,
                e.NewStartingIndex,
                e.NewItems
                );
        }

        static object Coerce_Tree (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as BaseDebugTreeControl;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (ObservableCollection<TreeNode>)basevalue;

            instance.Coerce_Tree (ref value);

            if (value == null)
            {
               value = new ObservableCollection<TreeNode> ();
            }

            return value;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public BaseDebugTreeControl ()
        {
            CoerceAllProperties ();
            Constructed__BaseDebugTreeControl ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__BaseDebugTreeControl ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (TreeProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public ObservableCollection<TreeNode> Tree
        {
            get
            {
                return (ObservableCollection<TreeNode>)GetValue (TreeProperty);
            }
            private set
            {
                if (Tree != value)
                {
                    SetValue (TreePropertyKey, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Tree (ObservableCollection<TreeNode> oldValue, ObservableCollection<TreeNode> newValue);
        partial void Coerce_Tree (ref ObservableCollection<TreeNode> coercedValue);
        partial void CollectionChanged_Tree (object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}
                                   
