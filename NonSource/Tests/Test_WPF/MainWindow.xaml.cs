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

using System.Windows;
using System.Windows.Controls.Primitives;
using FileInclude.Source.WPF;

namespace Test_WPF
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = e.OriginalSource as ButtonBase;
            if (button == null)
            {
                return;
            }

            var tag = button.Tag as string;
            switch(tag)
            {
                case "First":
                    AE.Present(AnimatedEntrance.Option.PushFromLeft, First);
                    break;
                case "Second":
                    AE.Present(AnimatedEntrance.Option.RevealToRight, Second);
                    break;
                case "Third":
                    AE.Present(AnimatedEntrance.Option.CoverFromBottom, Third);
                    break;
                case "Fourth":
                    AE.Present(AnimatedEntrance.Option.Fade, Fourth);
                    break;
                default:
                    break;
            }

        }
    }
}
