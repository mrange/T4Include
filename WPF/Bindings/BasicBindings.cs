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

// ReSharper disable PartialTypeWithSinglePart

// ### INCLUDE: ../BindingCache.cs

namespace Source.WPF.Bindings
{
    using System;
    using System.Windows.Data;
    using System.Windows.Markup;

    sealed partial class OneTime : MarkupExtension
    {
        static readonly BindingCache<string, Binding> s_cache = new BindingCache<string, Binding>(
            k => new Binding(k) { Mode=BindingMode.OneTime,}
            );

        public readonly string Path;

        public OneTime(string path)
        {
            Path = path ?? "";
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return s_cache.ProvideValue(Path, serviceProvider);
        }
    }

    sealed partial class OneWay : MarkupExtension
    {
        static readonly BindingCache<string, Binding> s_cache = new BindingCache<string, Binding>(
            k => new Binding(k) { Mode = BindingMode.OneWay, ValidatesOnDataErrors = true,}
            );

        public readonly string Path;

        public OneWay(string path)
        {
            Path = path ?? "";
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return s_cache.ProvideValue(Path, serviceProvider);
        }
    }

    sealed partial class TwoWay : MarkupExtension
    {
        static readonly BindingCache<string, Binding> s_cache = new BindingCache<string, Binding>(
            k => new Binding(k) { Mode = BindingMode.TwoWay, ValidatesOnDataErrors = true, }
            );

        public readonly string Path;

        public TwoWay(string path)
        {
            Path = path ?? "";
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return s_cache.ProvideValue(Path, serviceProvider);
        }
    }

    sealed partial class Immediate : MarkupExtension
    {
        static readonly BindingCache<string, Binding> s_cache = new BindingCache<string, Binding>(
            k => new Binding(k) { Mode = BindingMode.TwoWay, ValidatesOnDataErrors = true, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, }
            );

        public readonly string Path;

        public Immediate(string path)
        {
            Path = path ?? "";
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return s_cache.ProvideValue(Path, serviceProvider);
        }
    }
}
