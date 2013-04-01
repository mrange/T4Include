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

// ### INCLUDE: Generated_DebugVisualTreeControl_DependencyProperties.cs
// ### INCLUDE: DebugContainerControl.cs
// ### INCLUDE: ../../Extensions/WpfExtensions.cs

// ReSharper disable InconsistentNaming


using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Source.WPF.Debug
{
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Linq;
    using Source.Extensions;


    [TemplatePart (Name = PART_SelectButton     , Type = typeof (ButtonBase))   ]
    [TemplatePart (Name = PART_RefreshButton    , Type = typeof (ButtonBase))   ]
    [TemplatePart (Name = PART_SearchBox        , Type = typeof (TextBoxBase))  ]
    [TemplatePart (Name = PART_VisualTreeView   , Type = typeof (TreeView))     ]
    [TemplatePart (Name = PART_PropertyDataGrid , Type = typeof (DataGrid))     ]
    partial class DebugVisualTreeControl : DebugControl
    {
        public const string PART_SelectButton       = @"PART_SelectButton"      ;
        public const string PART_RefreshButton      = @"PART_RefreshButton"     ;
        public const string PART_SearchBox          = @"PART_SearchBox"         ;
        public const string PART_VisualTreeView     = @"PART_VisualTreeView"    ;
        public const string PART_PropertyDataGrid   = @"PART_PropertyDataGrid"  ;

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
                    <TreeView   Grid.Row=""2"" Grid.Column=""0"" x:Name=""PART_VisualTreeView""  ItemsSource=""{TemplateBinding VisualTree}"">
                        <TreeView.ItemTemplate>
                            <HierarchicalDataTemplate
                                ItemsSource=""{Binding Path=Children, Mode=OneTime}""
                                >
                                <TextBlock 
                                    Text=""{Binding Path=Name, Mode=OneTime}""
                                    ToolTip=""{Binding Path=ToolTip, Mode=OneTime}""
                                    />
                            </HierarchicalDataTemplate>
                        </TreeView.ItemTemplate>
                    </TreeView>
                    <DataGrid   Grid.Row=""2"" Grid.Column=""2"" x:Name=""PART_PropertyDataGrid""   ItemsSource=""{Binding ElementName=PART_VisualTreeView,Path=SelectedValue.Properties}"">
                    </DataGrid>
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
";
        public class VisualTreeNodeProperty : INotifyPropertyChanged
        {
            readonly DependencyObject   DependencyObject    ;
            readonly DependencyProperty DependencyProperty  ;

            public VisualTreeNodeProperty(
                DependencyObject dependencyObject, 
                DependencyProperty dependencyProperty
                )
            {
                DependencyObject    = dependencyObject      ?? new DependencyObject ();
                DependencyProperty  = dependencyProperty    ;
            }

            public string Name
            {
                get
                {
                    return DependencyProperty.Name;
                }
            }

            public object Value
            {
                get
                {
                    return DependencyObject.GetValue (DependencyProperty);    
                }
                set
                {
                    DependencyObject.SetValue (DependencyProperty, value);
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class VisualTreeNode : INotifyPropertyChanged
        {
            readonly DependencyObject   DependencyObject    ;
            string                      m_name              ;
            string                      m_tooltip           ;
            VisualTreeNode[]            m_children          ;
            VisualTreeNodeProperty[]    m_properties        ;

            public VisualTreeNode(DependencyObject dependencyObject)
            {
                DependencyObject = dependencyObject ?? new DependencyObject ();
            }

            public string Name
            {
                get
                {
                    if (m_name == null)
                    {
                        var type = DependencyObject.GetType ();
                
                        var sb = new StringBuilder (128);

                        sb.Append (type.Name);

                        var enumerator = DependencyObject.GetLocalValueEnumerator();

                        while(enumerator.MoveNext())
                        {
                            sb.Append (' ');
                            sb.Append (enumerator.Current.Property.Name);
                            sb.Append (@"=@""");
                            sb.Append ((enumerator.Current.Value ?? "").ToString ().Replace(@"""", @""""""));
                            sb.Append ('"');
                        }
                
                        m_name = sb.ToString ();
                       
                    }
                    return m_name;
                }
            }

            public string ToolTip
            {
                get
                {
                    if (m_tooltip == null)
                    {
                        var type = DependencyObject.GetType ();
                
                        var sb = new StringBuilder (128);

                        sb.Append (type.Name);

                        var enumerator = DependencyObject.GetLocalValueEnumerator();

                        while(enumerator.MoveNext())
                        {
                            sb.AppendLine ();
                            sb.Append ("  ");
                            sb.Append (enumerator.Current.Property.Name);
                            sb.Append (@"=@""");
                            sb.Append ((enumerator.Current.Value ?? "").ToString ().Replace(@"""", @""""""));
                            sb.Append ('"');
                        }
                
                        m_tooltip = sb.ToString ();
                       
                    }
                    return m_tooltip;
                }
            }

            public VisualTreeNode[] Children
            {
                get
                {
                    if (m_children == null)
                    {
                        m_children = DependencyObject
                            .GetVisualChildren ()
                            .Select(d => new VisualTreeNode (d))
                            .ToArray()
                            ;
                    }
                    return m_children;
                }
            }

            static readonly ConcurrentDictionary<Type, DependencyProperty[]> s_cachedProperties = new ConcurrentDictionary<Type, DependencyProperty[]> ();

            public VisualTreeNodeProperty[] Properties
            {
                get
                {
                    if (m_properties == null)
                    {
                        var properties = s_cachedProperties.GetOrAdd (
                            DependencyObject.GetType(),
                            type => type
                                      .GetFields (BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)
                                      .Where (fi => fi.FieldType == typeof (DependencyProperty))
                                      .Select (fi => fi.GetValue (null) as DependencyProperty)
                                      .Where (dp => dp != null)
                                      .OrderBy (dp => dp.Name)
                                      .ToArray ()
                                      );

                        m_properties = properties
                            .Select (dp => new VisualTreeNodeProperty (DependencyObject, dp))
                            .ToArray ()
                            ;
                    }

                    return m_properties;
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;      
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

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

        partial void Constructed__DebugVisualTreeControl()
        {
            RoutedEventHandler buttonClick = Button_Click;
            AddHandler (ButtonBase.ClickEvent, buttonClick);
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = e.OriginalSource as ButtonBase;
            if (button == null)
            {
                return;
            }

            switch (button.Name ?? "")
            {
                case PART_SelectButton:
                    break;
                case PART_RefreshButton:
                    PopulateVisualTree ();
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
            dependencyObject.Dispatcher.Async_Invoke (
                "Delay visual tree population till application idle", 
                PopulateVisualTree
                );
        }

        void PopulateVisualTree()
        {
            VisualTree.Clear ();
            if (AttachedTo == null)
            {
                return;
            }
            VisualTree.Add (new VisualTreeNode (AttachedTo));
        }

        protected override void OnDetachFrom(DependencyObject dependencyObject)
        {
            VisualTree.Clear ();
        }
    }
}
