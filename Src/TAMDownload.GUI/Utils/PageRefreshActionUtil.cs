namespace TAMDownload.GUI.Utils
{
    internal class PageRefreshActionUtil
    {
        /// <summary>
        /// 页面刷新通知事件
        /// </summary>
        public static event Action PageRefreshed;

        /// <summary>
        /// 触发页面刷新事件
        /// </summary>
        public static void TriggerPageRefresh()
        {
            PageRefreshed?.Invoke();
        }
    }
}
