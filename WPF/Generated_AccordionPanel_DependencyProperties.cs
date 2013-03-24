
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
    // AccordionPanel
    // ------------------------------------------------------------------------
    partial class AccordionPanel
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty PreviewWidthProperty = DependencyProperty.Register (
            "PreviewWidth",
            typeof (double),
            typeof (AccordionPanel),
            new FrameworkPropertyMetadata (
                32.0,
                FrameworkPropertyMetadataOptions.None,
                Changed_PreviewWidth,
                Coerce_PreviewWidth          
            ));

        static void Changed_PreviewWidth (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as AccordionPanel;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_PreviewWidth (oldValue, newValue);
            }
        }


        static object Coerce_PreviewWidth (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as AccordionPanel;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_PreviewWidth (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty ActiveElementProperty = DependencyProperty.Register (
            "ActiveElement",
            typeof (UIElement),
            typeof (AccordionPanel),
            new FrameworkPropertyMetadata (
                default (UIElement),
                FrameworkPropertyMetadataOptions.None,
                Changed_ActiveElement,
                Coerce_ActiveElement          
            ));

        static void Changed_ActiveElement (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as AccordionPanel;
            if (instance != null)
            {
                var oldValue = (UIElement)eventArgs.OldValue;
                var newValue = (UIElement)eventArgs.NewValue;

                instance.Changed_ActiveElement (oldValue, newValue);
            }
        }


        static object Coerce_ActiveElement (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as AccordionPanel;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (UIElement)basevalue;
            var newValue = oldValue;

            instance.Coerce_ActiveElement (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty ChildStateProperty = DependencyProperty.RegisterAttached (
            "ChildState",
            typeof (AccordionPanel.State),
            typeof (AccordionPanel),
            new FrameworkPropertyMetadata (
                default (AccordionPanel.State),
                FrameworkPropertyMetadataOptions.None,
                Changed_ChildState,
                Coerce_ChildState          
            ));

        static void Changed_ChildState (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject != null)
            {
                var oldValue = (AccordionPanel.State)eventArgs.OldValue;
                var newValue = (AccordionPanel.State)eventArgs.NewValue;

                Changed_ChildState (dependencyObject, oldValue, newValue);
            }
        }

        static object Coerce_ChildState (DependencyObject dependencyObject, object basevalue)
        {
            if (dependencyObject == null)
            {
                return basevalue;
            }
            var oldValue = (AccordionPanel.State)basevalue;
            var newValue = oldValue;

            Coerce_ChildState (dependencyObject, oldValue, ref newValue);

            return newValue;
        }
        public static readonly DependencyProperty AnimationClockProperty = DependencyProperty.RegisterAttached (
            "AnimationClock",
            typeof (double),
            typeof (AccordionPanel),
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
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            Coerce_AnimationClock (dependencyObject, oldValue, ref newValue);

            return newValue;
        }
        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public AccordionPanel ()
        {
            CoerceAllProperties ();
            Constructed__AccordionPanel ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__AccordionPanel ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (PreviewWidthProperty);
            CoerceValue (ActiveElementProperty);
            CoerceValue (ChildStateProperty);
            CoerceValue (AnimationClockProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public double PreviewWidth
        {
            get
            {
                return (double)GetValue (PreviewWidthProperty);
            }
            set
            {
                if (PreviewWidth != value)
                {
                    SetValue (PreviewWidthProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_PreviewWidth (double oldValue, double newValue);
        partial void Coerce_PreviewWidth (double value, ref double coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public UIElement ActiveElement
        {
            get
            {
                return (UIElement)GetValue (ActiveElementProperty);
            }
            set
            {
                if (ActiveElement != value)
                {
                    SetValue (ActiveElementProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_ActiveElement (UIElement oldValue, UIElement newValue);
        partial void Coerce_ActiveElement (UIElement value, ref UIElement coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public static AccordionPanel.State GetChildState (DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
            {
                return default (AccordionPanel.State);
            }

            return (AccordionPanel.State)dependencyObject.GetValue (ChildStateProperty);
        }

        public static void SetChildState (DependencyObject dependencyObject, AccordionPanel.State value)
        {
            if (dependencyObject != null)
            {
                if (GetChildState (dependencyObject) != value)
                {
                    dependencyObject.SetValue (ChildStateProperty, value);
                }
            }
        }

        public static void ClearChildState (DependencyObject dependencyObject)
        {
            if (dependencyObject != null)
            {
                dependencyObject.ClearValue (ChildStateProperty);
            }
        }
        // --------------------------------------------------------------------
        static partial void Changed_ChildState (DependencyObject dependencyObject, AccordionPanel.State oldValue, AccordionPanel.State newValue);
        static partial void Coerce_ChildState (DependencyObject dependencyObject, AccordionPanel.State value, ref AccordionPanel.State coercedValue);
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
        static partial void Coerce_AnimationClock (DependencyObject dependencyObject, double value, ref double coercedValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}
                                   
