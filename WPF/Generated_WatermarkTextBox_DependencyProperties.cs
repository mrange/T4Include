
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
    // WatermarkTextBox
    // ------------------------------------------------------------------------
    partial class WatermarkTextBox
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty WatermarkTextProperty = DependencyProperty.Register (
            "WatermarkText",
            typeof (string),
            typeof (WatermarkTextBox),
            new FrameworkPropertyMetadata (
                default (string),
                FrameworkPropertyMetadataOptions.None,
                Changed_WatermarkText,
                Coerce_WatermarkText          
            ));

        static void Changed_WatermarkText (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as WatermarkTextBox;
            if (instance != null)
            {
                var oldValue = (string)eventArgs.OldValue;
                var newValue = (string)eventArgs.NewValue;

                instance.Changed_WatermarkText (oldValue, newValue);
            }
        }


        static object Coerce_WatermarkText (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as WatermarkTextBox;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (string)basevalue;
            var newValue = oldValue;

            instance.Coerce_WatermarkText (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty WatermarkForegroundProperty = DependencyProperty.Register (
            "WatermarkForeground",
            typeof (Brush),
            typeof (WatermarkTextBox),
            new FrameworkPropertyMetadata (
                default (Brush),
                FrameworkPropertyMetadataOptions.None,
                Changed_WatermarkForeground,
                Coerce_WatermarkForeground          
            ));

        static void Changed_WatermarkForeground (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as WatermarkTextBox;
            if (instance != null)
            {
                var oldValue = (Brush)eventArgs.OldValue;
                var newValue = (Brush)eventArgs.NewValue;

                instance.Changed_WatermarkForeground (oldValue, newValue);
            }
        }


        static object Coerce_WatermarkForeground (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as WatermarkTextBox;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (Brush)basevalue;
            var newValue = oldValue;

            instance.Coerce_WatermarkForeground (oldValue, ref newValue);


            return newValue;
        }

        static readonly DependencyPropertyKey IsWatermarkVisiblePropertyKey = DependencyProperty.RegisterReadOnly (
            "IsWatermarkVisible",
            typeof (bool),
            typeof (WatermarkTextBox),
            new FrameworkPropertyMetadata (
                true,
                FrameworkPropertyMetadataOptions.None,
                Changed_IsWatermarkVisible,
                Coerce_IsWatermarkVisible          
            ));

        public static readonly DependencyProperty IsWatermarkVisibleProperty = IsWatermarkVisiblePropertyKey.DependencyProperty;

        static void Changed_IsWatermarkVisible (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as WatermarkTextBox;
            if (instance != null)
            {
                var oldValue = (bool)eventArgs.OldValue;
                var newValue = (bool)eventArgs.NewValue;

                instance.Changed_IsWatermarkVisible (oldValue, newValue);
            }
        }


        static object Coerce_IsWatermarkVisible (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as WatermarkTextBox;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (bool)basevalue;
            var newValue = oldValue;

            instance.Coerce_IsWatermarkVisible (oldValue, ref newValue);


            return newValue;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public WatermarkTextBox ()
        {
            CoerceAllProperties ();
            Constructed__WatermarkTextBox ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__WatermarkTextBox ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (WatermarkTextProperty);
            CoerceValue (WatermarkForegroundProperty);
            CoerceValue (IsWatermarkVisibleProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public string WatermarkText
        {
            get
            {
                return (string)GetValue (WatermarkTextProperty);
            }
            set
            {
                if (WatermarkText != value)
                {
                    SetValue (WatermarkTextProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_WatermarkText (string oldValue, string newValue);
        partial void Coerce_WatermarkText (string value, ref string coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public Brush WatermarkForeground
        {
            get
            {
                return (Brush)GetValue (WatermarkForegroundProperty);
            }
            set
            {
                if (WatermarkForeground != value)
                {
                    SetValue (WatermarkForegroundProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_WatermarkForeground (Brush oldValue, Brush newValue);
        partial void Coerce_WatermarkForeground (Brush value, ref Brush coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public bool IsWatermarkVisible
        {
            get
            {
                return (bool)GetValue (IsWatermarkVisibleProperty);
            }
            private set
            {
                if (IsWatermarkVisible != value)
                {
                    SetValue (IsWatermarkVisiblePropertyKey, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_IsWatermarkVisible (bool oldValue, bool newValue);
        partial void Coerce_IsWatermarkVisible (bool value, ref bool coercedValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}
                                   
