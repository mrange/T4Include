
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
    // ReflectionDecorator
    // ------------------------------------------------------------------------
    partial class ReflectionDecorator
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty ReflectionSizeProperty = DependencyProperty.Register (
            "ReflectionSize",
            typeof (double),
            typeof (ReflectionDecorator),
            new FrameworkPropertyMetadata (
                48.0,
                FrameworkPropertyMetadataOptions.None,
                Changed_ReflectionSize,
                Coerce_ReflectionSize          
            ));

        static void Changed_ReflectionSize (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as ReflectionDecorator;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_ReflectionSize (oldValue, newValue);
            }
        }


        static object Coerce_ReflectionSize (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as ReflectionDecorator;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            instance.Coerce_ReflectionSize (ref value);


            return value;
        }

        public static readonly DependencyProperty ReflectionSeparationProperty = DependencyProperty.Register (
            "ReflectionSeparation",
            typeof (double),
            typeof (ReflectionDecorator),
            new FrameworkPropertyMetadata (
                4.0,
                FrameworkPropertyMetadataOptions.None,
                Changed_ReflectionSeparation,
                Coerce_ReflectionSeparation          
            ));

        static void Changed_ReflectionSeparation (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as ReflectionDecorator;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_ReflectionSeparation (oldValue, newValue);
            }
        }


        static object Coerce_ReflectionSeparation (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as ReflectionDecorator;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            instance.Coerce_ReflectionSeparation (ref value);


            return value;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public ReflectionDecorator ()
        {
            CoerceAllProperties ();
            Constructed__ReflectionDecorator ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__ReflectionDecorator ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (ReflectionSizeProperty);
            CoerceValue (ReflectionSeparationProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public double ReflectionSize
        {
            get
            {
                return (double)GetValue (ReflectionSizeProperty);
            }
            set
            {
                if (ReflectionSize != value)
                {
                    SetValue (ReflectionSizeProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_ReflectionSize (double oldValue, double newValue);
        partial void Coerce_ReflectionSize (ref double coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double ReflectionSeparation
        {
            get
            {
                return (double)GetValue (ReflectionSeparationProperty);
            }
            set
            {
                if (ReflectionSeparation != value)
                {
                    SetValue (ReflectionSeparationProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_ReflectionSeparation (double oldValue, double newValue);
        partial void Coerce_ReflectionSeparation (ref double coercedValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}
                                   
