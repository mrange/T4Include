
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

namespace Source.WPF
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    using System.Windows;
    using System.Windows.Media;

    // ------------------------------------------------------------------------
    // CachedVisual
    // ------------------------------------------------------------------------
    partial class CachedVisual
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty ChildProperty = DependencyProperty.Register (
            "Child",
            typeof (UIElement),
            typeof (CachedVisual),
            new FrameworkPropertyMetadata (
                default (UIElement),
                FrameworkPropertyMetadataOptions.None,
                Changed_Child,
                Coerce_Child          
            ));

        static void Changed_Child (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as CachedVisual;
            if (instance != null)
            {
                var oldValue = (UIElement)eventArgs.OldValue;
                var newValue = (UIElement)eventArgs.NewValue;

                instance.Changed_Child (oldValue, newValue);
            }
        }


        static object Coerce_Child (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as CachedVisual;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (UIElement)basevalue;

            instance.Coerce_Child (ref value);


            return value;
        }

        public static readonly DependencyProperty IsCachingProperty = DependencyProperty.Register (
            "IsCaching",
            typeof (bool),
            typeof (CachedVisual),
            new FrameworkPropertyMetadata (
                default (bool),
                FrameworkPropertyMetadataOptions.None,
                Changed_IsCaching,
                Coerce_IsCaching          
            ));

        static void Changed_IsCaching (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as CachedVisual;
            if (instance != null)
            {
                var oldValue = (bool)eventArgs.OldValue;
                var newValue = (bool)eventArgs.NewValue;

                instance.Changed_IsCaching (oldValue, newValue);
            }
        }


        static object Coerce_IsCaching (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as CachedVisual;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (bool)basevalue;

            instance.Coerce_IsCaching (ref value);


            return value;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public CachedVisual ()
        {
            CoerceAllProperties ();
            Constructed__CachedVisual ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__CachedVisual ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (ChildProperty);
            CoerceValue (IsCachingProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public UIElement Child
        {
            get
            {
                return (UIElement)GetValue (ChildProperty);
            }
            set
            {
                if (Child != value)
                {
                    SetValue (ChildProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Child (UIElement oldValue, UIElement newValue);
        partial void Coerce_Child (ref UIElement coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public bool IsCaching
        {
            get
            {
                return (bool)GetValue (IsCachingProperty);
            }
            set
            {
                if (IsCaching != value)
                {
                    SetValue (IsCachingProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_IsCaching (bool oldValue, bool newValue);
        partial void Coerce_IsCaching (ref bool coercedValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}
                                   
