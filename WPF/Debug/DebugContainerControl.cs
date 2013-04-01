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
// ### INCLUDE: ../../Extensions/WpfExtensions.cs

using Source.Extensions;

namespace Source.WPF.Debug
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    abstract partial class DebugControl : Control
    {
        protected DependencyObject AttachedTo;

        public string GetFriendlyName ()
        {
            return OnGetFriendlyName ();    
        }

        protected abstract string OnGetFriendlyName();

        public void AttachTo (DependencyObject dependencyObject)
        {
            if (AttachedTo != null)
            {
                DetachFrom ();
            }

            AttachedTo = dependencyObject;            

            if (AttachedTo != null)
            {
                OnAttachTo (AttachedTo);
            }
        }

        protected abstract void OnAttachTo(DependencyObject attachedTo);

        public void DetachFrom ()
        {
            if (AttachedTo != null)
            {
                OnDetachFrom (AttachedTo);
            }
        }

        protected abstract void OnDetachFrom(DependencyObject attachedTo);
    }

    [TemplatePart (Name=PART_Tabs, Type = typeof (TabControl))]
    partial class DebugContainerControl : Control
    {
        const string PART_Tabs  = @"PART_Tabs"  ;

        public const string DefaultStyle = @"
<Style 
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    TargetType=""{x:Type d:DebugContainerControl}""
    >
    <Setter Property=""Template"">
        <Setter.Value>
            <ControlTemplate TargetType=""{x:Type d:DebugContainerControl}"">
                <TabControl x:Name=""PART_Tabs"">
                </TabControl>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
";

        static readonly Style       s_defaultStyle      ;
        static readonly TypeInfo[]  s_debugControlTypes ;

        readonly DebugControl[]     m_debugControls     ;
        TabControl                  m_tabControl        ;

        DependencyObject            m_attachedTo        ;

        static DebugContainerControl ()
        {
            var parserContext = GetParserContext();

            s_defaultStyle = (Style)XamlReader.Parse(
                DefaultStyle,
                parserContext
                );

            var type = typeof (DebugContainerControl);
            s_debugControlTypes = type
                .Assembly
                .DefinedTypes
                .Where (typeInfo => !typeInfo.IsAbstract && typeof(DebugControl).IsAssignableFrom (typeInfo))
                .ToArray ()
                ;

            StyleProperty.OverrideMetadata(typeof(DebugContainerControl), new FrameworkPropertyMetadata(s_defaultStyle));
        }

        public DebugContainerControl ()
        {
            m_debugControls = s_debugControlTypes
                .Select (Activator.CreateInstance)
                .OfType<DebugControl>()
                .ToArray();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            m_tabControl = GetTemplateChild (PART_Tabs) as TabControl;
            if (m_tabControl != null)
            {
                var tabs = m_debugControls
                    .Select (dc => 
                        new TabItem
                            {
                                Header  = dc.GetFriendlyName()  ,
                                Content = dc            ,
                            })
                    .ToArray ()
                    ;
                m_tabControl.ItemsSource = tabs;
            }
        }

        internal static ParserContext GetParserContext()
        {
            var parserContext = new ParserContext
                                    {
                                        XamlTypeMapper = new XamlTypeMapper(new string[0])
                                    };

            var type = typeof (DebugContainerControl);
            var namespaceName = type.Namespace ?? "";
            var assemblyName = type.Assembly.FullName;
            parserContext.XamlTypeMapper.AddMappingProcessingInstruction("Debug", namespaceName, assemblyName);
            parserContext.XmlnsDictionary.Add("d", "Debug");
            return parserContext;
        }

        public static void ShowWindow (DependencyObject dependencyObject, string title = null)
        {
            if (dependencyObject == null)
            {
                return;
            }

            dependencyObject.Dispatcher.Async_Invoke (
                "Delay show window till application idle", 
                () => ShowWindowImpl (dependencyObject, title)
                );

        }

        static void ShowWindowImpl(DependencyObject dependencyObject, string title)
        {
            var debugContainerControl = new DebugContainerControl ();
            debugContainerControl.AttachTo (dependencyObject);

            var window = 
                new Window
                    {
                        Title       = title ?? "Debug"      , 
                        MinHeight   = 200                   ,
                        MinWidth    = 320                   ,
                        Content     = debugContainerControl
                    };

            window.Show();
        }

        void AttachTo(DependencyObject dependencyObject)
        {
            foreach (var dc in m_debugControls)
            {
                dc.DetachFrom ();
            }

            m_attachedTo = dependencyObject;

            if (m_attachedTo != null)
            {
                foreach (var dc in m_debugControls)
                {
                    dc.AttachTo (m_attachedTo);
                }
            }


        }
    }
}
