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
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using FileInclude.Source.Extensions;
using FileInclude.Source.WPF;
using FileInclude.Source.WPF.Debug;

namespace Test_WPF
{
    public partial class MainWindow
    {
        BitmapSource[] m_bitmapSources;
        readonly DoubleAnimation m_opacityAnimation = new DoubleAnimation
                                                 {
                                                     To         = 1,
                                                     From       = 0,
                                                     Duration   = new Duration (TimeSpan.FromSeconds(1)),
                                                     FillBehavior = FillBehavior.Stop
                                                 }.FreezeObject ()
                                                 ;

        AnimationClock m_clock;

        public MainWindow()
        {
            InitializeComponent();

            Buzy.IsWaiting = true;
        }
    }
}
