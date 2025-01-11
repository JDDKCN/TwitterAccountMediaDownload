using TAMDownload.Config.Language;

namespace TAMDownload.GUI.Utils
{
    internal class InputChecker
    {
        public static bool TextCheck(Control userControl)
        {
            if (string.IsNullOrEmpty(userControl.Text))
            {
                ShowTipUtil.ShowTip(LanguageHelper.CurrentLanguage.GUIMessage.TextCheckErrTips, userControl);
                return false;
            }
            return true;
        }

        public static bool NumCheck(Control userControl)
        {
            if (!int.TryParse(userControl.Text, out int value))
            {
                ShowTipUtil.ShowTip(LanguageHelper.CurrentLanguage.GUIMessage.NumCheckErrTips, userControl);
                return false;
            }
            return true;
        }
    }
}
