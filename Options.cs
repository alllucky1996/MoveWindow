namespace MoveWindow {

    using CommandLine;
    using CommandLine.Text;

    public class Options {

        [Option('t', "WindoTitle", Required = true, HelpText = "ウィンドウタイトル")]
        public string WindowTitle { get; set; }

        [Option('x', "x", Required = true, HelpText = "ウィンドウの新しいx座標")]
        public int X { get; set; }

        [Option('y', "y", Required = true, HelpText = "ウィンドウの新しいy座標")]
        public int Y { get; set; }

        [Option('w', "width", Required = true, HelpText = "ウィンドウの新しい幅")]
        public int Width { get; set; }

        [Option('h', "height", Required = true, HelpText = "ウィンドウの新しい高さ")]
        public int Height { get; set; }

        [Option('v', "verbose", DefaultValue = true, HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption(HelpText = "ヘルプを表示")]
        public string GetUsage() {
            // ヘッダーの設定
            HeadingInfo head = new HeadingInfo("MoveWindow", "Version 1.0");
            HelpText help = new HelpText(head);
            help.Copyright = new CopyrightInfo("Toru Fukuad", 2017);
            help.AddPreOptionsLine("ウィンドウを移動します");
            help.AddPreOptionsLine("構文の例: MoveWindow.exe -x0 -y0 -t Twitter");

            // 全オプションを表示(1行間隔)
            help.AdditionalNewLineAfterOption = true;
            help.AddOptions(this);

            return help.ToString();
        }
    }
}