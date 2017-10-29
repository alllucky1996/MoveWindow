// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// ウィンドウを移動する
/// </summary>
namespace MoveWindow {

    using System;

    internal class Program {

        private static int Main(string[] args) {
            var options = new Options();
            if (!CommandLine.Parser.Default.ParseArguments(args, options)) {
                if (options.Verbose) {
                    Console.WriteLine("CommandLine Parse Error!");
                }

                return 1;
            }

            NativeMethods.MoveWindowEx(options.WindowTitle, options.X, options.Y, options.Width, options.Height);

            return 0;
        }
    }
}