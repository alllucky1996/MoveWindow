/// <summary>
/// ウィンドウを移動する
/// </summary>
namespace MoveWindow {

    using System;
    using System.Diagnostics;
    using System.Linq;

    public static class NativeMethods {

        public static void MoveWindowEx(string title, int x, int y, int width, int height) {
            // 全てのプロセスから、ウィンドウタイトルが合致するものを取得
            Process[] p = FirstProcessWithWindowTitle(title);
            if (p.Length == 0) {
                return;
            }

            MoveWindow(p[0].MainWindowHandle, x, y, width, height, 1);
        }

        private static Process[] FirstProcessWithWindowTitle(string title) {
            return Process.GetProcesses().Where((it) => it.MainWindowTitle.ToLower().Contains(title.ToLower())).Take(1).ToArray();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hwnd, int x, int y, int nWidth, int nHeight, int bRepaint);
    }
}