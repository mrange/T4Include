using System;
using System.Windows.Controls;

namespace $rootnamespace$
{
    [Flags]
    enum T4IncludeControlFlags
    {
        FirstFlag   = 0x0001            ,
        SecondFlag  = 0x0002            ,
        ThirdFlag   = 0x0004            ,
        FourthFlag  = 0x0008            ,
    }

    partial class T4IncludeControl : Control
    {
        partial void Constructed__T4IncludeControl()
        {
            // Intercepts construction
        }

        partial void Coerce_IsValid(ref bool coercedValue)
        {
            // Intercepts when IsValid is coerced
        }

        partial void Changed_IsValid(bool oldValue, bool newValue)
        {
            // Intercepts when IsValid is changed
        }

    }
}
