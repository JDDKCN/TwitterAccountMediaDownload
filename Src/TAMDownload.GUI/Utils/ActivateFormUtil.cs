using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TAMDownload.GUI.Utils
{
    public class ActivateFormUtil
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_RESTORE = 9;

        /// <summary>
        /// 激活现有窗体
        /// </summary>
        public static bool ActivateForm()
        {
            try
            {
                string processName = Process.GetCurrentProcess().ProcessName;
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;

                foreach (Process process in Process.GetProcessesByName(processName))
                {
                    if (process.MainWindowHandle != handle)
                    {
                        // 将窗体恢复到正常状态才能用SetForegroundWindow函数
                        ShowWindow(process.MainWindowHandle, SW_RESTORE);
                        SetForegroundWindow(process.MainWindowHandle);
                        Application.Exit();
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                return true;
            }
        }
    }
}
