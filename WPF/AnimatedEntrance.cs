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

// ### INCLUDE: Generated_AnimatedEntrance_DependencyProperties.cs
namespace Source.WPF
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;


    [TemplatePart(Name = PART_First , Type = typeof(Decorator))]
    [TemplatePart(Name = PART_Second, Type = typeof(Decorator))]
    [ContentProperty("Children")]
    sealed partial class AnimatedEntrance : Control
    {
        const string PART_First     = @"PART_First" ;
        const string PART_Second    = @"PART_Second";

        public enum Option
        {
            Fade            ,
            PushFromLeft    ,
            PushFromRight   ,
            PushFromTop     ,
            PushFromBottom  ,
            CoverFromLeft   ,
            CoverFromRight  ,
            CoverFromTop    ,
            CoverFromBottom ,
            RevealToLeft    ,
            RevealToRight   ,
            RevealToTop     , 
            RevealToBottom  ,
        }

        public const string DefaultStyle = @"<ResourceDictionary
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:i=""clr-namespace:Source.WPF"">
    <Style TargetType=""{x:Type i:AnimatedEntrance}"">
        <Setter Property=""Template"">
            <Setter.Value>
                <ControlTemplate TargetType=""{x:Type i:AnimatedEntrance}"">
                    <Border x:Name=""PART_First"" Visibility=""Collapsed""/>
                    <Border x:Name=""PART_Second"" Visibility=""Collapsed""/>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
</ResourceDictionary>
";

        readonly static Style s_defaultStyle;
        Decorator m_first;
        Decorator m_second;

        static AnimatedEntrance()
        {
            var parserContext = new ParserContext
                            {
                                XamlTypeMapper = new XamlTypeMapper(new string[0])
                            };
    
            var type = typeof (AnimatedEntrance);
            var namespaceName = type.Namespace;
            var assemblyName = type.Assembly.FullName;
            parserContext.XamlTypeMapper.AddMappingProcessingInstruction("Internal", namespaceName, assemblyName);
            parserContext.XmlnsDictionary.Add("i", "Internal");

            s_defaultStyle = (Style)XamlReader.Parse(
                DefaultStyle,
                parserContext
                );

            StyleProperty.OverrideMetadata(typeof(AnimatedEntrance), new FrameworkPropertyMetadata(s_defaultStyle));
        }

        partial void Constructed__AnimatedEntrance()
        {
            Children = new ObservableCollection<UIElement> ();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            m_first     = GetTemplateChild(PART_First) as Decorator;
            m_second    = GetTemplateChild(PART_First) as Decorator;
        }

        public void Present (Option option, UIElement element)
        {
            
        }

    }
}
