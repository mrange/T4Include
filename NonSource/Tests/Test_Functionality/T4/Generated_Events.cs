// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################





// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier

namespace Test_Functionality.T4
{
    using System.Windows;


    // -------------------------------------------------------------------------

    partial class DoActivateEventArgs : RoutedEventArgs
    {
        public delegate void Handler (object sender, DoActivateEventArgs eventArgs);
    }
    // -------------------------------------------------------------------------


    partial class TestControl
    {
        // ----------------------------------------------------------------------
        public readonly static RoutedEvent DoActivateEvent = EventManager.RegisterRoutedEvent (
            "DoActivate",
            RoutingStrategy.Bubble,
            typeof (DoActivateEventArgs.Handler),
            typeof (TestControl)
            );
        public event DoActivateEventArgs.Handler DoActivate
        {
            add { this.AddHandler_DoActivate (value); }
            remove { this.RemoveHandler_DoActivate (value); }
        }
        // ----------------------------------------------------------------------


    }

    static partial class RoutedEventExtensions
    {
        public static void Raise_DoActivate (
            this UIElement uiElement, 
            DoActivateEventArgs routedEventArgs = null
            )
        {
            if (uiElement != null)
            {
                routedEventArgs = routedEventArgs ?? new DoActivateEventArgs ();
                routedEventArgs.RoutedEvent = TestControl.DoActivateEvent;
                uiElement.RaiseEvent (routedEventArgs);
            }
        }

        public static void AddHandler_DoActivate (
            this UIElement uiElement,
            DoActivateEventArgs.Handler eventHandler,
            bool handledEventsToo = false
            )
        {
            if (uiElement != null)
            {
                uiElement.AddHandler (TestControl.DoActivateEvent, eventHandler, handledEventsToo);
            }
        }

        public static void RemoveHandler_DoActivate (
            this UIElement uiElement,
            DoActivateEventArgs.Handler eventHandler
            )
        {
            if (uiElement != null)
            {
                uiElement.RemoveHandler (TestControl.DoActivateEvent, eventHandler);
            }
        }
    }


    // -------------------------------------------------------------------------

    partial class OtherEventEventArgs : RoutedEventArgs
    {
        public delegate void Handler (object sender, OtherEventEventArgs eventArgs);
    }
    // -------------------------------------------------------------------------


    partial class OtherTest
    {
        // ----------------------------------------------------------------------
        public readonly static RoutedEvent OtherEventEvent = EventManager.RegisterRoutedEvent (
            "OtherEvent",
            RoutingStrategy.Bubble,
            typeof (OtherEventEventArgs.Handler),
            typeof (OtherTest)
            );
        // ----------------------------------------------------------------------


    }

    static partial class RoutedEventExtensions
    {
        public static void Raise_OtherEvent (
            this UIElement uiElement, 
            OtherEventEventArgs routedEventArgs = null
            )
        {
            if (uiElement != null)
            {
                routedEventArgs = routedEventArgs ?? new OtherEventEventArgs ();
                routedEventArgs.RoutedEvent = OtherTest.OtherEventEvent;
                uiElement.RaiseEvent (routedEventArgs);
            }
        }

        public static void AddHandler_OtherEvent (
            this UIElement uiElement,
            OtherEventEventArgs.Handler eventHandler,
            bool handledEventsToo = false
            )
        {
            if (uiElement != null)
            {
                uiElement.AddHandler (OtherTest.OtherEventEvent, eventHandler, handledEventsToo);
            }
        }

        public static void RemoveHandler_OtherEvent (
            this UIElement uiElement,
            OtherEventEventArgs.Handler eventHandler
            )
        {
            if (uiElement != null)
            {
                uiElement.RemoveHandler (OtherTest.OtherEventEvent, eventHandler);
            }
        }
    }

}

