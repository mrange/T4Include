// ----------------------------------------------------------------------------------------------
// Copyright (c) Mårten Rånge.
// ----------------------------------------------------------------------------------------------
// This source code is subject to terms and conditions of the Microsoft Public License. A 
// copy of the license can be found in the License.html file at the root of this distribution. 
// If you cannot locate the  Microsoft Public License, please send an email to 
// dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
//  by the terms of the Microsoft Public License.
// ----------------------------------------------------------------------------------------------
// You must not remove this notice, or any other, from this software.
// ----------------------------------------------------------------------------------------------

namespace Source.WPF
{
    using Source.Extensions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Windows.Media;

    partial class CachedVisual : FrameworkElement, IAddChild
    {
        public enum Strategy
        {
            None    ,
            Drawing ,
            Bitmap  ,
        }

        public void AddChild(object value)
        {
            Decorator x;
            var uiElement = value as UIElement;
            if (uiElement != null)
            {
                Child = uiElement;
            }
        }

        public void AddText(string text)
        {
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return Child != null ? 1 : 0;
            }
        }
        protected override Visual GetVisualChild(int index)
        {
            return index == 0 ? Child : null;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var child = Child;
            if (child == null)
            {
                return base.MeasureOverride(availableSize);
            }

            child.Measure(availableSize);
            return child.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var child = Child;
            if (child == null)
            {
                return base.MeasureOverride(finalSize);
            }

            child.Arrange(finalSize.ToRect());
            return child.RenderSize;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
        }
    }
}
