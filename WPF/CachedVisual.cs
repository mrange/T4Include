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

// ### INCLUDE: Generated_CachedVisual_DependencyProperties.cs

namespace Source.WPF
{
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    using Source.Extensions;

    partial class CachedVisual : FrameworkElement, IAddChild
    {
        Size?           m_cachedSize    ;
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
                return (!IsCaching && Child != null) ? 1 : 0;
            }
        }

        protected override Visual GetVisualChild(int index)
        {
            return (!IsCaching && index == 0) ? Child : null;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var child = Child;
            if (child == null)
            {
                return base.MeasureOverride(availableSize);
            }

            if (IsCaching)
            {
                if (m_cachedSize == null)
                {
                    child.Measure(availableSize);
                    return child.DesiredSize;
                }
                return m_cachedSize.Value.ScaleToFit (availableSize);
            }
            else
            {
                child.Measure(availableSize);
                return child.DesiredSize;
            }

        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var child = Child;
            if (child == null)
            {
                return base.ArrangeOverride(finalSize);
            }

            if (IsCaching)
            {
                if (m_cachedImage == null)
                {
                    m_cachedImage = GetImage (finalSize, child);
                }
                m_cachedSize = child.RenderSize;
                return m_cachedSize.Value;
            }
            else
            {
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

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (IsCaching && m_cachedSize != null)
            {
                drawingContext.DrawImage(
                    m_cachedImage, 
                    m_cachedSize.Value.ToRect()
                    );
                
            }
        }

        partial void Changed_Child(UIElement oldValue, UIElement newValue)
        {
            Invalidate ();
        }

        partial void Changed_IsCaching(bool oldValue, bool newValue)
        {
            Invalidate ();
        }

        void Invalidate()
        {
            m_cachedSize    = null;
            m_cachedImage   = null;
            InvalidateMeasure();
        }
    }
}
