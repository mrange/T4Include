// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################






namespace Source.Common
{
    using System;

    partial class Log
    {
        public enum Level
        {
            Success = 1000,
            HighLight = 2000,
            Info = 3000,
            Warning = 10000,
            Error = 20000,
            Exception = 21000,
        }

        public static void Success (string format, params object[] args)
        {
            LogMessage (Level.Success, format, args);
        }
        public static void HighLight (string format, params object[] args)
        {
            LogMessage (Level.HighLight, format, args);
        }
        public static void Info (string format, params object[] args)
        {
            LogMessage (Level.Info, format, args);
        }
        public static void Warning (string format, params object[] args)
        {
            LogMessage (Level.Warning, format, args);
        }
        public static void Error (string format, params object[] args)
        {
            LogMessage (Level.Error, format, args);
        }
        public static void Exception (string format, params object[] args)
        {
            LogMessage (Level.Exception, format, args);
        }
#if !NETFX_CORE
        static ConsoleColor GetLevelColor (Level level)
        {
            switch (level)
            {
                case Level.Success:
                    return ConsoleColor.Green;
                case Level.HighLight:
                    return ConsoleColor.White;
                case Level.Info:
                    return ConsoleColor.Gray;
                case Level.Warning:
                    return ConsoleColor.Yellow;
                case Level.Error:
                    return ConsoleColor.Red;
                case Level.Exception:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Magenta;
            }
        }
#endif
        static string GetLevelMessage (Level level)
        {
            switch (level)
            {
                case Level.Success:
                    return "SUCCESS  ";
                case Level.HighLight:
                    return "HIGHLIGHT";
                case Level.Info:
                    return "INFO     ";
                case Level.Warning:
                    return "WARNING  ";
                case Level.Error:
                    return "ERROR    ";
                case Level.Exception:
                    return "EXCEPTION";
                default:
                    return "UNKNOWN  ";
            }
        }

    }
}

