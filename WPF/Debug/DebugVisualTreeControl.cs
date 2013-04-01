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

using System.Windows.Markup;

namespace Source.WPF.Debug
{
    using System.Windows;

    partial class DebugVisualTreeControl : DebugControl
    {
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
                        <Button Padding=""8,0,8,0"" Margin=""0,0,4,0"" Content=""Select""/>
                        <Button Padding=""8,0,8,0"" Margin=""0,0,4,0"" Content=""Refresh""/>
                    </StackPanel>
                    <TextBox    Grid.Row=""0"" Grid.Column=""2""/>
                    <TreeView   Grid.Row=""2"" Grid.Column=""0""/>
                    <ListView   Grid.Row=""2"" Grid.Column=""2""/>
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

        public override string GetFriendlyName()
        {
            return "Visual Tree";
        }

        public override void AttachTo(DependencyObject dependencyObject)
        {
        }

        public override void DetachFrom(DependencyObject dependencyObject)
        {
        }
    }
}
