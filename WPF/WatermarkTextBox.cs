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


// ### INCLUDE: Generated_WatermarkTextBox_DependencyProperties.cs

namespace Source.WPF
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    partial class WatermarkTextBox : TextBox
    {
        const string DefaultStyle = @"
<Style 
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    TargetType=""{x:Type i:WatermarkTextBox}"">
    <Setter Property=""FocusVisualStyle"" Value=""{x:Null}""/>
    <Setter Property=""Foreground"" Value=""#000""/>
    <Setter Property=""BorderBrush"" Value=""#888""/>
    <Setter Property=""WatermarkForeground"" Value=""#888""/>
    <Setter Property=""WatermarkText"" Value=""Enter some text...""/>
    <Setter Property=""BorderThickness"" Value=""1""/>
    <Setter Property=""SnapsToDevicePixels"" Value=""true""/>
    <Setter Property=""Template"">
        <Setter.Value>
            <ControlTemplate TargetType=""{x:Type i:WatermarkTextBox}"">
                <Grid>
                    <Border x:Name=""Border""
                        Background=""{TemplateBinding Background}""
                        BorderBrush=""{TemplateBinding BorderBrush}""
                        BorderThickness=""{TemplateBinding BorderThickness}""
                        Padding=""2""
                        CornerRadius=""2""
                        >
    
                        <Grid>
                            <!-- The implementation places the Content into the ScrollViewer. It must be named PART_ContentHost for the control to function -->
                            <ScrollViewer
                                Margin=""0""
                                x:Name=""PART_ContentHost""
                                SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}""
                            />
                            <TextBlock
                                Margin=""4,0,0,0""
                                VerticalAlignment=""Top""
                                x:Name=""Watermark""
                                Foreground=""{TemplateBinding WatermarkForeground}""
                                FontStyle=""Italic""
                                Text=""{TemplateBinding WatermarkText}""
                                SnapsToDevicePixels=""{TemplateBinding SnapsToDevicePixels}""
                                />
                        </Grid>
                    </Border>
                </Grid>
                <ControlTemplate.Triggers>
                    <Trigger Property=""IsEnabled"" Value=""False"">
                        <Setter Property=""Opacity"" Value=""0.67""/>
                    </Trigger>
                    <Trigger Property=""IsFocused"" Value=""true"">
                        <Setter TargetName=""Border"" Property=""BorderBrush"" Value=""#FF9000""/>
                        <Setter TargetName=""Border"" Property=""BorderThickness"" Value=""2""/>
                        <Setter TargetName=""Border"" Property=""Margin"" Value=""-1""/>
                    </Trigger>
                    <Trigger Property=""IsWatermarkVisible"" Value=""False"">
                        <Setter Property=""Visibility"" Value=""Collapsed"" TargetName=""Watermark""/>
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
";

        static readonly Style s_defaultStyle;
        
        static WatermarkTextBox ()
        {
            var parserContext = new ParserContext
                            {
                                XamlTypeMapper = new XamlTypeMapper(new string[0])
                            };
        
            var type = typeof (WatermarkTextBox);
            var namespaceName = type.Namespace ?? "";
            var assemblyName = type.Assembly.FullName;
            parserContext.XamlTypeMapper.AddMappingProcessingInstruction("Internal", namespaceName, assemblyName);
            parserContext.XmlnsDictionary.Add("i", "Internal");
    
            s_defaultStyle = (Style)XamlReader.Parse(
                DefaultStyle,
                parserContext
                );
            
            StyleProperty.OverrideMetadata(typeof(WatermarkTextBox), new FrameworkPropertyMetadata(s_defaultStyle));
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            IsWatermarkVisible = string.IsNullOrEmpty (Text);
        }
    }
}
