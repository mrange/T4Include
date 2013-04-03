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

// ### INCLUDE: Generated_BaseDebugTreeControl_DependencyProperties.cs
// ### INCLUDE: DebugContainerControl.cs
// ### INCLUDE: ../../Extensions/WpfExtensions.cs

// ReSharper disable InconsistentNaming


using System.Collections.Generic;

namespace Source.WPF.Debug
{
    using System;
    using System.Collections.Concurrent;
    using System.ComponentModel;
    using System.Linq;
    using System.Globalization;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Markup;

    using Source.Extensions;

    [TemplatePart (Name = PART_SelectButton     , Type = typeof (ButtonBase))   ]
    [TemplatePart (Name = PART_RefreshButton    , Type = typeof (ButtonBase))   ]
    [TemplatePart (Name = PART_SearchBox        , Type = typeof (TextBoxBase))  ]
    [TemplatePart (Name = PART_TreeView         , Type = typeof (TreeView))     ]
    [TemplatePart (Name = PART_PropertyDataGrid , Type = typeof (DataGrid))     ]
    abstract partial class BaseDebugTreeControl : DebugControl
    {
        public const string PART_SelectButton       = @"PART_SelectButton"      ;
        public const string PART_RefreshButton      = @"PART_RefreshButton"     ;
        public const string PART_SearchBox          = @"PART_SearchBox"         ;
        public const string PART_TreeView           = @"PART_TreeView"          ;
        public const string PART_PropertyDataGrid   = @"PART_PropertyDataGrid"  ;

        public const string DefaultStyle = @"
<Style 
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    TargetType=""{x:Type d:BaseDebugTreeControl}""
    >
    <Setter Property=""Template"">
        <Setter.Value>
            <ControlTemplate TargetType=""{x:Type d:BaseDebugTreeControl}"">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height=""24""/>
                        <RowDefinition Height=""4""/>
                        <RowDefinition Height=""*""/>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition Width=""4""/>
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <StackPanel Grid.Row=""0"" Grid.Column=""0"" Orientation=""Horizontal"">
                        <Button x:Name=""PART_SelectButton""    Padding=""8,0,8,0"" Margin=""0,0,4,0"" Content=""Select""/>
                        <Button x:Name=""PART_RefreshButton""   Padding=""8,0,8,0"" Margin=""0,0,4,0"" Content=""Refresh""/>
                    </StackPanel>
                    <TextBox    Grid.Row=""0"" Grid.Column=""2"" x:Name=""PART_SearchBox""      />
                    <TreeView   Grid.Row=""2"" Grid.Column=""0"" x:Name=""PART_TreeView""  ItemsSource=""{TemplateBinding Tree}"">
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
                    <GridSplitter
                        Grid.Column=""1""
                        Grid.RowSpan=""3""
                        HorizontalAlignment=""Stretch""
                        VerticalAlignment=""Stretch""
                        /> 
                    <DataGrid   
                        Grid.Row=""2"" 
                        Grid.Column=""2"" 
                        x:Name=""PART_PropertyDataGrid""   
                        ItemsSource=""{Binding ElementName=PART_TreeView,Path=SelectedValue.Properties}"" 
                        EnableColumnVirtualization=""False"" 
                        EnableRowVirtualization=""True"" 
                        AutoGenerateColumns=""False""                        
                        >
                        <DataGrid.Columns>
                            <DataGridTextColumn IsReadOnly=""True"" Header=""Name"" Binding=""{Binding Path=Name, Mode=OneTime}""/>
                            <DataGridTextColumn Header=""Value"" Binding=""{Binding Path=Value, Mode=TwoWay}""/>
                        </DataGrid.Columns>
                    </DataGrid>
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
";
        public class TreeNodeProperty : INotifyPropertyChanged
        {
            readonly DependencyObject   DependencyObject    ;
            readonly DependencyProperty DependencyProperty  ;

            public TreeNodeProperty(
                DependencyObject dependencyObject, 
                DependencyProperty dependencyProperty
                )
            {
                DependencyObject    = dependencyObject      ?? new DependencyObject ();
                DependencyProperty  = dependencyProperty    ;
            }

            public bool IsReadOnly
            {
                get
                {
                    return DependencyProperty.ReadOnly;
                }
            }

            public bool IsAttached
            {
                get
                {
                    var ownerType = DependencyProperty.OwnerType;
                    var type = DependencyObject.GetType ();

                    return !ownerType.IsAssignableFrom (type);
                }
            }

            public bool HasValue
            {
                get
                {
                    return DependencyObject.ReadLocalValue (DependencyProperty) != null;
                }
            }

            public string Name
            {
                get
                {
                    if (IsAttached)
                    {
                        return DependencyProperty.OwnerType.Name + "." + DependencyProperty.Name;                                                
                    }
                    else
                    {
                        return DependencyProperty.Name;                        
                    }
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
                    if (IsReadOnly)
                    {
                    }
                    else 
                    {
                        value = value ?? "";
                        var converter = TypeDescriptor.GetConverter (DependencyProperty.PropertyType);
                        if (converter.CanConvertFrom(value.GetType ()))
                        {
                            var convertedValue = converter.ConvertFrom (null, CultureInfo.CurrentUICulture, value);
                            DependencyObject.SetValue (DependencyProperty, convertedValue);
                        }
                    }
                    OnPropertyChanged("Value");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class TreeNode : INotifyPropertyChanged
        {
            readonly BaseDebugTreeControl   Owner               ;
            readonly DependencyObject       DependencyObject    ;
            string                          m_name              ;
            string                          m_tooltip           ;
            TreeNode[]                      m_children          ;
            TreeNodeProperty[]              m_properties        ;

            public TreeNode(BaseDebugTreeControl owner, DependencyObject dependencyObject)
            {
                Owner = owner;
                DependencyObject = dependencyObject ?? new DependencyObject ();
            }

            public string Name
            {
                get
                {
                    if (m_name == null)
                    {
                        m_name = BuildDescription(" ");
                    }
                    return m_name;
                }
            }

            string BuildDescription(string separator)
            {
                separator = separator ?? " ";
                var type = DependencyObject.GetType();

                var sb = new StringBuilder(128);

                sb.Append(type.Name);

                foreach (var dp in DependencyObject.GetLocalDependencyProperties().OrderBy(dp => dp.Name))
                {
                    var value = DependencyObject.GetValue(dp);
                    if (value == null)
                    {
                        continue;
                    }

                    sb.Append(separator);
                    sb.Append(dp.Name);
                    sb.Append(@"=""");
                    sb.AppendFormat(CultureInfo.CurrentUICulture, "{0}", value);
                    sb.Append('"');
                }

                return sb.ToString ();
            }

            public string ToolTip
            {
                get
                {
                    if (m_tooltip == null)
                    {
                        m_tooltip = BuildDescription ("\r\n  ");
                    }
                    return m_tooltip;
                }
            }

            public TreeNode[] Children
            {
                get
                {
                    if (m_children == null)
                    {
                        m_children = Owner.GetChildren (DependencyObject)
                            .Select(d => new TreeNode (Owner, d))
                            .ToArray()
                            ;
                    }
                    return m_children;
                }
            }

            static readonly ConcurrentDictionary<Type, DependencyProperty[]> s_cachedProperties = new ConcurrentDictionary<Type, DependencyProperty[]> ();

            public TreeNodeProperty[] Properties
            {
                get
                {
                    if (m_properties == null)
                    {
                        var classProperties = s_cachedProperties.GetOrAdd (
                            DependencyObject.GetType(),
                            type => type.GetClassDependencyProperties().ToArray ()
                            );

                        var localProperties = DependencyObject.GetLocalDependencyProperties ();

                        m_properties = classProperties
                            .Union(localProperties)
                            .OrderBy (dp => dp.Name)
                            .Select (dp => new TreeNodeProperty (DependencyObject, dp))
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

        protected abstract IEnumerable<DependencyObject> GetChildren(DependencyObject dependencyObject);

        readonly static Style           s_defaultStyle      ;

        static BaseDebugTreeControl ()
        {
            var parserContext = DebugContainerControl.GetParserContext();

            s_defaultStyle = (Style)XamlReader.Parse(
                DefaultStyle,
                parserContext
                );            

            StyleProperty.OverrideMetadata(typeof(BaseDebugTreeControl), new FrameworkPropertyMetadata(s_defaultStyle));
        }

        partial void Constructed__BaseDebugTreeControl()
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
                    PopulateTree ();
                    break;
                default:
                    break;
            }
        }

        protected override void OnAttachTo(DependencyObject dependencyObject)
        {
            dependencyObject.Dispatcher.Async_Invoke (
                "Delay tree population till application idle", 
                PopulateTree
                );
        }

        void PopulateTree()
        {
            Tree.Clear ();
            if (AttachedTo == null)
            {
                return;
            }
            Tree.Add (new TreeNode (this, AttachedTo));
        }

        protected override void OnDetachFrom(DependencyObject dependencyObject)
        {
            Tree.Clear ();
        }
    }
}
