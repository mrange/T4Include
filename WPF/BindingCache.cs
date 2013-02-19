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
    using System;
    using System.Collections.Concurrent;
    using System.Windows.Data;

    sealed partial class BindingCache<TKey, TBinding>
        where TBinding : BindingBase
    {
        readonly ConcurrentDictionary<TKey, TBinding> m_cache = new ConcurrentDictionary<TKey, TBinding>();
        readonly Func<TKey, TBinding> m_bindingFactory;

        public BindingCache(Func<TKey, TBinding> bindingFactory)
        {
            if (bindingFactory == null)
            {
                throw new ArgumentNullException("bindingFactory");
            }

            m_bindingFactory = bindingFactory;
        }

        public TBinding GetOrAdd(TKey key)
        {
            return m_cache.GetOrAdd(key, m_bindingFactory);
        }

        public object ProvideValue(TKey key, IServiceProvider serviceProvider)
        {
            return GetOrAdd(key).ProvideValue(serviceProvider);
        }
    }
}
