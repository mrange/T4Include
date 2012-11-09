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
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart

namespace Source.Common
{
    using System.Globalization;

    sealed partial class InitConfig
    {
        public CultureInfo DefaultCulture = CultureInfo.InvariantCulture;
    }

    static partial class Config
    {
        static partial void Partial_Constructed(ref InitConfig initConfig);

        public readonly static CultureInfo DefaultCulture;

        static Config ()
        {
            var initConfig = new InitConfig();

            Partial_Constructed (ref initConfig);

            initConfig = initConfig ?? new InitConfig();

            DefaultCulture = initConfig.DefaultCulture;
        }
    }
}
