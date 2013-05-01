
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
    // BuzyWait
    // ------------------------------------------------------------------------
    partial class BuzyWait
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty AnimationClockProperty = DependencyProperty.RegisterAttached (
            "AnimationClock",
            typeof (double),
            typeof (BuzyWait),
            new FrameworkPropertyMetadata (
                default (double),
                FrameworkPropertyMetadataOptions.None,
                Changed_AnimationClock,
                Coerce_AnimationClock          
            ));

        static void Changed_AnimationClock (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                Changed_AnimationClock (dependencyObject, oldValue, newValue);
            }
        }

        static object Coerce_AnimationClock (DependencyObject dependencyObject, object basevalue)
        {
            if (dependencyObject == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            Coerce_AnimationClock (dependencyObject, ref value);

            return value;
        }
        public static readonly DependencyProperty IsWaitingProperty = DependencyProperty.Register (
            "IsWaiting",
            typeof (bool),
            typeof (BuzyWait),
            new FrameworkPropertyMetadata (
                default (bool),
                FrameworkPropertyMetadataOptions.None,
                Changed_IsWaiting,
                Coerce_IsWaiting          
            ));

        static void Changed_IsWaiting (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as BuzyWait;
            if (instance != null)
            {
                var oldValue = (bool)eventArgs.OldValue;
                var newValue = (bool)eventArgs.NewValue;

                instance.Changed_IsWaiting (oldValue, newValue);
            }
        }


        static object Coerce_IsWaiting (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as BuzyWait;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (bool)basevalue;

            instance.Coerce_IsWaiting (ref value);


            return value;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public BuzyWait ()
        {
            CoerceAllProperties ();
            Constructed__BuzyWait ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__BuzyWait ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (AnimationClockProperty);
            CoerceValue (IsWaitingProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public static double GetAnimationClock (DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
            {
                return default (double);
            }

            return (double)dependencyObject.GetValue (AnimationClockProperty);
        }

        public static void SetAnimationClock (DependencyObject dependencyObject, double value)
        {
            if (dependencyObject != null)
            {
                if (GetAnimationClock (dependencyObject) != value)
                {
                    dependencyObject.SetValue (AnimationClockProperty, value);
                }
            }
        }

        public static void ClearAnimationClock (DependencyObject dependencyObject)
        {
            if (dependencyObject != null)
            {
                dependencyObject.ClearValue (AnimationClockProperty);
            }
        }
        // --------------------------------------------------------------------
        static partial void Changed_AnimationClock (DependencyObject dependencyObject, double oldValue, double newValue);
        static partial void Coerce_AnimationClock (DependencyObject dependencyObject, ref double coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public bool IsWaiting
        {
            get
            {
                return (bool)GetValue (IsWaitingProperty);
            }
            set
            {
                if (IsWaiting != value)
                {
                    SetValue (IsWaitingProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_IsWaiting (bool oldValue, bool newValue);
        partial void Coerce_IsWaiting (ref bool coercedValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}
                                   
