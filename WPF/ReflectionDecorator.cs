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

// ReSharper disable InconsistentNaming

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
        LinearGradientBrush m_opacityMask;
        MatrixTransform m_transform;

        partial void Constructed__ReflectionDecorator()
        {
            m_opacityMask   = new LinearGradientBrush (
                new GradientStopCollection
                    {
                        new GradientStop (Colors.Transparent                , 0     ),    
                        new GradientStop ("#2000".ParseColor(Colors.Black)  , 0.25  ),    
                        new GradientStop ("#4000".ParseColor(Colors.Black)  , 0.50  ),    
                        new GradientStop ("#8000".ParseColor(Colors.Black)  , 0.75  ),    
                        new GradientStop (Colors.Black                      , 1     ),    
                    },
                90
                ).FreezeObject ();    

            m_transform = new MatrixTransform ();

            VerticalAlignment = VerticalAlignment.Center;       
            HorizontalAlignment = HorizontalAlignment.Center;
        }

        public override UIElement Child
        {
            get
            {
                return base.Child;
            }
            set
            {
                base.Child = value;
                if (value == null)
                {
                    m_brush = null;
                }
                else if (m_brush == null || !ReferenceEquals (m_brush.Visual, value))
                {
                    m_brush = new VisualBrush (value)
                                    {
                                        Stretch           = Stretch.None      ,
                                        AlignmentY        = AlignmentY.Bottom , 
                                        AutoLayoutContent = false             , 
                                        TileMode          = TileMode.None     ,
                                    }.FreezeObject ();
                }
            }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            var fullReflectionSize = FullReflectionSize;
            var adjustedSize = new Size (
                constraint.Width, 
                (constraint.Height - fullReflectionSize).LimitBy(constraint.Height)
                );
            var measuredSize = base.MeasureOverride (adjustedSize);

            var result = new Size(measuredSize.Width, measuredSize.Height + fullReflectionSize).LimitBy(constraint);

            return result;
        }

        double FullReflectionSize
        {
            get
            {
                return ReflectionSeparation + ReflectionSize;
            }
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var fullReflectionSize = FullReflectionSize;
            var adjustedSize = new Size (
                arrangeSize.Width, 
                (arrangeSize.Height - fullReflectionSize).LimitBy(arrangeSize.Height)
                );

                var finalSize = base.ArrangeOverride (adjustedSize);

            var result = new Size(finalSize.Width, finalSize.Height + fullReflectionSize).LimitBy(arrangeSize);

            return result;
        }

        partial void Coerce_ReflectionSeparation(ref double coercedValue)
        {
            coercedValue = Math.Max (0, coercedValue);
        }

        partial void Changed_ReflectionSeparation(double oldValue, double newValue)
        {
            InvalidateMeasure();
        }

        partial void Coerce_ReflectionSize(ref double coercedValue)
        {
            coercedValue = Math.Max (0, coercedValue);
        }

        partial void Changed_ReflectionSize(double oldValue, double newValue)
        {
            InvalidateMeasure();
        }


        protected override void OnRender(DrawingContext drawingContext)
        {
            var child = Child;
            if (child == null)
            {
                return;
            }

            if (m_brush == null)
            {
                return;
            }

            var renderSize = RenderSize;
            var childRenderSize = child.RenderSize;
            var reflectionSize = ReflectionSize;
            var reflectionSeparation = ReflectionSeparation;

            var matrix = Matrix.Identity;
            matrix.Scale(1,-1);
            matrix.Translate (0, childRenderSize.Height + reflectionSize + reflectionSeparation);

            m_transform.Matrix = matrix;

            drawingContext.PushTransform (m_transform);
            drawingContext.PushOpacityMask (m_opacityMask);

            var rectangle = new Rect(
                0, 
                0, 
                renderSize.Width, 
                reflectionSize
                );

            drawingContext.DrawRectangle (
                m_brush, 
                null, 
                rectangle
                );

            drawingContext.Pop();
            drawingContext.Pop();
        }
    }
}
