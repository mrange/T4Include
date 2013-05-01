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

// ### INCLUDE: BaseDebugTreeControl.cs

namespace Source.WPF.Debug
{
    using System.Collections.Generic;
    using System.Windows;
    using Source.Extensions;

    partial class DebugVisualTreeControl : BaseDebugTreeControl
    {
        protected override int OnGetOrdinal()
        {
            return 1000;
        }

        protected override string OnGetFriendlyName()
        {
            return "Visual Tree";
        }

        protected override IEnumerable<DependencyObject> GetChildren(DependencyObject dependencyObject)
        {
            return dependencyObject.GetVisualChildren ();
        }
    }
}