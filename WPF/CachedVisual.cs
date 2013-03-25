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

using System;
using System.Windows.Media.Imaging;

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

        Size?           m_cachedSize    ;
        Drawing         m_cachedDrawing ;
        ImageSource     m_cachedImage   ;

        public void AddChild(object value)
        {
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

            switch (CacheStrategy)
            {
                case Strategy.Drawing:
                case Strategy.Bitmap:
                    if (m_cachedSize == null)
                    {
                        child.Measure(availableSize);
                        return child.DesiredSize;
                    }
                    return m_cachedSize.Value.ScaleToFit (availableSize);
                case Strategy.None:
                default:
                    child.Measure(availableSize);
                    return child.DesiredSize;
            }

        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var child = Child;
            if (child == null)
            {
                return base.MeasureOverride(finalSize);
            }

            switch (CacheStrategy)
            {
                case Strategy.Drawing:
                    if (m_cachedDrawing == null)
                    {
                        m_cachedDrawing = GetDrawing(finalSize, child);
                    }
                    m_cachedSize = child.RenderSize;
                    return m_cachedSize.Value;
                case Strategy.Bitmap:
                    if (m_cachedImage == null)
                    {
                        m_cachedImage = GetImage (finalSize, child);
                    }
                    m_cachedSize = child.RenderSize;
                    return m_cachedSize.Value;
                default:
                case Strategy.None:
                    child.Arrange(finalSize.ToRect());
                    return child.RenderSize;
            }

        }

        ImageSource GetImage(Size finalSize, UIElement child)
        {
            var renderTargetBitmap = new RenderTargetBitmap (
                (int) finalSize.Width, 
                (int) finalSize.Height,
                0,
                0,
                PixelFormats.Default
                );

            renderTargetBitmap.Render (child);

            renderTargetBitmap.Freeze ();

            return renderTargetBitmap;
        }

        static Drawing GetDrawing(Size finalSize, UIElement child)
        {
            child.Arrange(finalSize.ToRect());
            var drawingVisual = new VisualDrawing();
            using (var dc = drawingVisual.RenderOpen())
            {
                                                      child.Rend
            }
            var drawing = drawingVisual.Drawing;
            drawing.Freeze();
            return drawing;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            switch (CacheStrategy)
            {
                case Strategy.Drawing:
                    drawingContext.DrawDrawing(m_cachedDrawing);
                    break;
                case Strategy.Bitmap:
                    drawingContext.DrawImage(
                        m_cachedImage, 
                        (m_cachedSize ?? new Size()).ToRect()
                        );
                    break;
                default:
                case Strategy.None:
                    break;
            }
        }

        partial void Changed_Child(UIElement oldValue, UIElement newValue)
        {
            Invalidate ();
        }

        partial void Changed_CacheStrategy(CachedVisual.Strategy oldValue, CachedVisual.Strategy newValue)
        {
            Invalidate();
        }

        void Invalidate()
        {
            m_cachedSize    = null;
            m_cachedDrawing = null;
            m_cachedImage   = null;
            InvalidateMeasure();
        }
    }
}
