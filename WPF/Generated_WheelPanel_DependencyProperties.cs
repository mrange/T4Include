
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
    // WheelPanel
    // ------------------------------------------------------------------------
    partial class WheelPanel
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty FromAngleProperty = DependencyProperty.Register (
            "FromAngle",
            typeof (double),
            typeof (WheelPanel),
            new FrameworkPropertyMetadata (
                180.0,
                FrameworkPropertyMetadataOptions.None,
                Changed_FromAngle,
                Coerce_FromAngle          
            ));

        static void Changed_FromAngle (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_FromAngle (oldValue, newValue);
            }
        }


        static object Coerce_FromAngle (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            instance.Coerce_FromAngle (ref value);


            return value;
        }

        public static readonly DependencyProperty ToAngleProperty = DependencyProperty.Register (
            "ToAngle",
            typeof (double),
            typeof (WheelPanel),
            new FrameworkPropertyMetadata (
                0.0,
                FrameworkPropertyMetadataOptions.None,
                Changed_ToAngle,
                Coerce_ToAngle          
            ));

        static void Changed_ToAngle (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_ToAngle (oldValue, newValue);
            }
        }


        static object Coerce_ToAngle (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            instance.Coerce_ToAngle (ref value);


            return value;
        }

        public static readonly DependencyProperty StepAngleProperty = DependencyProperty.Register (
            "StepAngle",
            typeof (double),
            typeof (WheelPanel),
            new FrameworkPropertyMetadata (
                10.0,
                FrameworkPropertyMetadataOptions.None,
                Changed_StepAngle,
                Coerce_StepAngle          
            ));

        static void Changed_StepAngle (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_StepAngle (oldValue, newValue);
            }
        }


        static object Coerce_StepAngle (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            instance.Coerce_StepAngle (ref value);


            return value;
        }

        public static readonly DependencyProperty StepScaleProperty = DependencyProperty.Register (
            "StepScale",
            typeof (double),
            typeof (WheelPanel),
            new FrameworkPropertyMetadata (
                0.9,
                FrameworkPropertyMetadataOptions.None,
                Changed_StepScale,
                Coerce_StepScale          
            ));

        static void Changed_StepScale (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_StepScale (oldValue, newValue);
            }
        }


        static object Coerce_StepScale (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            instance.Coerce_StepScale (ref value);


            return value;
        }

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register (
            "Radius",
            typeof (double),
            typeof (WheelPanel),
            new FrameworkPropertyMetadata (
                0.25,
                FrameworkPropertyMetadataOptions.None,
                Changed_Radius,
                Coerce_Radius          
            ));

        static void Changed_Radius (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_Radius (oldValue, newValue);
            }
        }


        static object Coerce_Radius (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (double)basevalue;

            instance.Coerce_Radius (ref value);


            return value;
        }

        public static readonly DependencyProperty CentreProperty = DependencyProperty.Register (
            "Centre",
            typeof (Point),
            typeof (WheelPanel),
            new FrameworkPropertyMetadata (
                new Point (0.5,0.5),
                FrameworkPropertyMetadataOptions.None,
                Changed_Centre,
                Coerce_Centre          
            ));

        static void Changed_Centre (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance != null)
            {
                var oldValue = (Point)eventArgs.OldValue;
                var newValue = (Point)eventArgs.NewValue;

                instance.Changed_Centre (oldValue, newValue);
            }
        }


        static object Coerce_Centre (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as WheelPanel;
            if (instance == null)
            {
                return basevalue;
            }
            var value = (Point)basevalue;

            instance.Coerce_Centre (ref value);


            return value;
        }

        public static readonly DependencyProperty ChildStateProperty = DependencyProperty.RegisterAttached (
            "ChildState",
            typeof (State),
            typeof (WheelPanel),
            new FrameworkPropertyMetadata (
                default (State),
                FrameworkPropertyMetadataOptions.None,
                Changed_ChildState,
                Coerce_ChildState          
            ));

        static void Changed_ChildState (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject != null)
            {
                var oldValue = (State)eventArgs.OldValue;
                var newValue = (State)eventArgs.NewValue;

                Changed_ChildState (dependencyObject, oldValue, newValue);
            }
        }

        static object Coerce_ChildState (DependencyObject dependencyObject, object basevalue)
        {
            if (dependencyObject == null)
            {
                return basevalue;
            }
            var value = (State)basevalue;

            Coerce_ChildState (dependencyObject, ref value);

            return value;
        }
        public static readonly DependencyProperty AnimationClockProperty = DependencyProperty.RegisterAttached (
            "AnimationClock",
            typeof (double),
            typeof (WheelPanel),
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
        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public WheelPanel ()
        {
            CoerceAllProperties ();
            Constructed__WheelPanel ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__WheelPanel ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (FromAngleProperty);
            CoerceValue (ToAngleProperty);
            CoerceValue (StepAngleProperty);
            CoerceValue (StepScaleProperty);
            CoerceValue (RadiusProperty);
            CoerceValue (CentreProperty);
            CoerceValue (ChildStateProperty);
            CoerceValue (AnimationClockProperty);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public double FromAngle
        {
            get
            {
                return (double)GetValue (FromAngleProperty);
            }
            set
            {
                if (FromAngle != value)
                {
                    SetValue (FromAngleProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_FromAngle (double oldValue, double newValue);
        partial void Coerce_FromAngle (ref double coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double ToAngle
        {
            get
            {
                return (double)GetValue (ToAngleProperty);
            }
            set
            {
                if (ToAngle != value)
                {
                    SetValue (ToAngleProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_ToAngle (double oldValue, double newValue);
        partial void Coerce_ToAngle (ref double coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double StepAngle
        {
            get
            {
                return (double)GetValue (StepAngleProperty);
            }
            set
            {
                if (StepAngle != value)
                {
                    SetValue (StepAngleProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_StepAngle (double oldValue, double newValue);
        partial void Coerce_StepAngle (ref double coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double StepScale
        {
            get
            {
                return (double)GetValue (StepScaleProperty);
            }
            set
            {
                if (StepScale != value)
                {
                    SetValue (StepScaleProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_StepScale (double oldValue, double newValue);
        partial void Coerce_StepScale (ref double coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double Radius
        {
            get
            {
                return (double)GetValue (RadiusProperty);
            }
            set
            {
                if (Radius != value)
                {
                    SetValue (RadiusProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Radius (double oldValue, double newValue);
        partial void Coerce_Radius (ref double coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public Point Centre
        {
            get
            {
                return (Point)GetValue (CentreProperty);
            }
            set
            {
                if (Centre != value)
                {
                    SetValue (CentreProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Centre (Point oldValue, Point newValue);
        partial void Coerce_Centre (ref Point coercedValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public static State GetChildState (DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
            {
                return default (State);
            }

            return (State)dependencyObject.GetValue (ChildStateProperty);
        }

        public static void SetChildState (DependencyObject dependencyObject, State value)
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
        static partial void Changed_ChildState (DependencyObject dependencyObject, State oldValue, State newValue);
        static partial void Coerce_ChildState (DependencyObject dependencyObject, ref State coercedValue);
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


    }
    // ------------------------------------------------------------------------

}
                                   
