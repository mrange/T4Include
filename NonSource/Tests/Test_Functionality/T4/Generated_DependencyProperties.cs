

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
                null          
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


        public static readonly DependencyProperty AdditionalProperty = DependencyProperty.RegisterAttached (
            "Additional",
            typeof (string),
            typeof (TestControl),
            new FrameworkPropertyMetadata (
                default (string),
                FrameworkPropertyMetadataOptions.None,
                null,
                null          
            ));

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
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}



