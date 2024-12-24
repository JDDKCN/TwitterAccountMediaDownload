using Sunny.UI;

namespace TAMDownload.GUI.Utils
{
    internal class ShowTipUtil
    {
        /// <summary>
        /// 提示气泡对象
        /// </summary>
        public static readonly UIToolTip TTip = new UIToolTip();

        /// <summary>
        /// 在指定控件上显示提示气泡
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="control">控件</param>
        public static void ShowTip(string message, Control control)
        {
            try
            {
                TTip.Show(message, control, 0, control.Size.Height, 3000);
            }
            catch (Exception ex)
            {
                UIForm uIForm = new UIForm();
                uIForm.ShowErrorDialog(ex.Message, message);
                return;
            }
        }
    }
}
