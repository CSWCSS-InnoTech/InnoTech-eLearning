﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

//[assembly: Dependency(typeof(Utils))]

namespace InnoTecheLearning
{/// <summary>
/// A class that provides methods to help run the App.
/// </summary>
    public static partial class Utils
    {   /// <summary>
        /// Which project is the app built in?
        /// </summary>
        public static ProjectType Project
        {
            get
            {
#if __ANDROID__
                return ProjectType.Android;
#elif __IOS__
                return ProjectType.iOS;
#elif WINDOWS_UWP
                return ProjectType.UWP10;
#elif WINDOWS_APP
                return ProjectType.Win81;
#elif WINDOWS_PHONE_APP
                return ProjectType.WinPhone81;
#else
                return ProjectType.Undefined;
#endif
            }
        }
        /// <summary>
        /// All project types.
        /// </summary>
        public enum ProjectType : sbyte
        {
            Undefined = -1,
            iOS,
            Android,
            UWP10,
            WinPhone81,
            Win81
        }
#if false && !(WINDOWS_APP || WINDOWS_PHONE_APP || WINDOWS_UWP)
        public class FileIO
        {
            public FileIO(string FileName, FileMode Mode = FileMode.Create)
            {
                this.FileName = FileName;
                FileStream = new System.IO.IsolatedStorage.IsolatedStorageFileStream(FileName, Mode);
            }
            //var a = new FileImageSourceConverter();
            //var uri = new Image().Source.GetValue(UriImageSource.UriProperty);
            public string FileName { get; }
            public string FilePath { get; }
            public System.IO.IsolatedStorage.IsolatedStorageFileStream FileStream { get; }
            public int Read(byte[] Buffer, int Offset, int Count)
            { return FileStream.Read(Buffer, Offset, Count); }
            public void Write(byte[] Buffer, int Offset, int Count)
            { FileStream.Write(Buffer, Offset, Count); }
            public void Dispose(bool Delete = false)
            {
                FileStream.Dispose();
                if (Delete)
                    File.Delete(FilePath);
            }
            ~FileIO()
            { try { Dispose(); } catch { } }
        }
#endif
        /// <summary>
        /// Returns different values depending on the <see cref="ProjectType"/> <see cref="Xamarin.Forms"/> is working on.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the value to be returned.</typeparam>
        /// <param name="iOS">The value for an Apple <paramref name="iOS"/> OS.</param>
        /// <param name="Android">The value for a Google <paramref name="Android"/> OS.</param>
        /// <param name="Windows">The value for the <paramref name="Windows"/> platform.</param>
        /// <param name="WinPhone">The value for a Microsoft <paramref name="WinPhone"/> OS.</param>
        /// <param name="Default">The value to return if no value was provided for the current OS.</param>
        /// <returns>The value depending on the <see cref="ProjectType"/> <see cref="Xamarin.Forms"/> is working on.</returns>
        public static T OnPlatform<T>(Func<T> iOS = null, Func<T> Android = null,
            Func<T> Windows = null, Func<T> WinPhone = null, Func<T> Default = null)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    if (iOS != null)
                        return (T)iOS.DynamicInvoke();
                    break;
                case Device.Android:
                    if (Android != null)
                        return (T)Android.DynamicInvoke();
                    break;
                case Device.WinPhone:
                    if (WinPhone != null)
                        return (T)WinPhone.DynamicInvoke();
                    break;
                case Device.Windows:
                    if (Windows != null)
                        return (T)Windows.DynamicInvoke();
                    break;
                default:
                    break;
            }
            return Default == null ? default(T) : (T)Default.DynamicInvoke();
        }
        /// <summary>
        /// Returns different values depending on the <see cref="ProjectType"/> <see cref="Xamarin.Forms"/> is working on.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the value to be returned.></typeparam>
        /// <param name="iOS">The value for an Apple <paramref name="iOS"/> OS.</param>
        /// <param name="Android">The value for a Google <paramref name="Android"/> OS.</param>
        /// <param name="Windows">The value for the <paramref name="Windows"/> platform.</param>
        /// <param name="WinPhone">The value for a Microsoft <paramref name="WinPhone"/> OS.</param>
        /// <param name="Default">The value to return if no value was provided for the current OS.</param>
        /// <returns>The value depending on the <see cref="ProjectType"/> <see cref="Xamarin.Forms"/> is working on.</returns>
        public static T OnPlatform<T>(T iOS = default(T), T Android = default(T), T Windows = default(T),
                                      T WinPhone = default(T), T Default = default(T))
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    if (!iOS.Equals(default(T)))
                        return iOS;
                    break;
                case Device.Android:
                    if (!Android.Equals(default(T)))
                        return Android;
                    break;
                case Device.WinPhone:
                    if (!WinPhone.Equals(default(T)))
                        return WinPhone;
                    break;
                case Device.Windows:
                    if (!Windows.Equals(default(T)))
                        return Windows;
                    break;
                default:
                    break;
            }
            return Default;
        }
        public static T OnProject<T>(Func<T> iOS = null, Func<T> Android = null, Func<T> UWP10 = null,
            Func<T> Win81 = null, Func<T> WinPhone81 = null, Func<T> Default = null)
        {
            switch (Project)
            {
                case ProjectType.iOS:
                    if (iOS != null)
                        return (T)iOS.DynamicInvoke();
                    break;
                case ProjectType.Android:
                    if (Android != null)
                        return (T)Android.DynamicInvoke();
                    break;
                case ProjectType.UWP10:
                    if (UWP10 != null)
                        return (T)UWP10.DynamicInvoke();
                    break;
                case ProjectType.Win81:
                    if (Win81 != null)
                        return (T)Win81.DynamicInvoke();
                    break;
                case ProjectType.WinPhone81:
                    if (WinPhone81 != null)
                        return (T)WinPhone81.DynamicInvoke();
                    break;
                case ProjectType.Undefined:
                default:
                    break;
            }
            return Default == null ? default(T) : (T)Default.DynamicInvoke();
        }
        public static T OnProject<T>(T iOS = default(T), T Android = default(T), T UWP10 = default(T),
                                      T Win81 = default(T), T WinPhone81 = default(T), T Default = default(T))
        {
            switch (Project)
            {
                case ProjectType.iOS:
                    if (!iOS.Equals(default(T)))
                        return iOS;
                    break;
                case ProjectType.Android:
                    if (!Android.Equals(default(T)))
                        return Android;
                    break;
                case ProjectType.UWP10:
                    if (!UWP10.Equals(default(T)))
                        return UWP10;
                    break;
                case ProjectType.Win81:
                    if (!Win81.Equals(default(T)))
                        return Win81;
                    break;
                case ProjectType.WinPhone81:
                    if (!WinPhone81.Equals(default(T)))
                        return WinPhone81;
                    break;
                case ProjectType.Undefined:
                default:
                    break;
            }
            return Default;
        }

        public static string CurrentNamespace
        { get { return "InnoTecheLearning." + OnProject("iOS", "Droid", "UWP", "Windows", "WinPhone"); } }

        public async static ValueTask<T> Alert<T>(T Return, Page Page, Text Message = default(Text),
                                                  string Title = "Alert", string Cancel = "OK")
        {
            await Page.DisplayAlert(Title, Message, Cancel);
            return Return;
        }

        public static ValueTask<Unit> Alert(Page Page, Text Message = default(Text),
            string Title = "Alert", string Cancel = "OK") => Unit.Await(Page.DisplayAlert(Title, Message, Cancel));
        public async static ValueTask<bool> AlertChoose(Page Page, Text Message = default(Text),
            string Title = "Alert", string Accept = "OK", string Cancel = "Cancel") =>
            await Page.DisplayAlert(Message, Title, Accept, Cancel);

        /// <summary>
        /// Making formatted text is #Ez.
        /// </summary>
        /// <param name="Spans">Obviously you will need text to format.</param>
        /// <returns></returns>
        public static FormattedString Format(params Span[] Spans)
        {
            FormattedString fs = new FormattedString();
            foreach (Span Span in Spans)
            {
                fs.Spans.Add(Span);
            }
            /*fs.Spans.Add(new Span { Text = "First ", ForegroundColor = Color.Red, FontSize = 14 });
            fs.Spans.Add(new Span { Text = " second ", ForegroundColor = Color.Blue, FontSize = 28 });
            fs.Spans.Add(new Span { Text = " third.", ForegroundColor = Color.Yellow, FontSize = 14 });*/
            return fs;
        }

        /// <summary>
        /// Returns bolded <see cref="Text"/>.
        /// </summary>
        /// <param name="Text"><see cref="Text"/> to make bold.</param>
        /// <returns></returns>
        public static Span Bold(Text Text)
        { return new Span { Text = Text, FontAttributes = FontAttributes.Bold }; }
        /// <summary>
        /// Returns a <see cref="string"/> consisting of the specified
        /// <see cref="char"/> repeated the specified number of times.
        /// </summary>
        /// <param name="Char">The <see cref="char"/> that you want to duplicate. </param>
        /// <param name="Count">Number of times to duplicate the <see cref="char"/>.</param>
        /// <returns>Returns a <see cref="string"/> consisting of the specified
        /// <see cref="char"/> repeated the specified number of times. </returns>
        public static string StrDup(char Char, int Count)
        { return new string(Char, Count); }
        /// <summary>
        /// Returns a <see cref="string"/> consisting of the specified
        /// <see cref="string"/> repeated the specified number of times.
        /// </summary>
        /// <param name="String">The <see cref="string"/> that you want to duplicate. </param>
        /// <param name="Count">Number of times to duplicate the <see cref="string"/>.</param>
        /// <returns>Returns a <see cref="string"/> consisting of the specified
        /// <see cref="string"/> repeated the specified number of times. </returns>
        public static string StrDup(string String, int Count)
        {
            string Return = "";
            for (int i = 0; i < Count; i++)
                Return += String;
            return Return;
        }
        public static T[] Duplicate<T>(T Item, int Count)
        {
            T[] Return = new T[Count];
            for (int i = 0; i < Count; i++) Return[i] = Item;
            return Return;
        }
        public static T[] Duplicate<T>(Func<T> Creator, int Count)
        {
            T[] Return = new T[Count];
            for (int i = 0; i < Count; i++) Return[i] = Creator();
            return Return;
        }
        /// <summary>
        /// Trys to convert an <see cref="object"/> instance to a specified <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> to convert to.</typeparam>
        /// <param name="Object">The <see cref="object"/> instance to convert.</param>
        /// <param name="Result">The result of conversion if successful.
        /// If not it will be the default value of the <see cref="Type"/> to convert to.</param>
        /// <returns>Whether the conversion has succeeded.</returns>
        public static bool TryCast<T>(object Object, out T Result)
        {
            try
            {
                Result = (T)Object;
                return true;
            }
            catch (Exception)
            //when(ex is InvalidCastException || ex is Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                Result = default(T);
                return false;
            }
        }

        /// <summary>
        /// Trys to convert an <see cref="object"/> instance to a specified <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> to convert to.</typeparam>
        /// <param name="Object">The <see cref="object"/> instance to convert.</param>
        /// <returns>The result of conversion if successful. If not it will be the default value of
        /// the <see cref="Type"/> to convert to.</returns>
        public static T TryCast<T>(object Object)
        {
            try
            {
                return (T)Object;
            }
            catch (Exception)
            //when (ex is InvalidCastException || ex is Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                return default(T);
            }
        }
        /// <summary>
        /// Trys to convert an <see cref="object"/> instance to a specified <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> to convert to.</typeparam>
        /// <param name="Object">The <see cref="object"/> instance to convert.</param>
        /// <param name="Default">The result of conversion if failed.</param>
        /// <param name="Result">The result of conversion if successful.
        /// If not it will be <paramref name="Default"/>.</param>
        /// <returns>Whether the conversion has succeeded.</returns>
        public static bool TryCast<T>(object Object, T Default, out T Result)
        {
            try
            {
                Result = (T)Object;
                return true;
            }
            catch (Exception)
            //when(ex is InvalidCastException || ex is Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                Result = Default;
                return false;
            }
        }

        /// <summary>
        /// Trys to convert an <see cref="object"/> instance to a specified <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> to convert to.</typeparam>
        /// <param name="Object">The <see cref="object"/> instance to convert.</param>
        /// <param name="Default">The result of conversion if failed.</param>
        /// <returns>The result of conversion if successful. If not it will be <paramref name="Default"/>.</returns>
        public static T TryCast<T>(object Object, T Default)
        {
            try
            {
                return (T)Object;
            }
            catch (Exception)
            //when (ex is InvalidCastException || ex is Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                return Default;
            }
        }

        public static char[] CharGen(char Start, char End, params char[] Exclude)
        {
            string Return = "";
            for (char i = Start; i < End + 1; i++)
            {
                if (Array.Exists(Exclude, x => x != i))
                    Return += i;
            }
            return Return.ToCharArray();
        }

        public static void DoNothing(params object[] Params)
        { }

        public static T Return<T>(T Return)
        { return Return; }

        public static T Return<T>(T Return, params object[] Params)
        { return Return; }

        public static T Assign<T>(T Value, out T Object)
        { return Object = Value; }

        public static ushort ToUShort(string String)
        {
            Retry: try
            {
                return ushort.Parse(String);
            }
            catch (OverflowException)
            {
                try
                {
                    return ushort.Parse(String.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.
                        NegativeSign, string.Empty).Replace("-", string.Empty).Remove(6));
                }
                catch (OverflowException)
                {
                    return ushort.Parse(String.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.
                        NegativeSign, string.Empty).Replace("-", string.Empty).Remove(5));
                }
            }
            catch (ArgumentNullException)
            { return 0; }
            catch (FormatException)
            {
                for (int i = 0; i < String.Length; i++)
                    if (!char.IsDigit(String[i]))
                    { String = String.Remove(i, 1); i--; }
                goto Retry;
            }
        }
        public delegate double MathFunc0();
        public delegate double MathFunc(double x);
        public delegate double MathFunc2(double x, double y);
        //public delegate double MathFuncArgs(params double[] arguments);
        public static string Eval(string CodeToExecute)
        { return new Jint.Engine().Execute(CodeToExecute).GetCompletionValue().ToString(); }
        public static T Eval<T>(string CodeToExecute)
        { return (T)(new Jint.Engine().Execute(CodeToExecute).GetCompletionValue().ToObject()); }
        private static string JSEvaluteAns = "";
        private static string[] JSVariables = new string[26];
        public enum AngleMode : byte { Degree, Radian, Gradian, Turn }
        public enum Modifier : byte { Normal, Percentage, Mixed_Fraction, Fraction, AngleMeasure, IntSurd, FracSurd }
        public static Jint.Engine JSEngine = new Jint.Engine();
        public static string JSEvaluate(string Expression, Page Alert = null, AngleMode Mode = AngleMode.Radian,
            bool TrueFree = false)
        {
            void GetVars(Jint.Engine Engine, params string[] Vars)
            {
                for (int i = 0; i <= 25; i++)
                    Engine.SetValue($"Var{((char)('A' + i)).ToString()}", Vars[i]);
                for (int i = 0; i <= 25; i++)
                    Engine.SetValue(((char)('A' + i)).ToString(), TryParseDouble(Vars[i], double.NaN));
            }
            void SetVars(Jint.Engine Engine)
            {
                for (int i = 0; i <= 25; i++)
                    JSVariables[i] = Engine.GetValue(((char)('A' + i)).ToString()).ToString();
            }/*
            string Escape(string Value) => new System.Text.StringBuilder(Value).
                Replace("\\", @"\\").Replace("\b", @"\b").Replace("\f", @"\f").
                Replace("\n", @"\n").Replace("\r", @"\r").Replace("\t", @"\t").Replace("\v", @"\v").
                Replace("\0", @"\0").Replace("'", @"\'").Replace("\"", @"\""").ToString();*/
            double AngleConvert(double Num, AngleMode Origin, AngleMode Target)
            {
                switch (Origin)
                {
                    case AngleMode.Degree:
                        switch (Target)
                        {
                            case AngleMode.Degree:
                                return Num;
                            case AngleMode.Radian:
                                return Num * Math.PI / 180;
                            case AngleMode.Gradian:
                                return Num * 10 / 9;
                            case AngleMode.Turn:
                                return Num / 360;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(Target), Target, "Invalid target of angle conversion.");
                        }
                    case AngleMode.Radian:
                        switch (Target)
                        {
                            case AngleMode.Degree:
                                return Num / Math.PI * 180;
                            case AngleMode.Radian:
                                return Num;
                            case AngleMode.Gradian:
                                return Num * 200 / Math.PI;
                            case AngleMode.Turn:
                                return Num / Math.PI / 2;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(Target), Target, "Invalid target of angle conversion.");
                        }
                    case AngleMode.Gradian:
                        switch (Target)
                        {
                            case AngleMode.Degree:
                                return Num / 10 * 9;
                            case AngleMode.Radian:
                                return Num / 200 * Math.PI;
                            case AngleMode.Gradian:
                                return Num;
                            case AngleMode.Turn:
                                return Num / 400;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(Target), Target, "Invalid target of angle conversion.");
                        }
                    case AngleMode.Turn:
                        switch (Target)
                        {
                            case AngleMode.Degree:
                                return Num * 360;
                            case AngleMode.Radian:
                                return Num * 2 * Math.PI;
                            case AngleMode.Gradian:
                                return Num * 400;
                            case AngleMode.Turn:
                                return Num;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(Target), Target, "Invalid target of angle conversion.");
                        }
                    default://What?
                        throw new ArgumentOutOfRangeException(nameof(Origin), Origin, "Invalid origin of angle conversion.");
                }
            }
            double Factorial(double x)
            {
                // Use type annotation to only accept numbers coercible to integers.
                // double is used for the return type to allow very large numbers to be returned.
                if (x < 0)
                {
                    return double.NaN; //throw(""Cannot take the factorial of a negative number."");
                }
                else
                {  // Call the recursive function.
                    return Factorial_(x, 0);
                }
                double Factorial_(double aNumber, byte recursNumber)
                {
                    // recursNumber keeps track of the number of iterations so far.
                    if (aNumber < 3)
                    {  // If the number is 0, its factorial is 1.
                        if (aNumber == 0) return 1.0;
                        return aNumber;
                    }
                    else
                    {
                        if (recursNumber > 170)
                        {
                            return double.PositiveInfinity;
                        }
                        else
                        {  // Otherwise, recurse again.
                            return (aNumber * Factorial_(aNumber - 1, (byte)(recursNumber + 1)));
                        }
                    }
                }
            }
            double GCD(double a, double b)
            {
                while (b != 0)
                {
                    var temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }
            // Ask user to enter expression.
            try
            {
                //TODO: Add methods from https://help.syncfusion.com/cr/xamarin/calculate
                //Number suffix reference: http://stackoverflow.com/questions/7898310/using-regex-to-balance-match-parenthesis
                JSEngine = new Jint.Engine();
                if (TrueFree) return JSEngine.Execute(Expression).GetCompletionValue().ToString();
                GetVars(JSEngine, JSVariables);
                JSEngine.SetValue("Prev", JSEvaluteAns)
                .SetValue("Ans", TryParseDouble(JSEvaluteAns, double.NaN))
                .SetValue("global", JSEngine.Global)
.Execute(@"
function Hypot()
{                    
    var y = 0.0;
    var length = arguments.length;

    for (var i = 0; i < length; i++)
    {
        if (arguments[i] === Infinity || arguments[i] === -Infinity)
                return Infinity;
        y += arguments[i] * arguments[i];
    }
    return Math.sqrt(y);
};
function Max() { return Math.max.apply(global, arguments); }
function Min() { return Math.min.apply(global, arguments); }
"""";")
                .SetValue("AngleConvert", new Func<double, AngleMode, AngleMode, double>(AngleConvert))
                .SetValue("Abs", new MathFunc(Math.Abs))
                .SetValue("Acos", new MathFunc(x => AngleConvert(Math.Acos(x), AngleMode.Radian, Mode)))
                .SetValue("Acosh", new MathFunc(x => Math.Log(x + Math.Sqrt(x * x - 1))))
                .SetValue("Acot", new MathFunc(x => AngleConvert(Math.PI / 2 - Math.Atan(x), AngleMode.Radian, Mode)))
                .SetValue("Acoth", new MathFunc(x => Math.Log((x + 1) / (x - 1)) / 2))
                .SetValue("Acsc", new MathFunc(x => AngleConvert(Math.Asin(1 / x), AngleMode.Radian, Mode)))
                .SetValue("Acsch", new MathFunc(x => Math.Log((Math.Sqrt(1 + x * x) + 1) / x)))
                .SetValue("Asec", new MathFunc(x => AngleConvert(Math.Acos(1 / x), AngleMode.Radian, Mode)))
                .SetValue("Asech", new MathFunc(x => Math.Log((Math.Sqrt(1 - x * x) + 1) / x)))
                .SetValue("Asin", new MathFunc(x => AngleConvert(Math.Asin(x), AngleMode.Radian, Mode)))
                .SetValue("Asinh", new MathFunc(x => Math.Log(x + Math.Sqrt(x * x + 1))))
                .SetValue("Atan", new MathFunc(x => AngleConvert(Math.Atan(x), AngleMode.Radian, Mode)))
                .SetValue("Atan2", new MathFunc2((y, x) => AngleConvert(Math.Atan2(y, x), AngleMode.Radian, Mode)))
                .SetValue("Atanh", new MathFunc(x => Math.Log((1 + x) / (1 - x)) / 2))
                .SetValue("Cbrt", new MathFunc(x => 
                    double.IsInfinity(x) || double.IsNaN(x) ? x : x / Math.Abs(x) * Math.Pow(Math.Abs(x), 1 / 3)))
                .SetValue("Ceil", new MathFunc(Math.Ceiling))
                .SetValue("Cos", new MathFunc(x => AngleConvert(Math.Cos(x), AngleMode.Radian, Mode)))
                .SetValue("Cosh", new MathFunc(Math.Cosh))
                .SetValue("Cot", new MathFunc(x => 1 / Math.Tan(AngleConvert(x, Mode, AngleMode.Radian))))
                .SetValue("Coth", new MathFunc(x => (1 + Math.Exp(-2 * x)) / (1 - Math.Exp(-2 * x))))
                .SetValue("Csc", new MathFunc(x => 1 / Math.Sin(AngleConvert(x, Mode, AngleMode.Radian))))
                .SetValue("Csch", new MathFunc(x => (2 * Math.Exp(-x)) / (1 - Math.Exp(-2 * x))))
                .SetValue("Clz32", new MathFunc(x => 31 - Math.Floor(Math.Log(x, 2))))
                .SetValue("Exp", new MathFunc(Math.Exp))
                .SetValue("Floor", new MathFunc(Math.Floor))
                .SetValue("Imul", new MathFunc2((x, y) => (x * (y % 65536) + x * Math.Floor(y / 65536)) % 2147483648))
                .SetValue("Lb", new MathFunc(x => Math.Log(x, 2)))
                .SetValue("Ln", new MathFunc(Math.Log))
                .SetValue("Log", new MathFunc2((x, @base) =>
                    Math.Log(x, double.IsNaN(@base) || double.IsInfinity(@base) ? Math.Log(10) : Math.Log(@base))))
                //.SetValue("Max_", new MathFuncArgs(System.Linq.Enumerable.Max))
                //.SetValue("Min_", new MathFuncArgs(System.Linq.Enumerable.Min))
                .SetValue("Pow", new MathFunc2(Math.Pow))
                .SetValue("Round", new MathFunc(Math.Round))
                .SetValue("Random", new MathFunc0(new Random().NextDouble))
                .SetValue("Sec", new MathFunc(x => 1 / Math.Cos(AngleConvert(x, Mode, AngleMode.Radian))))
                .SetValue("Sech", new MathFunc(x => (2 * Math.Exp(-x)) / (1 + Math.Exp(-2 * x))))
                .SetValue("Sign", new MathFunc(x => Math.Sign(x)))
                .SetValue("Sin", new MathFunc(x => Math.Sin(AngleConvert(x, Mode, AngleMode.Radian))))
                .SetValue("Sinh", new MathFunc(Math.Sinh))
                .SetValue("Sqrt", new MathFunc(Math.Sqrt))
                .SetValue("Tan", new MathFunc(x => Math.Tan(AngleConvert(x, Mode, AngleMode.Radian))))
                .SetValue("Tanh", new MathFunc(Math.Tanh))
                .SetValue("Trunc", new MathFunc(Math.Truncate))
                .SetValue("Deg", new MathFunc(x => AngleConvert(x, AngleMode.Degree, Mode)))
                .SetValue("Rad", new MathFunc(x => AngleConvert(x, AngleMode.Radian, Mode)))
                .SetValue("Grad", new MathFunc(x => AngleConvert(x, AngleMode.Gradian, Mode)))
                .SetValue("Turn", new MathFunc(x => AngleConvert(x, AngleMode.Turn, Mode)))
                .SetValue("Factorial", new MathFunc(Factorial))
                .SetValue("nPr", new MathFunc2((n, r) => r > n ? 0 : Factorial(n) / Factorial(n - r)))
                .SetValue("nCr", new MathFunc2((n, r) => r > n ? 0 : Factorial(n) / (Factorial(n - r) * Factorial(r))))
                .SetValue("GCD", new MathFunc2(GCD))
                .SetValue("HCF", new MathFunc2(GCD))
                .SetValue("LCM", new MathFunc2((x, y) => (x / GCD(x, y)) * y))

                .SetValue("π", Math.PI)
                .SetValue("e", Math.E)
                .SetValue("Root2", Math.Sqrt(2))
                .SetValue("Root0_5", Math.Sqrt(0.5))
                .SetValue("Ln2", Math.Log(2))
                .SetValue("Ln10", Math.Log(10))
                .SetValue("Log2e", Math.Log(Math.E, 2))
                .SetValue("Log10e", Math.Log10(Math.E))
                .Execute(Expression);
                JSEvaluteAns = JSEngine.GetCompletionValue().ToString();
                SetVars(JSEngine);
                return JSEngine.GetCompletionValue().ToString();
            }
            catch (System.Reflection.TargetInvocationException ex) when (Alert != null)
            { return 'ⓧ' + ex.InnerException.Message.Split('\r', '\n', '\f')[0]; }
            catch (Exception ex) when (Alert != null) { return 'ⓧ' + ex.Message.Split('\r', '\n', '\f')[0]; } //⮾ 
        }
        public static string Display(double value, Modifier mod)
        {
            switch (mod)
            {
                case Modifier.Normal:
                    return value.ToString();
                case Modifier.Percentage:
                    return (value * 100).ToString("F99").TrimEnd('0').TrimEnd('.') + "%";
                case Modifier.Mixed_Fraction:
                    for (var denom = 1.0; denom <= 1e6; denom++)
                    {
                        var numer = Math.Round(value * denom);
                        if (Math.Abs(value - numer / denom) == 0)
                            return $"{Math.Round(numer / denom)} {numer % denom} / {denom}";
                    }
                    throw new ArithmeticException("Cannot find appropriate fraction.");
                    /*
                    var best_numer = 1.0;
                    var best_denom = 1.0;
                    var best_err = Math.Abs(value - best_numer / best_denom);
                    for (var denom = 1.0; best_err > 0 && denom <= 1e6; denom++)
                    {
                        var numer = Math.Round(value * denom);
                        var err = Math.Abs(value - numer / denom);
                        if (err < best_err)
                        {
                            best_numer = numer;
                            best_denom = denom;
                            best_err = err;
                            //Console.WriteLine(best_numer + " / " + best_denom +
                            //    " = " + (best_numer / best_denom) + " error " + best_err);
                        }
                    }
                    return Math.Round(best_numer / best_denom) + " " + best_numer % best_denom + " / " + best_denom;*/
                case Modifier.Fraction:
                    for (var denom = 1.0; denom <= 1e6; denom++)
                    {
                        var numer = Math.Round(value * denom);
                        if (HasMinimalDifference(value, numer / denom))
                            return $"{numer} / {denom}";
                    }
                    throw new ArithmeticException("Cannot find appropriate fraction.");
                    /*
                    var best_numer = 1.0;
                    var best_denom = 1.0;
                    var best_err = Math.Abs(value - best_numer / best_denom);
                    for (var denom = 1.0; best_err > 0 && denom <= 1e6; denom++)
                    {
                        var numer = Math.Round(value * denom);
                        var err = Math.Abs(value - numer / denom);
                        if (err < best_err)
                        {
                            best_numer = numer;
                            best_denom = denom;
                            best_err = err;
                            //Console.WriteLine(best_numer + " / " + best_denom +
                            //    " = " + (best_numer / best_denom) + " error " + best_err);
                        }
                    }
                    return best_numer + " / " + best_denom;*/
                case Modifier.AngleMeasure:
                    var degree = Math.Floor(value);
                    var minute = Math.Floor((value - degree) * 60);
                    var second = ((value - degree - minute / 60) * 3600).ToString("F99").TrimEnd('0').TrimEnd('.');
                    return $"{degree}° {minute}′ {second}″";
                case Modifier.IntSurd:
                    if (double.IsInfinity(value) || double.IsNaN(value))
                        throw new ArithmeticException(nameof(value) + " is not finite.");
                    if (value.NearInteger()) return value.ToString() + OnPlatform("√1̅", "√1̅", "√̅1");
                    var Negative = value < 0;
                    // A = AVariable, B = Builder, C = Char
                    if (value > 5000 || value < -5000)
                        throw new ArgumentOutOfRangeException(nameof(value), value,
                            nameof(value) + "'s absolute value is too large (>5000).");
                    double A = Math.Round(value * value), squa = A;
                    do { A--; } while (squa / (A * A) - Math.Truncate(squa / (A * A)) != 0);
                    if (A == -1 || !HasMinimalDifference(A * Math.Sqrt(squa / (A * A)), value))
                        throw new ArithmeticException("Cannot find appropriate surd.");
                    //if (A < 0) A = 1;
                    var B = new System.Text.StringBuilder();
                    if (Negative) B.Append("-");
                    B.Append(A).Append("√");
                    foreach (var C in (squa / (A * A)).ToString())
                    {
#if WINDOWS_UWP
                        B.Append("̅");
                        B.Append(C);
#else
                    B.Append(C);
                    B.Append("̅");
#endif
                    }
                    return B.ToString();
                case Modifier.FracSurd:
                    if (double.IsInfinity(value) || double.IsNaN(value))
                        throw new ArithmeticException(nameof(value) + " is not finite.");
                    bool Minus = value < 0;
                    if (Minus) value = -value;
                    for (int Surd = 1; Surd <= 1000; Surd++)
                        for (int Denom = 1; Denom <= 500; Denom++)
                        {
                            var Numer = value / Math.Sqrt(Surd) * Denom;
                            if (Numer.NearInteger())
                            {
                                Numer = Math.Round(Numer);
                                int GCF(int a, int b)
                                {
                                    while (b != 0)
                                    {
                                        int temp = b;
                                        b = a % b;
                                        a = temp;
                                    }
                                    return a;
                                }
                                /*
                                int LCM(int a, int b)
                                {
                                    return (a / GCF(a, b)) * b;
                                }
                                */
                                (int Squared, int Remaining) SimplifySurd(int a)
                                {
                                    int Number = a, b = 0, Squared = 1;
                                    for (b = 2; a > 1; b++)
                                        if (a % b == 0)
                                        {
                                            int x = 0;
                                            while (a % b == 0)
                                            {
                                                a /= b;
                                                x++;
                                            }
                                            //Console.WriteLine("{0} is a prime factor {1} times!", b, x);
                                            for (int c = 2; c <= x; c += 2) Squared *= b;
                                        }
                                    return (Squared, Number / (Squared * Squared));
                                }

                                var Simplified = SimplifySurd(Surd);
                                Numer *= Simplified.Squared;
                                Surd = Simplified.Remaining;
                                var Common = GCF((int)Math.Round(Numer), Denom);
                                Numer /= Common;
                                Denom /= Common;

                                var Builder = new System.Text.StringBuilder();
                                if (Minus) Builder.Append("-");
                                Builder.Append(Numer).Append(" / ").Append(Denom).Append(" √");
                                foreach (var C in (Surd).ToString())
                                {
#if WINDOWS_UWP
                                    Builder.Append("̅");
                                    Builder.Append(C);
#else
                                Builder.Append(C);
                                Builder.Append("̅");
#endif
                                }
                                return Builder.ToString();
                            }
                        }
                    throw new ArithmeticException("Cannot find appropriate fraction and surd.");
                default:
                    throw new ArgumentOutOfRangeException(nameof(mod), mod, $"{mod} is not a valid {nameof(Modifier)}");
            }
        }
#if false
        static void Hi()
        {
            Type scriptType = Type.GetTypeFromCLSID(Guid.Parse("0E59F1D5-1FBE-11D0-8FF2-00A0D10038BC"));

            dynamic obj = Activator.CreateInstance(scriptType, false);
            obj.Language = "javascript";

            var res = obj.Eval("a=3; 2*a+32-Math.sin(6)");
        }
#endif
        public static void Try<TException>(Action Try, Action<TException> Catch = null,
            Func<bool> CatchFilter = null, Action Finally = null) where TException : Exception
        {
            try
            {
                Try();
            }
            catch (TException ex) when (Catch != null && (CatchFilter == null ? true : CatchFilter()))
            {
                Catch(ex);
            }
            finally
            {
                Finally?.Invoke();
            }

        }
        public static T Try<T, TException>(Func<T> Try, Func<TException, T> Catch = null,
            Func<bool> CatchFilter = null, Action Finally = null) where TException : Exception
        {
            try
            {
                return Try();
            }
            catch (TException ex) when (Catch != null && (CatchFilter == null ? true : CatchFilter()))
            {
                return Catch(ex);
            }
            finally
            {
                Finally?.Invoke();
            }
        }
        public static void Try<TException1, TException2>(Action Try, Action<TException1> Catch1 = null,
            Func<bool> CatchFilter1 = null, Action<TException2> Catch2 = null, Func<bool> CatchFilter2 = null,
            Action Finally = null) where TException1 : Exception where TException2 : Exception
        {
            try
            {
                Try();
            }
            catch (TException1 ex) when (Catch1 != null && (CatchFilter1 == null ? true : CatchFilter1()))
            {
                Catch1(ex);
            }
            catch (TException2 ex) when (Catch2 != null && (CatchFilter2 == null ? true : CatchFilter2()))
            {
                Catch2(ex);
            }
            finally
            {
                Finally?.Invoke();
            }

        }
        public static T Try<T, TException1, TException2>(Func<T> Try, Func<TException1, T> Catch1 = null,
            Func<bool> CatchFilter1 = null, Func<TException2, T> Catch2 = null, Func<bool> CatchFilter2 = null,
            Action Finally = null) where TException1 : Exception where TException2 : Exception
        {
            try
            {
                return Try();
            }
            catch (TException1 ex) when (Catch1 != null && (CatchFilter1 == null ? true : CatchFilter1()))
            {
                return Catch1(ex);
            }
            catch (TException2 ex) when (Catch2 != null && (CatchFilter2 == null ? true : CatchFilter2()))
            {
                return Catch2(ex);
            }
            finally
            {
                Finally?.Invoke();
            }
        }
        public static EventHandler<TextChangedEventArgs> TextChanged(Func<string> Value)
        {
            return (object sender, TextChangedEventArgs e) =>
            { if (((Entry)sender).Text != Value()) { ((Entry)sender).Text = Value(); } };
        }
        public static double TryParseDouble(string s, double @default)
        { if (double.TryParse(s, out double d)) { return d; } else { return @default; }; }

        public static byte[] Resample(byte[] samples, int fromSampleRate, int toSampleRate, int quality = 10)
        {
            int srcLength = samples.Length;
            var destLength = (long)samples.Length * toSampleRate / fromSampleRate;
            byte[] _samples = new byte[destLength];
            var dx = srcLength / destLength;

            // fmax : nyqist half of destination sampleRate
            // fmax / fsr = 0.5;
            var fmaxDivSR = 0.5;
            var r_g = 2 * fmaxDivSR;

            // Quality is half the window width
            var wndWidth2 = quality;
            var wndWidth = quality * 2;

            var x = 0;
            int i, j;
            double r_y;
            int tau;
            double r_w;
            double r_a;
            double r_snc;
            for (i = 0; i < destLength; ++i)
            {
                r_y = 0.0;
                for (tau = -wndWidth2; tau < wndWidth2; ++tau)
                {
                    // input sample index
                    j = x + tau;

                    // Hann Window. Scale and calculate sinc
                    r_w = 0.5 - 0.5 * Math.Cos(2 * Math.PI * (0.5 + (j - x) / wndWidth));
                    r_a = 2 * Math.PI * (j - x) * fmaxDivSR;
                    r_snc = 1.0;
                    if (r_a != 0)
                        r_snc = Math.Sin(r_a) / r_a;

                    if ((j >= 0) && (j < srcLength))
                    {
                        r_y += r_g * r_w * r_snc * samples[j];
                    }
                }
                _samples[i] = (byte)r_y;
                x += (int)dx; 
            }

            return _samples;
        }
        public static double[] Resample(double[] samples, int fromSampleRate, int toSampleRate, int quality = 10)
        {
            List<double> _samples = new List<double>();

            int srcLength = samples.Length;
            var destLength = (long)samples.Length * toSampleRate / fromSampleRate;
            var dx = srcLength / destLength;

            // fmax : nyqist half of destination sampleRate
            // fmax / fsr = 0.5;
            var fmaxDivSR = 0.5;
            var r_g = 2 * fmaxDivSR;

            // Quality is half the window width
            var wndWidth2 = quality;
            var wndWidth = quality * 2;

            var x = 0;
            int i, j;
            double r_y;
            int tau;
            double r_w;
            double r_a;
            double r_snc;
            for (i = 0; i < destLength; ++i)
            {
                r_y = 0.0;
                for (tau = -wndWidth2; tau < wndWidth2; ++tau)
                {
                    // input sample index
                    j = x + tau;

                    // Hann Window. Scale and calculate sinc
                    r_w = 0.5 - 0.5 * Math.Cos(2 * Math.PI * (0.5 + (j - x) / wndWidth));
                    r_a = 2 * Math.PI * (j - x) * fmaxDivSR;
                    r_snc = 1.0;
                    if (r_a != 0)
                        r_snc = Math.Sin(r_a) / r_a;

                    if ((j >= 0) && (j < srcLength))
                    {
                        r_y += r_g * r_w * r_snc * samples[j];
                    }
                }
                _samples[i] = r_y;
                x += (int)dx;
            }

            return _samples.ToArray();
        }
        public static IEnumerable<T> ToEnumerable<T>(params T[] Items)
        {
            foreach (T Item in Items)
                yield return Item;
        }

        /// <summary>Formula for computing Luminance out of R G B, which is something close to
        /// luminance = (red * 0.3) + (green * 0.6) + (blue * 0.1).</summary>
        // Original Source: http://stackoverflow.com/questions/20978198/how-to-match-uilabels-textcolor-to-its-background
        public static Color GetTextColor(Color backgroundColor)
        {
            var backgroundColorDelta = ((backgroundColor.R * 0.3) + (backgroundColor.G * 0.6) + (backgroundColor.B * 0.1));

            return (backgroundColorDelta > 0.4f) ? Color.Black : Color.White;
        }

        public static Dictionary<TKey, TValue> NewDictionary<TKey, TValue>(TKey key, TValue value) => 
            new Dictionary<TKey, TValue>() {[key] = value};
        public static void IgnoreEx(Action Action, params Type[] Exceptions)
        {
            try { Action(); }
            catch (Exception e) when (System.Linq.Enumerable.Contains(Exceptions, e.GetType())) { }
        }
        public static T IgnoreEx<T>(Func<T> Action, params Type[] Exceptions)
        {
            try { return Action(); }
            catch (Exception e) when (System.Linq.Enumerable.Contains(Exceptions, e.GetType())) { return default(T); }
        }

        public static ValueTask<bool> InternetAvaliable
        {
            get
            {
                async ValueTask<bool> InternalAsync()
                {
                    try
                    {
                        await System.Net.Dns.GetHostEntryAsync("www.google.com");
                        return true;
                    }
                    catch (System.Net.Sockets.SocketException) { return false; }
                    catch (AggregateException ex) when (ex.InnerException is System.Net.Sockets.SocketException)
                    {
                        return false;
                    }
                }
                return InternalAsync();
            }
        }
        public static int FloatToInt32Bits(float value)
        {
            int result = BitConverter.ToInt32(BitConverter.GetBytes(value), 0);
            if (((result & 0x7F800000) == 0x7F800000) && (result & 0x80000000) != 0)
                result = 0x7fc00000;
            return result;
        }
        public static float Int32BitsToFloat(int value) => BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
        public static bool HasMinimalDifference(float value1, float value2, int units = 11)
        {
            int iValue1 = FloatToInt32Bits(value1);
            int iValue2 = FloatToInt32Bits(value2);

            // If the signs are different, return false except for +0 and -0.
            if ((iValue1 >> 31) != (iValue2 >> 31)) return value1 == value2;

            int diff = Math.Abs(iValue1 - iValue2);

            return diff <= units;
        }
        public static bool HasMinimalDifference(double value1, double value2, int units = 22)
        {
            long lValue1 = BitConverter.DoubleToInt64Bits(value1);
            long lValue2 = BitConverter.DoubleToInt64Bits(value2);

            // If the signs are different, return false except for +0 and -0.
            if ((lValue1 >> 63) != (lValue2 >> 63)) return value1 == value2;

            long diff = Math.Abs(lValue1 - lValue2);

            return diff <= units;
        }
        public static Func<bool> False(Action A) => () => { A?.Invoke(); return false; };
        public static Func<bool> True(Action A) => () => { A?.Invoke(); return true; };
        public static TimeSpan Seconds(double s) => TimeSpan.FromSeconds(s);
        public static TimeSpan Milliseconds(double s) => TimeSpan.FromMilliseconds(s);

    }
    ///// <summary>
    ///// An uninitialized Void object.
    ///// </summary>
    //public static object Void
    //{ get { return System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(void)); } }
    /*
    public string TransformForCurrentPlatform(string url)
    {
        string result = ArgumentValidator.AssertNotNull(url, "url");

        if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
        {
            const string filePrefix = "file:///";

            if (url.StartsWith(filePrefix))
            {
                result = url.Substring(filePrefix.Length);
            }

            result = result.Replace("/", "_").Replace("\\", "_");

            if (result.StartsWith("_") && result.Length > 1)
            {
                result = result.Substring(1);
            }
        }
        else if (Device.OS == TargetPlatform.WinPhone)
        {
            if (url.StartsWith("/") && url.Length > 1)
            {
                result = result.Substring(1);
            }
        }

        return result;
    }
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            ImageSource imageSource = null;

            var transformer = Dependency.Resolve<IImageUrlTransformer, ImageUrlTransformer>(true);
            string url = transformer.TransformForCurrentPlatform(Source);

            if (Device.OS == TargetPlatform.Android)
            {
                imageSource = ImageSource.FromFile(url);
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                imageSource = ImageSource.FromFile(url);
            }
            else if (Device.OS == TargetPlatform.WinPhone)
            {
#if WINDOWS_PHONE
    if (url.StartsWith("/") && url.Length > 1)
    {
        url = url.Substring(1);
    }

    var stream = System.Windows.Application.GetResourceStream(new Uri(url, UriKind.Relative));

    if (stream != null)
    {
        imageSource = ImageSource.FromStream(() => stream.Stream);
    }
    else
    {
        ILog log;
        if (Dependency.TryResolve<ILog>(out log))
        {
           log.Debug("Unable to located create ImageSource using URL: " + url);
        }
    }
#endif
            }

            if (imageSource == null)
            {
                imageSource = ImageSource.FromFile(url);
            }

            return imageSource;
        }
    }
<style type="text/css">
.tg  {border-collapse:collapse;border-spacing:0;}
.tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;}
.tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;}
.tg .tg-s6z2{text-align:center}
.tg .tg-baqh{text-align:center;vertical-align:top}
</style>
<table class="tg">
<tbody><tr>
<th class="tg-s6z2" colspan="19"></th>
</tr>
<tr>
<td class="tg-baqh" rowspan="6"></td>
<td class="tg-baqh">π</td>
<td class="tg-baqh">e</td>
<td class="tg-baqh" rowspan="6"></td>
<td class="tg-baqh">Log</td>
<td class="tg-baqh">Pow</td>
<td class="tg-baqh">Sin</td>
<td class="tg-baqh">Asin</td>
<td class="tg-baqh" rowspan="6"></td>
<td class="tg-baqh">&lt;</td>
<td class="tg-baqh">&gt;</td>
<td class="tg-baqh">&amp;&amp;</td>
<td class="tg-baqh">&gt;&gt;&gt;</td>
<td class="tg-baqh" rowspan="6"><br></td>
<td class="tg-baqh">␣</td>
<td class="tg-baqh">%</td>
<td class="tg-baqh">Ans</td>
<td class="tg-baqh">⌫</td>
<td class="tg-baqh">⎚</td>
</tr>
<tr>
<td class="tg-s6z2">Root2</td>
<td class="tg-s6z2">Root0_5</td>
<td class="tg-s6z2">Rdm</td>
<td class="tg-s6z2">Exp</td>
<td class="tg-s6z2">Cos</td>
<td class="tg-s6z2">Acos</td>
<td class="tg-s6z2">&lt;=</td>
<td class="tg-s6z2">&gt;=</td>
<td class="tg-s6z2">&lt;&lt;</td>
<td class="tg-s6z2">&gt;&gt;</td>
<td class="tg-baqh">7</td>
<td class="tg-s6z2">8</td>
<td class="tg-s6z2">9</td>
<td class="tg-s6z2">(</td>
<td class="tg-s6z2">)</td>
</tr>
<tr>
<td class="tg-s6z2">Ln2</td>
<td class="tg-s6z2">Ln10</td>
<td class="tg-s6z2">Max</td>
<td class="tg-s6z2">Min</td>
<td class="tg-s6z2">Tan</td>
<td class="tg-s6z2">Atan</td>
<td class="tg-s6z2">==</td>
<td class="tg-s6z2">!=</td>
<td class="tg-s6z2">++</td>
<td class="tg-s6z2">--</td>
<td class="tg-baqh">4</td>
<td class="tg-s6z2">5</td>
<td class="tg-s6z2">6</td>
<td class="tg-s6z2">*</td>
<td class="tg-s6z2">/</td>
</tr>
<tr>
<td class="tg-s6z2">Log2e</td>
<td class="tg-s6z2">Log10e</td>
<td class="tg-s6z2">Sqrt</td>
<td class="tg-s6z2">Rnd</td>
<td class="tg-s6z2">Ceil</td>
<td class="tg-s6z2">Floor</td>
<td class="tg-s6z2">===</td>
<td class="tg-s6z2">!==</td>
<td class="tg-s6z2">~</td>
<td class="tg-s6z2">&amp;</td>
<td class="tg-baqh">1</td>
<td class="tg-s6z2">2</td>
<td class="tg-s6z2">3</td>
<td class="tg-s6z2">+</td>
<td class="tg-s6z2">-</td>
</tr>
<tr>
<td class="tg-s6z2"></td>
<td class="tg-s6z2"></td>
<td class="tg-s6z2" colspan="2">,</td>

<td class="tg-s6z2">Abs</td>
<td class="tg-s6z2">Fct</td>
<td class="tg-s6z2">!</td>
<td class="tg-s6z2">||</td>
<td class="tg-s6z2">^</td>
<td class="tg-s6z2">|</td>
<td class="tg-baqh">0</td>
<td class="tg-s6z2">.</td>
<td class="tg-s6z2">e</td>
<td class="tg-s6z2" colspan="2">=</td>
</tr>
<tr>
<td class="tg-s6z2">Const</td>
<td class="tg-s6z2"></td>
<td class="tg-s6z2"></td>
<td class="tg-s6z2">Func</td>
<td class="tg-s6z2"></td>
<td class="tg-s6z2"></td>
<td class="tg-s6z2"></td>
<td class="tg-s6z2">Bin</td>
<td class="tg-s6z2"></td>
<td class="tg-s6z2"></td>
<td class="tg-baqh"></td>
<td class="tg-s6z2">Norm</td>
<td class="tg-s6z2"></td>
<td class="tg-s6z2"></td>
<td class="tg-s6z2"></td>
</tr>
</tbody></table>
     */
}