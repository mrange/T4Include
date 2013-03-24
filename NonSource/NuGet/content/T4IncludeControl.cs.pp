using System.Windows.Controls;

namespace $rootnamespace$
{
    partial class T4IncludeControl : Control
    {
        partial void Constructed__T4IncludeControl()
        {
            // Intercepts construction
        }

        partial void Coerce_IsValid(bool value, ref bool coercedValue)
        {
            // Intercepts when IsValid is coerced
        }

        partial void Changed_IsValid(bool oldValue, bool newValue)
        {
            // Intercepts when IsValid is changed
        }

    }
}
