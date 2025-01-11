using Sunny.UI;
using System.Runtime.InteropServices;
using TAMDownload.Config.Language;

namespace TAMDownload.GUI.Utils
{
    internal class KUI
    {
        [DllImport("user32.dll")]
        private static extern IntPtr MonitorFromPoint(Point pt, uint dwFlags);

        [DllImport("Shcore.dll")]
        private static extern int GetDpiForMonitor(IntPtr hmonitor, int dpiType, out uint dpiX, out uint dpiY);

        const int MDT_EFFECTIVE_DPI = 0;

        public static Point ScreenCentralLocation(Form form) => GetScreenCentralLocation(form);

        private static Point GetScreenCentralLocation(Form form)
        {
            IntPtr hMonitor = MonitorFromPoint(form.Location, 2);

            _ = GetDpiForMonitor(hMonitor, MDT_EFFECTIVE_DPI, out uint dpiX, out uint dpiY);

            float scaleFactorX = dpiX / 96.0f;
            float scaleFactorY = dpiY / 96.0f;

            Rectangle workingArea = Screen.FromHandle(form.Handle).WorkingArea;
            int centerX = (int)(workingArea.Left + (workingArea.Width / 2) / scaleFactorX);
            int centerY = (int)(workingArea.Top + (workingArea.Height / 2) / scaleFactorY);

            return new Point(centerX, centerY);
        }

        public static void Error(string msg)
        {
            Sunny.UI.UIForm form = new Sunny.UI.UIForm();
            form.Location = ScreenCentralLocation(form);
            form.ShowErrorDialog2(LanguageHelper.CurrentLanguage.GUIMessage.Error, msg);
        }

        public static void Error(string msg, string title)
        {
            Sunny.UI.UIForm form = new Sunny.UI.UIForm();
            form.Location = ScreenCentralLocation(form);
            form.ShowErrorDialog2(title, msg);
        }

        public static void Warning(string msg)
        {
            Sunny.UI.UIForm form = new Sunny.UI.UIForm();
            form.Location = ScreenCentralLocation(form);
            form.ShowWarningDialog2(LanguageHelper.CurrentLanguage.GUIMessage.Warn, msg);
        }

        public static void Warning(string msg, string title)
        {
            Sunny.UI.UIForm form = new Sunny.UI.UIForm();
            form.Location = ScreenCentralLocation(form);
            form.ShowWarningDialog2(title, msg);
        }

        public static void OK(string msg)
        {
            Sunny.UI.UIForm form = new Sunny.UI.UIForm();
            form.Location = ScreenCentralLocation(form);
            form.ShowSuccessDialog2(LanguageHelper.CurrentLanguage.GUIMessage.Success, msg);
        }

        public static void OK(string msg, string title)
        {
            Sunny.UI.UIForm form = new Sunny.UI.UIForm();
            form.Location = ScreenCentralLocation(form);
            form.ShowSuccessDialog2(title, msg);
        }

        public static void Info(string msg)
        {
            Sunny.UI.UIForm form = new Sunny.UI.UIForm();
            form.Location = ScreenCentralLocation(form);
            form.ShowInfoDialog2(LanguageHelper.CurrentLanguage.GUIMessage.Info, msg);
        }

        public static void Info(string msg, string title)
        {
            Sunny.UI.UIForm form = new Sunny.UI.UIForm();
            form.Location = ScreenCentralLocation(form);
            form.ShowInfoDialog2(title, msg);
        }

        public static bool ShowBool(string msg, string title, UIStyle style = UIStyle.Blue, bool showMask = false, UIMessageDialogButtons defaultButton = UIMessageDialogButtons.Cancel, int delay = 0)
        {
            using UIMessageForm2 uIMessageForm = new UIMessageForm2(title, msg, UINotifierType.Ask, defaultButton);

            uIMessageForm.Delay = delay;
            uIMessageForm.StyleCustomMode = true;
            uIMessageForm.Style = style;
            uIMessageForm.StartPosition = FormStartPosition.CenterScreen;
            uIMessageForm.Location = ScreenCentralLocation(uIMessageForm);
            uIMessageForm.ShowInTaskbar = false;
            uIMessageForm.TopMost = true;
            uIMessageForm.Render();

            return showMask ? (uIMessageForm.ShowDialogWithMask() == DialogResult.OK) 
                : (uIMessageForm.ShowDialog() == DialogResult.OK);
        }
    }
}
