using static TAMDownload.Config.Cookie.CookiesSelectConfig;

namespace TAMDownload.Config.Cookie
{
    public class CookiesSelectHelper
    {
        /// <summary>
        /// 添加Cookie配置
        /// </summary>
        /// <param name="accountName">Twitter账户名</param>
        /// <param name="cookie">Cookie值</param>
        /// <returns>新增配置的ID</returns>
        public string Add(string accountName, string cookie, bool isActive = false)
        {
            var config = ReadConfig();
            config.SelectedCookies ??= new List<CookiesConfig>();

            var newConfig = new CookiesConfig
            {
                ID = Guid.NewGuid().ToString("N"),
                AccountName = accountName,
                Cookie = cookie
            };

            config.SelectedCookies.Add(newConfig);

            if (isActive)
                config.SelectedID = newConfig.ID;

            SaveConfig(config);
            return newConfig.ID;
        }

        /// <summary>
        /// 删除Cookie配置
        /// </summary>
        /// <param name="id">要删除的配置ID</param>
        /// <returns>是否删除成功</returns>
        public bool Delete(string id)
        {
            var config0 = ReadConfig();
            if (config0.SelectedCookies == null)
                return false;

            var config = config0.SelectedCookies.FirstOrDefault(x => x.ID == id);
            if (config == null)
                return false;

            config0.SelectedCookies.Remove(config);

            if (config0.SelectedID == id)
                config0.SelectedID = null;

            SaveConfig(config0);
            return true;
        }

        /// <summary>
        /// 查找Cookie配置
        /// </summary>
        /// <param name="id">配置ID</param>
        /// <returns>Cookie配置信息</returns>
        public CookiesConfig? Find(string id)
        {
            var config = ReadConfig();
            if (config.SelectedCookies == null)
                return null;
            return config.SelectedCookies.FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// 根据账户名查找Cookie配置
        /// </summary>
        /// <param name="accountName">Twitter账户名</param>
        /// <returns>Cookie配置信息</returns>
        public CookiesConfig? FindByAccountName(string accountName)
        {
            var config = ReadConfig();
            if (config.SelectedCookies == null)
                return null;
            return config.SelectedCookies.FirstOrDefault(x => x.AccountName == accountName);
        }

        /// <summary>
        /// 更新选中项ID
        /// </summary>
        /// <param name="selectedID"></param>
        public void UpdateSelectedID(string selectedID)
        {
            var config = ReadConfig();
            config.SelectedID = selectedID;
            SaveConfig(config);
        }

        /// <summary>
        /// 根据账户名更新选中项ID
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public bool UpdateSelectedIDByAccountName(string accountName)
        {
            CookiesConfig? id = FindByAccountName(accountName);
            if (id == null || string.IsNullOrEmpty(id.ID))
                return false;
            UpdateSelectedID(id.ID);
            return true;
        }

        /// <summary>
        /// 更新指定ID的Cookie
        /// </summary>
        /// <param name="id">配置ID</param>
        /// <param name="newCookie">新的Cookie值</param>
        /// <returns>更新是否成功</returns>
        public bool UpdateItemCookie(string id, string newCookie)
        {
            var config = ReadConfig();
            if (config.SelectedCookies == null)
                return false;

            var cookieConfig = config.SelectedCookies.FirstOrDefault(x => x.ID == id);
            if (cookieConfig == null)
                return false;

            cookieConfig.Cookie = newCookie;
            SaveConfig(config);
            return true;
        }

        /// <summary>
        /// 根据账户名更新指定ID的Cookie
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public bool UpdateItemCookieByAccountName(string accountName, string newCookie)
        {
            CookiesConfig? id = FindByAccountName(accountName);
            if (id == null || string.IsNullOrEmpty(id.ID))
                return false;
            UpdateItemCookie(id.ID, newCookie);
            return true;
        }

    }
}
