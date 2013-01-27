

// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################





// ReSharper disable InconsistentNaming
// ReSharper disable InvocationIsSkipped
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantUsingDirective

namespace Test_Functionality.T4
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    using System.Windows;
    using System.Windows.Media;

    // ------------------------------------------------------------------------
    // TestControl
    // ------------------------------------------------------------------------
    partial class TestControl
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty IsValidProperty = DependencyProperty.Register (
            "IsValid",
            typeof (bool),
            typeof (TestControl),
            new FrameworkPropertyMetadata (
                default (bool),
                FrameworkPropertyMetadataOptions.None,
                Changed_IsValid,
                Coerce_IsValid          
            ));

        static void Changed_IsValid (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as TestControl;
            if (instance != null)
            {
                var oldValue = (bool)eventArgs.OldValue;
                var newValue = (bool)eventArgs.NewValue;

                instance.Changed_IsValid (oldValue, newValue);
            }
        }


        static object Coerce_IsValid (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as TestControl;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (bool)basevalue;
            var newValue = oldValue;

            instance.Coerce_IsValid (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty AdditionalProperty = DependencyProperty.RegisterAttached (
            "Additional",
            typeof (string),
            typeof (TestControl),
            new FrameworkPropertyMetadata (
                default (string),
                FrameworkPropertyMetadataOptions.None,
                Changed_Additional,
                Coerce_Additional          
            ));

        static void Changed_Additional (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject != null)
            {
                var oldValue = (string)eventArgs.OldValue;
                var newValue = (string)eventArgs.NewValue;

                Changed_Additional (dependencyObject, oldValue, newValue);
            }
        }

        static object Coerce_Additional (DependencyObject dependencyObject, object basevalue)
        {
            if (dependencyObject == null)
            {
                return basevalue;
            }
            var oldValue = (string)basevalue;
            var newValue = oldValue;

            Coerce_Additional (dependencyObject, oldValue, ref newValue);

            return newValue;
        }
        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public TestControl ()
        {
            CoerceAllProperties ();
            Constructed__TestControl ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__TestControl ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (IsValidProperty);
            CoerceValue (AdditionalProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public bool IsValid
        {
            get
            {
                return (bool)GetValue (IsValidProperty);
            }
            set
            {
                if (IsValid != value)
                {
                    SetValue (IsValidProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_IsValid (bool value, ref bool coercedValue);
        partial void Changed_IsValid (bool oldValue, bool newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public static string GetAdditional (DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
            {
                return default (string);
            }

            return (string)dependencyObject.GetValue (AdditionalProperty);
        }

        public static void SetAdditional (DependencyObject dependencyObject, string value)
        {
            if (dependencyObject != null)
            {
                if (GetAdditional (dependencyObject) != value)
                {
                    dependencyObject.SetValue (AdditionalProperty, value);
                }
            }
        }

        public static void ClearAdditional (DependencyObject dependencyObject)
        {
            if (dependencyObject != null)
            {
                dependencyObject.ClearValue (AdditionalProperty);
            }
        }
        // --------------------------------------------------------------------
        static partial void Coerce_Additional (DependencyObject dependencyObject, string value, ref string coercedValue);
        static partial void Changed_Additional (DependencyObject dependencyObject, string oldValue, string newValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}



