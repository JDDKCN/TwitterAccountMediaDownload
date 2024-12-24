namespace TAMDownload.GUI.Utils
{
    internal class InputChecker
    {
        public static bool TextCheck(Control userControl)
        {
            if (string.IsNullOrEmpty(userControl.Text))
            {
                ShowTipUtil.ShowTip("此处不得为空！", userControl);
                return false;
            }
            return true;
        }
    }
}
