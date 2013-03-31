
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
        public static readonly DependencyProperty ReflectionHeightProperty = DependencyProperty.Register (
            "ReflectionHeight",
            typeof (double),
            typeof (ReflectionDecorator),
            new FrameworkPropertyMetadata (
                48.0,
                FrameworkPropertyMetadataOptions.None,
                Changed_ReflectionHeight,
                Coerce_ReflectionHeight          
            ));

        static void Changed_ReflectionHeight (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as ReflectionDecorator;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_ReflectionHeight (oldValue, newValue);
            }
        }


        static object Coerce_ReflectionHeight (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as ReflectionDecorator;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            instance.Coerce_ReflectionHeight (ref value);


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
            CoerceValue (ReflectionHeightProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public double ReflectionHeight
        {
            get
            {
                return (double)GetValue (ReflectionHeightProperty);
            }
            set
            {
                if (ReflectionHeight != value)
                {
                    SetValue (ReflectionHeightProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_ReflectionHeight (double oldValue, double newValue);
        partial void Coerce_ReflectionHeight (ref double coercedValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}
                                   
