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

using Source.Extensions;

namespace Source.WPF
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;


    partial class AccordionPanel : Panel
    {
        public sealed partial class State
        {
            public double               From        ;
            public double               To          ;
            public TranslateTransform   Transform   ;            
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var count = Children.Count; 
            if (count == 0)
            {
                return availableSize;
            }

            var adjustedSize = new Size (
                availableSize.Width - (count - 1) * PreviewWidth, 
                availableSize.Height
                );

            for (int index = 0; index < count; index++)
            {
                var child = Children[index];
                child.Measure(adjustedSize);
            }

            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var count = Children.Count; 
            if (count == 0)
            {
                return finalSize;
            }

            var adjustedSize = new Size (
                finalSize.Width - (count - 1) * PreviewWidth, 
                finalSize.Height
                );
            var adjustedRect = adjustedSize.ToRect();

            var activeElement = ActiveElement;

            for (int index = 0; index < count; index++)
            {
                var child = Children[index];

                var state = GetChildState(child);
                if (state == null)
                {
                    state = new State
                                {
                                    Transform    = new TranslateTransform(),
                                };
                    SetChildState (child, state);
                }

                child.Arrange(adjustedRect);



            }

            return finalSize;
        }
    }
}
