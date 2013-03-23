
// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # text template file (.tt)                                                      #
// ############################################################################



// ############################################################################
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\AnimatedEntrance.cs
// @@@ INCLUDE_FOUND: Generated_AnimatedEntrance_DependencyProperties.cs
// @@@ INCLUDING: C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_DependencyProperties.cs
// ############################################################################
// Certains directives such as #define and // Resharper comments has to be 
// moved to top in order to work properly    
// ############################################################################
// ReSharper disable CompareOfFloatsByEqualityOperator
// ReSharper disable InconsistentNaming
// ReSharper disable InvocationIsSkipped
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PossibleUnintendedReferenceComparison
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast
// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedMember.Local
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\AnimatedEntrance.cs
namespace FileInclude
{
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
    
    
    namespace Source.WPF
    {
        using System.Collections.ObjectModel;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Markup;
    
    
        [TemplatePart(Name = PART_Canvas    , Type = typeof(Canvas))]
        [ContentProperty("Children")]
        sealed partial class AnimatedEntrance : Control
        {
            const string PART_Canvas    = @"PART_Canvas"    ;
    
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
    
            public const string DefaultStyle = @"
<Style 
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    TargetType=""{x:Type i:AnimatedEntrance}""
    >
    <Setter Property=""Template"">
        <Setter.Value>
            <ControlTemplate TargetType=""{x:Type i:AnimatedEntrance}"">
                <Canvas x:Name=""PART_Canvas"">
                </Canvas>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
";
    
            readonly static Style s_defaultStyle;
            Canvas m_canvas;
    
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
                m_canvas    = GetTemplateChild(PART_Canvas) as Canvas;
            }
    
            public void Present (Option option, UIElement element)
            {
                
            }
    
        }
    }
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\AnimatedEntrance.cs
// ############################################################################

// ############################################################################
// @@@ BEGIN_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_DependencyProperties.cs
namespace FileInclude
{
    
    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    
    
    
                                       
    
    
    namespace Source.WPF
    {
        using System.Collections;
        using System.Collections.ObjectModel;
        using System.Collections.Specialized;
    
        using System.Windows;
        using System.Windows.Media;
    
        // ------------------------------------------------------------------------
        // AnimatedEntrance
        // ------------------------------------------------------------------------
        partial class AnimatedEntrance
        {
            #region Uninteresting generated code
            static readonly DependencyPropertyKey ChildrenPropertyKey = DependencyProperty.RegisterReadOnly (
                "Children",
                typeof (ObservableCollection<UIElement>),
                typeof (AnimatedEntrance),
                new FrameworkPropertyMetadata (
                    null,
                    FrameworkPropertyMetadataOptions.None,
                    Changed_Children,
                    Coerce_Children          
                ));
    
            public static readonly DependencyProperty ChildrenProperty = ChildrenPropertyKey.DependencyProperty;
    
            static void Changed_Children (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
            {
                var instance = dependencyObject as AnimatedEntrance;
                if (instance != null)
                {
                    var oldValue = (ObservableCollection<UIElement>)eventArgs.OldValue;
                    var newValue = (ObservableCollection<UIElement>)eventArgs.NewValue;
    
                    if (oldValue != null)
                    {
                        oldValue.CollectionChanged -= instance.CollectionChanged_Children;
                    }
    
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += instance.CollectionChanged_Children;
                    }
    
                    instance.Changed_Children (oldValue, newValue);
                }
            }
    
            void CollectionChanged_Children(object sender, NotifyCollectionChangedEventArgs e)
            {
                CollectionChanged_Children (
                    sender, 
                    e.Action,
                    e.OldStartingIndex,
                    e.OldItems,
                    e.NewStartingIndex,
                    e.NewItems
                    );
            }
    
            static object Coerce_Children (DependencyObject dependencyObject, object basevalue)
            {
                var instance = dependencyObject as AnimatedEntrance;
                if (instance == null)
                {
                    return basevalue;
                }
                var oldValue = (ObservableCollection<UIElement>)basevalue;
                var newValue = oldValue;
    
                instance.Coerce_Children (oldValue, ref newValue);
    
                if (newValue == null)
                {
                   newValue = new ObservableCollection<UIElement> ();
                }
    
                return newValue;
            }
    
            #endregion
    
            // --------------------------------------------------------------------
            // Constructor
            // --------------------------------------------------------------------
            public AnimatedEntrance ()
            {
                CoerceAllProperties ();
                Constructed__AnimatedEntrance ();
            }
            // --------------------------------------------------------------------
            partial void Constructed__AnimatedEntrance ();
            // --------------------------------------------------------------------
            void CoerceAllProperties ()
            {
                CoerceValue (ChildrenProperty);
            }
    
    
            // --------------------------------------------------------------------
            // Properties
            // --------------------------------------------------------------------
    
               
            // --------------------------------------------------------------------
            public ObservableCollection<UIElement> Children
            {
                get
                {
                    return (ObservableCollection<UIElement>)GetValue (ChildrenProperty);
                }
                private set
                {
                    if (Children != value)
                    {
                        SetValue (ChildrenPropertyKey, value);
                    }
                }
            }
            // --------------------------------------------------------------------
            partial void Changed_Children (ObservableCollection<UIElement> oldValue, ObservableCollection<UIElement> newValue);
            partial void Coerce_Children (ObservableCollection<UIElement> value, ref ObservableCollection<UIElement> coercedValue);
            partial void CollectionChanged_Children (object sender, NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems);
            // --------------------------------------------------------------------
    
    
        }
        // ------------------------------------------------------------------------
    
    }
                                       
}
// @@@ END_INCLUDE: C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_DependencyProperties.cs
// ############################################################################

// ############################################################################
namespace FileInclude.Include
{
    static partial class MetaData
    {
        public const string RootPath        = @"..\..\..";
        public const string IncludeDate     = @"2013-03-23T21:05:26";

        public const string Include_0       = @"C:\temp\GitHub\T4Include\WPF\AnimatedEntrance.cs";
        public const string Include_1       = @"C:\temp\GitHub\T4Include\WPF\Generated_AnimatedEntrance_DependencyProperties.cs";
    }
}
// ############################################################################


