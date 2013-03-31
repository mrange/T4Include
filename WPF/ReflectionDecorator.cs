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


// ### INCLUDE: Generated_ReflectionDecorator_DependencyProperties.cs

namespace Source.WPF
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    using Source.Extensions;

    partial class ReflectionDecorator : Decorator
    {
        VisualBrush m_brush;

        partial void Constructed__ReflectionDecorator()
        {
            m_brush = new VisualBrush
        }

        protected override Size MeasureOverride(Size constraint)
        {
            var reflectionHeight = ReflectionHeight;
            var adjustedSize = new Size (
                constraint.Width, 
                (constraint.Height - reflectionHeight).LimitBy(constraint.Height)
                );
            var measuredSize = base.MeasureOverride (adjustedSize);

            return new Size (measuredSize.Width, measuredSize.Height + reflectionHeight).LimitBy (constraint);
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var reflectionHeight = ReflectionHeight;
            var adjustedSize = new Size (
                arrangeSize.Width, 
                (arrangeSize.Height - reflectionHeight).LimitBy(arrangeSize.Height)
                );

                var finalSize = base.ArrangeOverride (adjustedSize);
    
                return new Size (finalSize.Width, finalSize.Height + reflectionHeight).LimitBy (arrangeSize);
        }

        partial void Coerce_ReflectionHeight(ref double coercedValue)
        {
            coercedValue = Math.Max (0, coercedValue);
        }
        partial void Changed_ReflectionHeight(double oldValue, double newValue)
        {
            InvalidateMeasure();
        }


        protected override void OnRender(DrawingContext drawingContext)
        {
            var renderSize = RenderSize;

            var reflectionHeight = ReflectionHeight;

            var child = Child;

            if (!ReferenceEquals(m_brush.Visual, child))
            {
                m_brush.Visual = child;    
            }

            var rectangle = new Rect(
                0, 
                (renderSize.Height - reflectionHeight).LimitBy(renderSize.Height), 
                renderSize.Width, 
                reflectionHeight
                );

            drawingContext.DrawRectangle (
                m_brush, 
                null, 
                rectangle
                );
        }
    }
}
