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

// ### INCLUDE: DebugContainerControl.cs
// ### INCLUDE: ../../Extensions/WpfExtensions.cs

// ReSharper disable InconsistentNaming


namespace Source.WPF.Debug
{
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;

    [TemplatePart (Name = PART_SelectButton     , Type = typeof (ButtonBase))   ]
    [TemplatePart (Name = PART_RefreshButton    , Type = typeof (ButtonBase))   ]
    [TemplatePart (Name = PART_SearchBox        , Type = typeof (TextBoxBase))  ]
    [TemplatePart (Name = PART_VisualTreeView   , Type = typeof (TreeView))     ]
    [TemplatePart (Name = PART_NodeListView     , Type = typeof (ListView))     ]
    partial class DebugVisualTreeControl : DebugControl
    {
        public const string PART_SelectButton   = @"PART_SelectButton"  ;
        public const string PART_RefreshButton  = @"PART_RefreshButton" ;
        public const string PART_SearchBox      = @"PART_SearchBox"     ;
        public const string PART_VisualTreeView = @"PART_VisualTreeView";
        public const string PART_NodeListView   = @"PART_NodeListView"  ;

        public const string DefaultStyle = @"
<Style 
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    TargetType=""{x:Type d:DebugVisualTreeControl}""
    >
    <Setter Property=""Template"">
        <Setter.Value>
            <ControlTemplate TargetType=""{x:Type d:DebugVisualTreeControl}"">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height=""24""/>
                        <RowDefinition Height=""4""/>
                        <RowDefinition Height=""*""/>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width=""*""/>
                        <ColumnDefinition Width=""4""/>
                        <ColumnDefinition Width=""*""/>
                    </Grid.ColumnDefinitions>
                    <StackPanel Grid.Row=""0"" Grid.Column=""0"" Orientation=""Horizontal"">
                        <Button x:Name=""PART_SelectButton""    Padding=""8,0,8,0"" Margin=""0,0,4,0"" Content=""Select""/>
                        <Button x:Name=""PART_RefreshButton""   Padding=""8,0,8,0"" Margin=""0,0,4,0"" Content=""Refresh""/>
                    </StackPanel>
                    <TextBox    Grid.Row=""0"" Grid.Column=""2"" x:Name=""PART_SearchBox""      />
                    <TreeView   Grid.Row=""2"" Grid.Column=""0"" x:Name=""PART_VisualTreeView"" />
                    <ListView   Grid.Row=""2"" Grid.Column=""2"" x:Name=""PART_NodeListView""   />
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
";
    
        readonly static Style           s_defaultStyle      ;

        static DebugVisualTreeControl ()
        {
            var parserContext = DebugContainerControl.GetParserContext();

            s_defaultStyle = (Style)XamlReader.Parse(
                DefaultStyle,
                parserContext
                );            

            StyleProperty.OverrideMetadata(typeof(DebugVisualTreeControl), new FrameworkPropertyMetadata(s_defaultStyle));
        }

        public DebugVisualTreeControl ()
        {
            RoutedEventHandler buttonClick = Button_Click;
            AddHandler (ButtonBase.ClickEvent, buttonClick);
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = e.Source as ButtonBase;
            if (button == null)
            {
                return;
            }

            switch (button.Name ?? "")
            {
                case PART_SelectButton:
                    break;
                case PART_RefreshButton:
                    break;
                default:
                    break;
            }
        }

        protected override string OnGetFriendlyName()
        {
            return "Visual Tree";
        }

        protected override void OnAttachTo(DependencyObject dependencyObject)
        {
        }

        protected override void OnDetachFrom(DependencyObject dependencyObject)
        {
        }
    }
}
