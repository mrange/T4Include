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
using System.Diagnostics;
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

            Loaded += Loaded_MainWindow;

            Cnt.IsHitTestVisible = false;
            Cnt.Opacity = 0;
        }

        void Loaded_MainWindow(object sender, RoutedEventArgs e)
        {
            m_bitmapSources = this
                .GetLogicalTree_BreadthFirst ()
                .OfType<Image> ()
                .Select (i => i.Source)
                .OfType<BitmapSource> ()
                .Where (bs => bs.IsDownloading)
                .ToArray ();


            foreach (var bitmapSource in m_bitmapSources)
            {
                bitmapSource.DownloadCompleted  += bitmapSource_DownloadCompleted;
                bitmapSource.DownloadFailed     += bitmapSource_DownloadFailed;
            }

            DebugContainerControl.ShowWindow (this, "Test_WPF: Debug view");
        }

        void bitmapSource_DownloadCompleted(object sender, EventArgs e)
        {
            ShowContent();
        }

        void ShowContent()
        {
            if (!m_bitmapSources.Any(bs => bs.IsDownloading))
            {
                Cnt.IsHitTestVisible = true;
                m_clock = m_opacityAnimation.CreateClock ();
                m_clock.Completed += clock_Completed;
                Cnt.ApplyAnimationClock(OpacityProperty, m_clock);
            }
        }

        void clock_Completed(object sender, EventArgs e)
        {
            m_clock.Completed -= clock_Completed;
            Cnt.ApplyAnimationClock(OpacityProperty, null);
            Cnt.Opacity = 1;
        }

        void bitmapSource_DownloadFailed(object sender, System.Windows.Media.ExceptionEventArgs e)
        {
            ShowContent();
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
                case "Fifth":
                    AE.Present(AnimatedEntrance.Option.Instant, Fifth);
                    break;
                default:
                    break;
            }

        }
    }
}
