
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
            var oldValue = (UIElement)basevalue;
            var newValue = oldValue;

            instance.Coerce_Child (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty CacheStrategyProperty = DependencyProperty.Register (
            "CacheStrategy",
            typeof (Strategy),
            typeof (CachedVisual),
            new FrameworkPropertyMetadata (
                default (Strategy),
                FrameworkPropertyMetadataOptions.None,
                Changed_CacheStrategy,
                Coerce_CacheStrategy          
            ));

        static void Changed_CacheStrategy (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as CachedVisual;
            if (instance != null)
            {
                var oldValue = (Strategy)eventArgs.OldValue;
                var newValue = (Strategy)eventArgs.NewValue;

                instance.Changed_CacheStrategy (oldValue, newValue);
            }
        }


        static object Coerce_CacheStrategy (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as CachedVisual;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (Strategy)basevalue;
            var newValue = oldValue;

            instance.Coerce_CacheStrategy (oldValue, ref newValue);


            return newValue;
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
            CoerceValue (CacheStrategyProperty);
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
        partial void Coerce_Child (UIElement value, ref UIElement coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public Strategy CacheStrategy
        {
            get
            {
                return (Strategy)GetValue (CacheStrategyProperty);
            }
            set
            {
                if (CacheStrategy != value)
                {
                    SetValue (CacheStrategyProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_CacheStrategy (Strategy oldValue, Strategy newValue);
        partial void Coerce_CacheStrategy (Strategy value, ref Strategy coercedValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}
                                   
