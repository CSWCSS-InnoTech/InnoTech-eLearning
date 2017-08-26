﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventHandler = System.EventHandler;
using EventArgs = System.EventArgs;

using Part = InnoTecheLearning.Utils.NerdamerPart;
using static InnoTecheLearning.Utils.NerdamerPart;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InnoTecheLearning.Pages
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class Logic_Symbolics : ContentPage
    {
        //TODO: Add methods from https://help.syncfusion.com/cr/xamarin/calculate
        //Number suffix reference: http://stackoverflow.com/questions/7898310/using-regex-to-balance-match-parenthesis
        const int ButtonRows = 5;
        const int ButtonColumns = 5;
        [System.Flags] enum ButtonModifier : byte
        {
            Norm = 0,
            Shift = 1,
            Alpha = 2,
            Alt = 4
        }
        ButtonModifier ButtonMod = ButtonModifier.Norm;
        static readonly (Part, Part[,]) WhenNorm = (Percent, new Part[ButtonRows, ButtonColumns]
            {
                { Comma, Equation, Assign, LeftRound, RightRound },
                { D7, D8, D9, Exponent, Factorial },
                { D4, D5, D6, Multiply, Divide },
                { D1, D2, D3, Add, Subtract },
                { D0, Decimal, ConstPi, ConstE, ConstI }
            });
        static readonly (Part, Part[,]) WhenShift = (Fib, new Part[ButtonRows, ButtonColumns]
            {
                { Log, Log10, Sqrt, LeftSquare, RightSquare },
                { Floor, Ceil, Round, Trunc, Mod },
                { Gcd, Lcm, Mean, Mode, Median },
                { Expand, DivideFunc, PFactor, Min, Max },
                { Factor, Roots, Coeffs, Solve, SolveEquations }
            });
        static readonly (Part, Part[,]) WhenAlpha = (a, new Part[ButtonRows, ButtonColumns]
            {
                { b, c, d, e, f },
                { g, h, i, j, k },
                { l, m, n, o, p },
                { q, r, s, t, u },
                { v, w, x, y, z }
            });
        static readonly (Part, Part[,]) WhenShiftAlpha = (A, new Part[ButtonRows, ButtonColumns]
            {
                { B, C, D, E, F },
                { G, H, I, J, K },
                { L, M, N, O, P },
                { Q, R, S, T, U },
                { V, W, Part.X, Part.Y, Z }
            });
        static readonly (Part, Part[,]) WhenAlt = (Atan2, new Part[ButtonRows, ButtonColumns]
            {
                { Sin, Asin, Sinh, Asinh, Empty },
                { Cos, Acos, Cosh, Acosh, Empty },
                { Tan, Atan, Tanh, Atanh, Empty },
                { Empty, Sinc, Empty, Empty, Empty },
                { Sum, Product, Diff, Integrate, Defint }
            });
        static readonly (Part, Part[,]) WhenShiftAlt = (Step, new Part[ButtonRows, ButtonColumns]
            {
                { Sec, Asec, Sech, Asech, Erf },
                { Csc, Acsc, Csch, Acsch, Rect },
                { Cot, Acot, Coth, Acoth, Tri },
                { Si, Ci, Shi, Chi, Ei },
                { Laplace, Smpvar, Variance, Smpstdev, Stdev }
            });
        static readonly (Part, Part[,]) WhenAltAlpha = (NotEqual, new Part[ButtonRows, ButtonColumns]
            {
                { LessThan, LessEqual, Equal, GreaterEqual, GreaterThan },
                { Empty, Empty, Empty, Empty, Empty },
                { IMatrix, Empty, Empty, Empty, Empty },
                { Matrix, Matget, Matset, Invert, Transpose },
                { Vector, Vecget, Vecset, Cross, Dot }
            });
        static readonly (Part, Part[,]) WhenInvalid = (Empty, Utils.Duplicate(Empty, ButtonRows, ButtonColumns));
        readonly Button[,] Buttons;
        (Part, Part[,]) _Mapper = WhenNorm;
        (Part, Part[,]) Mapper
        {
            get => _Mapper;
            set
            {
                _Mapper = value;
                B03.Text = _Mapper.Item1.Name;
                for (int i = 0; i < ButtonRows; i++)
                    for (int j = 0; j < ButtonColumns; j++)
                    {
                        Buttons[i, j].Text = _Mapper.Item2[i, j].Name;
                    };
                if (ButtonMod == ButtonModifier.Shift) Back.Text = "CLR";
                else Back.Text = "←";
            }
        }
        bool DisplayDecimals = true;
        bool DoEvaluate = true;
        public Logic_Symbolics()
        {
            #region Declarations
            InitializeComponent();

            Buttons = new Button[ButtonRows, ButtonColumns]
            {
                { B10, B11, B12, B13, B14 },
                { B20, B21, B22, B23, B24 },
                { B30, B31, B32, B33, B34 },
                { B40, B41, B42, B43, B44 },
                { B50, B51, B52, B53, B54 }
            };
            EventHandler ModClicked(ButtonModifier Modifier) => (sender, e) =>
            {
                ButtonMod ^= Modifier;
                switch (ButtonMod)
                {
                    case ButtonModifier.Norm:
                        Mapper = WhenNorm;
                        break;
                    case ButtonModifier.Shift:
                        Mapper = WhenShift;
                        break;
                    case ButtonModifier.Alpha:
                        Mapper = WhenAlpha;
                        break;
                    case ButtonModifier.Alt:
                        Mapper = WhenAlt;
                        break;
                    case ButtonModifier.Shift | ButtonModifier.Alpha:
                        Mapper = WhenShiftAlpha;
                        break;
                    case ButtonModifier.Shift | ButtonModifier.Alt:
                        Mapper = WhenShiftAlt;
                        break;
                    case ButtonModifier.Alt | ButtonModifier.Alpha:
                        Mapper = WhenAltAlpha;
                        break;
                    case ButtonModifier.Shift | ButtonModifier.Alt | ButtonModifier.Alpha:
                    default:
                        Mapper = WhenInvalid;
                        break;
                }
                if (ButtonMod.HasFlag(Modifier)) (sender as VisualElement)?.TranslateTo(0, 10, 0);
                else (sender as VisualElement)?.TranslateTo(0, 0, 0);
            };
            EventHandler ButtonClicked = (sender, e) =>
            {
                var (x, y) = Utils.IndicesOf(Buttons, (Button)sender);
                In.Text += x == -1 && y == -1 ? Mapper.Item1.FullName : Mapper.Item2[x, y].FullName;
                ButtonMod = ButtonModifier.Norm;
                Shift.TranslateTo(0, 0, 0);
                Alpha.TranslateTo(0, 0, 0);
                Alt.TranslateTo(0, 0, 0);
                Mapper = WhenNorm;
            };
            EventHandler ButtonLongPressed = (sender, e) => 
            {
                var button = (Button)sender;
                var (x, y) = Utils.IndicesOf(Buttons, button);
                var Part = x == -1 && y == -1 ? Mapper.Item1 : Mapper.Item2[x, y];
                if (Part.DescriptionContent != null) DisplayAlert(Part.DescriptionTitle, Part.DescriptionContent, "OK");
            };
            #endregion

            #region Wiring up
            In.Completed += Calculate_Clicked;

            Shift.Clicked += ModClicked(ButtonModifier.Shift);
            Alpha.Clicked += ModClicked(ButtonModifier.Alpha);
            Alt.Clicked += ModClicked(ButtonModifier.Alt);
            Back.Clicked += (sender, e) => 
                In.Text = ButtonMod != ButtonModifier.Shift && In.Text?.Length > 0 ?
                     In.Text.Remove(In.Text.Length - 1) : string.Empty;

            B03.Clicked += ButtonClicked;
            Utils.LongPress.Register(B03, ButtonLongPressed);
            for (int i = 0; i < ButtonRows; i++)
                for (int j = 0; j < ButtonColumns; j++)
                {
                    Buttons[i, j].Clicked += ButtonClicked;
                    Utils.LongPress.Register(Buttons[i, j], ButtonLongPressed);
                }

            Calculate.Clicked += Calculate_Clicked;
            Utils.LongPress.Register(Calculate, async (sender, e) => Out.Text = await (await Current).Evaluate(In.Text));
            Display.Clicked += (sender, e) => Display.Text = (DisplayDecimals = !DisplayDecimals) ? "Display Decimals" : "Display Fractions";
            Evaluate.Clicked += (sender, e) => Evaluate.Text = (DoEvaluate = !DoEvaluate) ? "Evaluate Symbols" : "Keep Symbols";

            Out.Focused += (sender, e) => Out.Unfocus();
            OutCopy.Clicked += (sender, e) => Utils.ClipboardText = Out.Text;

            /*
            async void Debug_Clicked(object sender, EventArgs e) => await Eval("{0}");
            Debug.Clicked += Debug_Clicked;
            */
#if false
            Current.GetAwaiter().OnCompleted(() => Current.Result.Break += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() => DisplayAlert("Jint Breakpoint Reached",
$@"Current Statement:
{e.CurrentStatement.Location.Source}
Call Stack:
{e.CallStack}
Locals:
{e.Locals.Select(x => x.ToString()).Aggregate((prev, current) => $"{prev}\n{current}")}
Globals:
{e.Globals.Select(x => x.ToString()).Aggregate((prev, current) => $"{prev}\n{current}")}",
"Continue"));
                return Jint.Runtime.Debugger.StepMode.None;
            });
#endif
            #endregion
        }

        ~Logic_Symbolics()
        {
            Utils.LongPress.UnregisterAll(B03);
            for (int i = 0; i < ButtonRows; i++)
                for (int j = 0; j < ButtonColumns; j++)
                    Utils.LongPress.UnregisterAll(Buttons[i, j]);
        }

        #region Talking to the Engine
        public static List<Jint.Runtime.Debugger.BreakPoint> Breakpoints = new List<Jint.Runtime.Debugger.BreakPoint>();
        async Task Eval()
        {
            Out.Text = await (await Current).Evaluate(string.Concat(
                "try{",
                    "nerdamer('", Utils.EncodeJavascript(In.Text, false), "')",
                    DoEvaluate ? ".evaluate()" : string.Empty,
                    DisplayDecimals ? ".text()" : ".toString()",
                "}catch(e){'", Utils.Error, "'+(e.message?e.message:e)}"
                ));
        }
        async void Calculate_Clicked(object sender, EventArgs e) => await Eval();

        ValueTask<Utils.SymbolicsEngine> Current = CreateEngineAsync();
        static ValueTask<Utils.SymbolicsEngine> CreateEngineAsync() => new ValueTask<Utils.SymbolicsEngine>(async () =>
        {
            var Return = new Utils.SymbolicsEngine();
            await Return.Evaluate(Utils.Resources.GetString("nerdamer.core.js"));
            await Return.Evaluate(Utils.Resources.GetString("Algebra.js"));
            await Return.Evaluate(Utils.Resources.GetString("Calculus.js"));
            await Return.Evaluate(Utils.Resources.GetString("Solve.js"));
            await Return.Evaluate(Utils.Resources.GetString("Extra.js"));
            await Return.Evaluate("nerdamer.setFunction('lcm', ['a', 'b'], '(a / gcd(a, b)) * b')");
            return Return;
        });
#if false
        ValueTask<Engine> Current = CreateEngineAsync();
        static ValueTask<Engine> CreateEngineAsync() => new ValueTask<Engine>(() =>
            new Engine()
#warning Workaround for https://bugzilla.xamarin.com/show_bug.cgi?id=58995, used at nerdamer.core.js:7501
                .SetValue("___AND", new System.Func<double, double, int>((x, y) => (int)x & (int)y))
                .Execute(Utils.Resources.GetString("nerdamer.core.js"))
                .Execute(Utils.Resources.GetString("Algebra.js"))
                .Execute(Utils.Resources.GetString("Calculus.js"))
                .Execute(Utils.Resources.GetString("Solve.js"))
                .Execute(Utils.Resources.GetString("Extra.js"))
                .Execute("nerdamer.setFunction('lcm', ['a', 'b'], '(a / gcd(a, b)) * b')")
                .With((ref Engine x) => x.BreakPoints.AddRange(Breakpoints))
        );
#endif
        #endregion
    }
}