﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static InnoTecheLearning.Utils;
using static InnoTecheLearning.Utils.Create;
using static InnoTecheLearning.StreamPlayer;
using Xamarin.Forms;

namespace InnoTecheLearning
{
    public class Main : ContentPage
    {
        public enum Pages : sbyte
        {
            CloudTest = -2,
            Changelog = -1,
            Main,
            Forum,
            Translate,
            VocabBook,
            Calculator,
            Calculator_Free,
            Factorizer,
            Sports,
            MusicTuner,
            MathSolver
        }
        Pages _Showing;
        Pages Showing
        {
            get { return _Showing; }
            set
            {
                switch (value)
                {
                    case Pages.CloudTest:
                        Region = "CloudTest";
                        Content = CloudTest;
                        break;
                    case Pages.Changelog:
                        Region = "Changelog";
                        Content = ChangelogView(this);
                        break;
                    case Pages.Main:
                        Region = "Main";
                        Content = MainView;
                        break;
                    case Pages.Forum:
                        Region = "Forum";
                        break;
                    case Pages.Translate:
                        Region = "Translate";
                        break;
                    case Pages.VocabBook:
                        Region = "VocabBook";
                        break;
                    case Pages.Calculator:
                        Region = "Calculator";
                        Content = Calculator;
                        break;
                    case Pages.Calculator_Free:
                        Region = "Calculator_Free";
                        Content = Calculator_Free;
                        break;
                    case Pages.Factorizer:
                        Region = "Factorizer";
                        break;
                    case Pages.Sports:
                        Region = "Sports";
                        break;
                    case Pages.MusicTuner:
                        Region = "MusicTuner";
                        Content = MusicTuner;
                        break;
                    case Pages.MathSolver:
                        Region = "MathSolver";
                        break;
                    default:
                        Region = "App";
                        break;
                }
                _Showing = value;
            }
        }
        public Main()
        {
            BackgroundColor = Color.White;
            //Alert(this, "Main constructor");
            Showing = Pages.Main;
            Log("Main page initialized.");
        }
        protected override bool OnBackButtonPressed()
        {
            if (Showing != Pages.Main)
            {
                Showing = Pages.Main;
                return true;
            }
            else
                return base.OnBackButtonPressed();
        }

        public StackLayout MainView
        {
            get
            {
                return new StackLayout
                {
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Children = {
                        Title("CSWCSS eLearning App"),
                        Society,

           MainScreenRow(MainScreenItem(Image(ImageFile.Forum),delegate{
               /*Alert(this,"[2016-11-1 18:00:00] 1E03: Hi\n"+
               "[2016-11-1 18:00:09] 3F43: No one likes you loser\n[2016-11-1 18:00:16] 1E03: 😢😭😢😭😢😭😢😭😢\n"+
               "[2016-11-1 18:00:22] 2E12: Hey don't bully him!\n[2016-11-1 18:00:28] 3F43: Go kill yourself because you"+
               " are a F-ing faggot\n[2016-11-1 18:00:34] 2E12: I am going to rape you\n"+
               "[2016-11-1 18:00:55] 3F43: "+StrDup("😢😭😢😭😢😭😢😭😢",5));*/
               Showing = Pages.CloudTest;
                         }, BoldLabel("Forum\n(CloudTest)") ),
                         MainScreenItem(Image(ImageFile.Translate), delegate{Alert(this,
                          "I'm a translator.\nInput: eifj[vguowhfuy9q727969y\nOutput: Gud mornin turists, we spek Inglish"); },
                         BoldLabel("Translator") ),
                         MainScreenItem(Image(ImageFile.VocabBook),delegate {Alert(this,"Ida = 捱打，伸張靜儀、儆惡懲奸，\n" +
"      救死扶傷、伸張靜儀、鋤強扶弱、儆惡懲奸、修身齊家、知足常樂"); },BoldLabel("Vocab Book"))),

           MainScreenRow(MainScreenItem(Image(ImageFile.Calculator),delegate {
                            Showing = Pages.Calculator;// Alert(this, "1+1=2");
                             },BoldLabel("Calculator")),
                         MainScreenItem(Image(ImageFile.Calculator_Free),delegate {
                             Showing = Pages.Calculator_Free;//Alert(this, StrDup("1+",100) + "1\n=101");
                         },BoldLabel("Calculator\nFree Mode")),
                         MainScreenItem(Image(ImageFile.Factorizer),delegate {Alert(this,
                             "Factorize 3𝐗²(𝐗−1)²+2𝐗(𝐗−1)³\n = 𝐗(𝐗−1)²(5𝐗−2)"
                             ); },BoldLabel("Quadratic Factorizer"))),

           MainScreenRow(MainScreenItem(Image(ImageFile.Sports), delegate {
                             Alert(this,"🏃🏃🏃長天長跑🏃🏃🏃"); },BoldLabel("Sports")),
                         MainScreenItem(Image(ImageFile.MusicTuner), delegate {
                             Showing = Pages.MusicTuner;//Alert(this,"🎼♯♩♪♭♫♬🎜🎝♮🎵🎶\n🎹🎻🎷🎺🎸");
                         },BoldLabel("Music Tuner")),
                         MainScreenItem(Image(ImageFile.MathSolver), delegate {
                             Alert(this, "🔥🔥🔥🔥🔥🔥🐲🐉"); },BoldLabel("Maths Solver Minigame"))
                         ),

                Button((Text)"Changelog", delegate {Showing = Pages.Changelog; }),
                Utils.Create.Version
                    }
                };
            }
        }
        StreamPlayer MusicSound { get; set; }
        public StackLayout MusicTuner
        {
            get
            {
                return new StackLayout
                {
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Children = {
                        Title("CSWCSS Music Tuner"),

                        Row(Image(ImageFile.Violin, delegate {Alert(this, "🎻♫♬♩♪♬♩♪♬"); })
                        , (Text)"Violin and Viola"),

                        Row(Button((Text)"G",  delegate {MusicSound =  Play(Sounds.Violin_G); }),
                        Button((Text)"D",  delegate {MusicSound =  Play(Sounds.Violin_D); }),
                        Button((Text)"A",  delegate {MusicSound =  Play(Sounds.Violin_A); }),
                        Button((Text)"E",  delegate {MusicSound =  Play(Sounds.Violin_E); })),

                        Row(Image(ImageFile.Cello, delegate {Alert(this, "🎻♫♬♩♪♬♩♪♬"); })
                        , (Text)"Cello and Double Bass"),

                        Row(Button((Text)"'C",  delegate {MusicSound =  Play(Sounds.Cello_C); }),
                        Button((Text)"'G",  delegate {MusicSound =  Play(Sounds.Cello_G); }),
                        Button((Text)"D",  delegate {MusicSound =  Play(Sounds.Cello_D); }),
                        Button((Text)"A",  delegate {MusicSound =  Play(Sounds.Cello_A); })),

#if __ANDROID__
                        BoldLabel("Sorry, but Android 6.0+ only!"),
#endif
                        Back(this)
                    }
                };
            }
        }
        public StackLayout CloudTest
        {
            get
            {
                var Display = new
                {
                    ID = "ID:".PadRight(8),
                    Name = "Name:".PadRight(8),
                    Class = "Class:".PadRight(8),
                    Number = "Number:".PadRight(8)
                };

                Entry ID = new Entry
                {
                    Keyboard = Keyboard.Numeric,
                    Placeholder = "Student ID (without beginning s)",
                    PlaceholderColor = Color.Gray,
                    TextColor = Color.Black,
                    Text = "18999"
                };
                Entry E = new Entry
                {
                    Keyboard = Keyboard.Text,
                    Placeholder = "Password",
                    PlaceholderColor = Color.Gray,
                    TextColor = Color.Black,
                    Text = "Y1234567"
                };
                Label L1 = BoldLabel(Display.ID);
                Label L2 = BoldLabel(Display.Name);
                Label L3 = BoldLabel(Display.Class);
                Label L4 = BoldLabel(Display.Number);

                return new StackLayout
                {
                    Children = {ID, E, Button("Test the Cloud",
                    delegate { var Response = Login(ToUShort(ID.Text), E.Text);
                    Try(delegate {
                    L1.Text = Display.ID + Response[0];    L2.Text = Display.Name + Response[1];
                    L3.Text = Display.Class + Response[2]; L4.Text = Display.Number + Response[3]; },
                    (IndexOutOfRangeException ex)=> {
                        Alert(this, "Abnornal return value from Cloud: " + '"' + Response + '"'); },
                        Catch2:(Exception ex) => { Alert(this, ex.ToString()); }
                    ); }),
                    L1, L2, L3, L4, Back(this)}
                    ,
                    VerticalOptions = LayoutOptions.Center
                };
            }
        }
        string Calculator_Value = "";
        List<Expressions> Calculator_Expression = new List<Expressions>();
        delegate void NoInputDelegate();
        event NoInputDelegate Calculator_Changed;
        public StackLayout Calculator
        {
            get
            {
                Entry In = new Entry
                {
                    TextColor = Color.Black,
                    Placeholder = "Expression",
                    PlaceholderColor = Color.Gray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.FromRgb(0xD0, 0xD0, 0xD0),
                    Text = Calculator_Expression.AsString()
                };
                In.TextChanged += delegate
                {
                    if (In.Text != Calculator_Expression.AsString())
                        In.Text = Calculator_Expression.AsString();
                };
                Entry Out = new Entry
                {
                    TextColor = Color.Black,
                    Placeholder = "Result",
                    PlaceholderColor = Color.Gray,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                Out.TextChanged += Calculator_TextChanged;
                Calculator_Changed += delegate { In.Text = Calculator_Expression.AsString(); };
                Grid Const, Func, Bin, Norm = new Grid
                {
                    ColumnDefinitions = Columns(GridUnitType.Star, 1, 1, 1, 1, 1),
                    RowDefinitions = Rows(GridUnitType.Star, 1, 1, 1, 1, 1),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                Append(Norm.Children, Expressions.Space, "␣", 0, 0);
                Append(Norm.Children, Expressions.Modulus, 1, 0);
                Append(Norm.Children, Expressions.Ans, 2, 0);
                Norm.Children.Add(Button("⌫", delegate
                {
                    Calculator_Expression.RemoveLast();
                    Calculator_Changed();
                }, Color.FromHex("#E91E63")), 3, 0);
                Norm.Children.Add(Button("⎚", delegate
                {
                    Calculator_Expression.Clear();
                    Calculator_Changed();
                }, Color.FromHex("#E91E63")), 4, 0); //Pink
                Append(Norm.Children, Expressions.D7, 0, 1, Color.FromHex("#607D8B"));
                Append(Norm.Children, Expressions.D8, 1, 1, Color.FromHex("#607D8B"));
                Append(Norm.Children, Expressions.D9, 2, 1, Color.FromHex("#607D8B"));
                Append(Norm.Children, Expressions.LParenthese, 3, 1);
                Append(Norm.Children, Expressions.RParenthese, 4, 1);
                Append(Norm.Children, Expressions.D4, 0, 2, Color.FromHex("#607D8B"));
                Append(Norm.Children, Expressions.D5, 1, 2, Color.FromHex("#607D8B"));
                Append(Norm.Children, Expressions.D6, 2, 2, Color.FromHex("#607D8B"));
                Append(Norm.Children, Expressions.Multiplication, 3, 2);
                Append(Norm.Children, Expressions.Division, 4, 2);
                Append(Norm.Children, Expressions.D1, 0, 3, Color.FromHex("#607D8B"));
                Append(Norm.Children, Expressions.D2, 1, 3, Color.FromHex("#607D8B"));
                Append(Norm.Children, Expressions.D3, 2, 3, Color.FromHex("#607D8B"));
                Append(Norm.Children, Expressions.Addition, 3, 3);
                Append(Norm.Children, Expressions.Subtraction, 4, 3);
                Append(Norm.Children, Expressions.D0, 0, 4, Color.FromHex("#607D8B")); //Blue Grey
                Append(Norm.Children, Expressions.DPoint, 1, 4);
                Append(Norm.Children, Expressions.e, 2, 4);
                Norm.Children.Add(Button("=", delegate
                {
                    Calculator_Value = Evaluate(In.Text, this);
                    Calculator_TextChanged(Out, new TextChangedEventArgs("", In.Text));
                }, Color.FromHex("#FFC107")), 3, 5, 4, 5); //Amber

                Bin = new Grid
                {
                    ColumnDefinitions = Columns(GridUnitType.Star, 1, 1, 1, 1),
                    RowDefinitions = Rows(GridUnitType.Star, 1, 1, 1, 1, 1),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                Append(Bin.Children, Expressions.Less, 0, 0);
                Append(Bin.Children, Expressions.Great, 1, 0);
                Append(Bin.Children, Expressions.LAnd, 2, 0);
                Append(Bin.Children, Expressions.UnsignRShift, 3, 0);
                Append(Bin.Children, Expressions.LessEqual, 0, 1);
                Append(Bin.Children, Expressions.GreatEqual, 1, 1);
                Append(Bin.Children, Expressions.BLShift, 2, 1);
                Append(Bin.Children, Expressions.BRShift, 3, 1);
                Append(Bin.Children, Expressions.Equal, 0, 2);
                Append(Bin.Children, Expressions.NEqual, 1, 2);
                Append(Bin.Children, Expressions.Increment, 2, 2);
                Append(Bin.Children, Expressions.Decrement, 3, 2);
                Append(Bin.Children, Expressions.Identity, 0, 3);
                Append(Bin.Children, Expressions.NIdentity, 1, 3);
                Append(Bin.Children, Expressions.BNot, 2, 3);
                Append(Bin.Children, Expressions.BAnd, 3, 3);
                Append(Bin.Children, Expressions.LNot, 0, 4);
                Append(Bin.Children, Expressions.LOr, 1, 4);
                Append(Bin.Children, Expressions.BXor, 2, 4);
                Append(Bin.Children, Expressions.BOr, 3, 4);

                Func = new Grid
                {
                    ColumnDefinitions = Columns(GridUnitType.Star, 1, 1, 1, 1),
                    RowDefinitions = Rows(GridUnitType.Star, 1, 1, 1, 1, 1),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                Append(Func.Children, Expressions.Log, "Log", 0, 0);
                Append(Func.Children, Expressions.Pow, "Pow", 1, 0);
                Append(Func.Children, Expressions.Sin, "Sin", 2, 0);
                Append(Func.Children, Expressions.Asin, "Asin", 3, 0);
                Append(Func.Children, Expressions.Random, "Random", 0, 1);
                Append(Func.Children, Expressions.Exp, "Exp", 1, 1);
                Append(Func.Children, Expressions.Cos, "Cos", 2, 1);
                Append(Func.Children, Expressions.Acos, "Acos", 3, 1);
                Append(Func.Children, Expressions.Max, "Max", 0, 2);
                Append(Func.Children, Expressions.Min, "Min", 1, 2);
                Append(Func.Children, Expressions.Tan, "Tan", 2, 2);
                Append(Func.Children, Expressions.Atan, "Atan", 3, 2);
                Append(Func.Children, Expressions.Sqrt, "Sqrt", 0, 3);
                Append(Func.Children, Expressions.Round, "Round", 1, 3);
                Append(Func.Children, Expressions.Ceil, "Ceil", 2, 3);
                Append(Func.Children, Expressions.Floor, "Floor", 3, 3);
                Append(Func.Children, Expressions.Comma, 0, 2, 4, 5);
                Append(Func.Children, Expressions.Abs, "Abs", 2, 4);
                Append(Func.Children, Expressions.Factorial, "Factor", 3, 4);

                Const = new Grid
                {
                    ColumnDefinitions = Columns(GridUnitType.Star, 1, 1, 1, 1),
                    RowDefinitions = Rows(GridUnitType.Star, 1, 1, 1),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                Append(Const.Children, Expressions.π, 0, 0);
                Append(Const.Children, Expressions.e, 1, 0);
                Append(Const.Children, Expressions.Root2, 2, 0);
                Append(Const.Children, Expressions.Root0_5, "Root0.5", 3, 0);
                Append(Const.Children, Expressions.Ln2, 0, 1);
                Append(Const.Children, Expressions.Ln10, 1, 1);
                Append(Const.Children, Expressions.Log2e, 2, 1);
                Append(Const.Children, Expressions.Log10e, 3, 1);
                Append(Const.Children, Expressions.Infinity, 0, 2);
                Append(Const.Children, Expressions.NInfinity, 1, 2);
                Append(Const.Children, Expressions.NaN, 2, 2);
                Append(Const.Children, Expressions.Undefined, 3, 2);

                StackLayout Return = new StackLayout { Children = { In, new ScrollView(), Norm, Out } };
                ScrollView Select = new ScrollView
                {
                    Content = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = {
                        Button("Norm", delegate {Try(delegate { if(Return.Children[2] != Norm) Return.Children[2]
                                = Norm; },(InvalidOperationException e)=> { }); }, Color.FromHex("#8AC249")) ,
                        Button("Bin", delegate {Try(delegate { if(Return.Children[2] != Bin) Return.Children[2]
                                = Bin; },(InvalidOperationException e)=> { }); }, Color.FromHex("#8AC249")) ,
                        Button("Func", delegate {Try(delegate { if(Return.Children[2] != Func) Return.Children[2]
                                = Func; },(InvalidOperationException e)=> { }); }, Color.FromHex("#8AC249")) ,
                        Button("Const", delegate {Try(delegate { if(Return.Children[2] != Const) Return.Children[2]
                                = Const; },(InvalidOperationException e)=> { }); }, Color.FromHex("#8AC249")) ,
                        //Light Green
                        }
                    }
                };
                Return.Children[1] = Select;
                return Return;
            } //http://www.goxuni.com/671054-how-to-create-a-custom-color-picker-for-xamarin-forms/
        }
        #region Append
        public void Append(Grid.IGridList<View> List, Expressions Expression,
            Color BackColor = default(Color), Color TextColor = default(Color))
        {
            List.Add(Button(Expression, (object sender, ExpressionEventArgs e) =>
            { Calculator_Expression.Add(e.Expression); Calculator_Changed(); }, BackColor, TextColor));
        }
        public void Append(Grid.IGridList<View> List, Expressions Expression,
            int Left, int Top, Color BackColor = default(Color), Color TextColor = default(Color))
        {
            List.Add(Button(Expression, (object sender, ExpressionEventArgs e) =>
            { Calculator_Expression.Add(e.Expression); Calculator_Changed(); }, BackColor, TextColor), Left, Top);
        }
        public void Append(Grid.IGridList<View> List, Expressions Expression,
            int Left, int Right, int Top, int Bottom, Color BackColor = default(Color), Color TextColor = default(Color))
        {
            List.Add(Button(Expression, (object sender, ExpressionEventArgs e) =>
            { Calculator_Expression.Add(e.Expression); Calculator_Changed(); }, BackColor, TextColor), Left, Right, Top, Bottom);
        }
        public void Append(Grid.IGridList<View> List, Expressions Expression, Text Name,
            Color BackColor = default(Color), Color TextColor = default(Color))
        {
            List.Add(Button(Expression, (object sender, ExpressionEventArgs e) =>
            { Calculator_Expression.Add(e.Expression); Calculator_Changed(); }, Name, BackColor, TextColor));
        }
        public void Append(Grid.IGridList<View> List, Expressions Expression, Text Name,
            int Left, int Top, Color BackColor = default(Color), Color TextColor = default(Color))
        {
            List.Add(Button(Expression, (object sender, ExpressionEventArgs e) =>
            { Calculator_Expression.Add(e.Expression); Calculator_Changed(); }, Name, BackColor, TextColor), Left, Top);
        }
        public void Append(Grid.IGridList<View> List, Expressions Expression, Text Name,
            int Left, int Right, int Top, int Bottom, Color BackColor = default(Color), Color TextColor = default(Color))
        {
            List.Add(Button(Expression, (object sender, ExpressionEventArgs e) =>
            { Calculator_Expression.Add(e.Expression); Calculator_Changed(); }, Name, BackColor, TextColor), Left, Right, Top, Bottom);
        }
        #endregion
        private void Calculator_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((Entry)sender).Text != Calculator_Value) { ((Entry)sender).Text = Calculator_Value; }
        }
        string Calculator_Free_Value = "";
        public StackLayout Calculator_Free
        {
            get
            {
                Editor Editor = new Editor
                {
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.FromRgb(0xD0, 0xD0, 0xD0)
                };
                Entry Entry = new Entry
                {
                    TextColor = Color.Black,
                    Placeholder = "Result",
                    PlaceholderColor = Color.Gray,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                Entry.TextChanged += Calculator_Free_TextChanged;
                return new StackLayout
                {
                    Children =
                    {Editor,
                    Button("Evaluate", delegate { Calculator_Free_Value = Evaluate(Editor.Text, this);
                        Calculator_Free_TextChanged(Entry, new TextChangedEventArgs(Entry.Text, Calculator_Free_Value)); }),
                    Entry
                    }
                };
            }
        }

        private void Calculator_Free_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((Entry)sender).Text != Calculator_Free_Value) { ((Entry)sender).Text = Calculator_Free_Value; }
        }

        string Factorizer_Root1 = "";
        string Factorizer_Root2 = "";
        string Factorizer_Result = "";
        public StackLayout Factorizer
        {
            get
            {
                Entry C1 = Entry("", "Coefficient");
                Entry C2 = Entry("", "Coefficient");
                Entry C3 = Entry("", "Coefficient");
                Entry R1 = Entry(Factorizer_Root1, "First Root", delegate { return Factorizer_Root1; });
                Entry R2 = Entry(Factorizer_Root1, "Second Root", delegate { return Factorizer_Root2; });
                Entry F = Entry(Factorizer_Root1, "Factorized Result", delegate { return Factorizer_Result; });
                return new StackLayout
                {
                    Children = {
                        Row(C1, (Text)"X²+"),
                        Row(C2, (Text)"XY+"),
                        Row(C3, (Text)"Y²"),
                        Button("Factorize", delegate { })
                    }
                };
            }
        }
    }
}
