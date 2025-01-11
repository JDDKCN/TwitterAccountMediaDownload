namespace TAMDownload.Config.Language
{
    public class LanguageConfig
    {
        public LanguageConfig()
        {
            GUIMessage = new GUIMessageConfig();
            CoreMessage = new CoreMessageConfig();
        }

        public string LanguageName { get; set; } = "简体中文";
        public string LanguageCode { get; set; } = "zh_CN";

        public GUIMessageConfig GUIMessage { get; set; }
        public CoreMessageConfig CoreMessage { get; set; }

        public class GUIMessageConfig
        {
            public string Success { get; set; } = "成功";
            public string Error { get; set; } = "错误";
            public string Warn { get; set; } = "警告";
            public string Info { get; set; } = "信息";
            public string Add { get; set; } = "新建";
            public string Del { get; set; } = "删除";
            public string Enable { get; set; } = "启用";
            public string Disable { get; set; } = "禁用";

            public string MediaSaveDirPath { get; set; } = "下载媒体保存路径";
            public string SelectPath { get; set; } = "选择路径";
            public string GetTypes { get; set; } = "获取内容类型";
            public string DownloadTypes { get; set; } = "下载内容类型";
            public string EnableProxy { get; set; } = "启用代理";
            public string StartDownload { get; set; } = "开始下载";
            public string Downloading { get; set; } = "正在下载";
            public string CookiesSettingMenu { get; set; } = "Cookies设置菜单";
            public string FilterTweetSettingMenu { get; set; } = "推文过滤设置菜单";
            public string MetadataManager { get; set; } = "MetaData数据管理";
            public string UsingAccount { get; set; } = "当前使用账户";
            public string BookMarks { get; set; } = "书签内容";
            public string Likes { get; set; } = "点赞内容";
            public string AllTypes { get; set; } = "全部内容";
            public string AccountType { get; set; } = "单用户媒体内容";
            public string TweetType { get; set; } = "单推文媒体内容";
            public string UserNameOrTweetID { get; set; } = "用户名或推文ID";

            public string Photos { get; set; } = "图片";
            public string Videos { get; set; } = "视频";
            public string Gifs { get; set; } = "动图";
            public string Setting { get; set; } = "设置";
            public string TimeOut { get; set; } = "连接超时时间(s)";
            public string RetryTime { get; set; } = "单任务失败重试次数";
            public string TwitterAccountNickName { get; set; } = "Twitter用户名";
            public string ApplyChanges { get; set; } = "保存并使用";
            public string HandBook { get; set; } = "说明文档";
            public string NoUserSelected { get; set; } = "未选择用户";
            public string FilterBlockedWords { get; set; } = "屏蔽词过滤";
            public string FilterDateRange { get; set; } = "时间段过滤";
            public string BlockedWords { get; set; } = "屏蔽词";
            public string SetStartDate { get; set; } = "设置起始日期";
            public string SetEndDate { get; set; } = "设置截止日期";

            public string ConfigErrTips { get; set; } = "配置加载失败，请重置配置文件。";
            public string MediaTypeNoSelectErrTips { get; set; } = "请至少选择一项下载内容！";
            public string CoreNoExistErrTips { get; set; } = "下载内核程序不存在，无法进行下载操作。\n请尝试重装程序以解决该问题。";
            public string TextCheckErrTips { get; set; } = "此处不得为空！";
            public string NumCheckErrTips { get; set; } = "请填写数字！";
            public string DelWarnTips { get; set; } = "您确认要删除 {0} 吗？";
            public string GetCookiesHandBook { get; set; } = "1. 首先在浏览器中登录账号。\r\n2. 进入 `个人资料` 页面，点击 `喜欢的内容` 。\r\n3. 停留在此页面，按 `F12` 或 `Fn+F12` 唤出开发者工具。\r\n4. 在开发者工具顶栏中找到并进入 `网络 (Internet)` 项。\r\n5. 点击筛选栏右侧的 `Fetch/XHR` 筛选按钮，在筛选栏左侧的过滤器输入框中输入 `like` 。\r\n6. 点击过滤出的项，查看右侧 `标头` 项的 `请求标头` - `Cookie` 。\r\n7. 复制完整Cookie文字到控制台中即可。\r\n";
            public string GetUserScreenNameAndTweetIDHandBook { get; set; } = "1. 对于 `单用户媒体内容` : 请填入@后面由数字和英文字母组成的用户名称，如 `剧毒的KCN @2233KCN03` 填入 `2233KCN03` 。\r\n\r\n2. 对于 `单推文媒体内容` : 请填入推文分享链接尾部的纯数字ID，如 `https://x.com/2233kcn03/status/1234567890987654321` 填入 `1234567890987654321` 。";

        }

        public class CoreMessageConfig
        {
            public string GetTypesMode { get; set; } = "获取模式";
            public string DownloadStatistics { get; set; } = "下载数据统计: 共下载 {0} 个文件，图片 {1} 张，视频 {2} 个，GIF {3} 张。";
            public string GetTypesStart { get; set; } = "开始获取";
            public string GetPages { get; set; } = "正在获取页面";
            public string HomePage { get; set; } = "首页";
            public string GetNextPages { get; set; } = "准备获取下一页...";
            public string GetLastPages { get; set; } = "已到达最后一页";
            public string GetTweetTaskCompleted { get; set; } = "任务完成，共处理 {0} 条推文";
            public string DownloadTweetMediaTaskStart { get; set; } = "开始下载第 {0} 条推文的媒体文件...";
            public string GetPagesNoNewMedia { get; set; } = "当前页面没有新的媒体内容";
            public string GetMediaByThisPage { get; set; } = "本页获取到 {0} 条推文";
            public string GetMediaByUserAccount { get; set; } = "开始获取用户 {0} 的媒体内容...";
            public string FileIsExist { get; set; } = "文件已存在";
            public string FileDownloadTaskCompleted { get; set; } = "下载完成";
            public string FileDownloadTaskErrorRetry { get; set; } = "下载失败: {0} (已重试 {1} 次)";
            public string FileDownloadTaskErrorRetry2 { get; set; } = "下载失败: {0} (尝试 {1}/{2}) : {3}";
            public string FileDownloadTaskErrorTimeOut { get; set; } = "下载超时";
            public string FileDownloadTaskError { get; set; } = "下载出错";
            public string EnterCookies { get; set; } = "未找到预设Cookie，请输入Cookie";
            public string CookiesByAccount { get; set; } = "进行下载操作的账号";
            public string GetUserAccountID { get; set; } = "获取用户ID";
            public string SkipBlockedWordsTweet { get; set; } = "发现屏蔽词 {0} ，跳过此推文 ( {1} )。";
            public string SkipDateRangeTweet { get; set; } = "时间段不匹配 {0} ，跳过此推文 ( {1} )。";

            public string ConvertingTweets { get; set; } = "正在转换 {0} 条推文到元数据";
            public string AvailableUsers { get; set; } = "可用用户数: {0}";
            public string ProcessingTweet { get; set; } = "正在处理推文 {0}";
            public string UserNotFound { get; set; } = "未找到推文 {0} 的用户";
            public string CreatedNewUserEntry { get; set; } = "已为用户 {0} 创建新条目";
            public string AddedTweetForUser { get; set; } = "已添加用户 {0} 的推文";
            public string MetadataConversionComplete { get; set; } = "元数据转换完成。用户数量: {0}";

            public string ProcessingEntry { get; set; } = "正在处理条目: {0}";
            public string AddedTweet { get; set; } = "已添加推文: {0}";
            public string FoundNextPage { get; set; } = "已找到下一页: {0}";
            public string ProcessedTweetsCount { get; set; } = "已处理 {0} 条推文";
            public string ProcessingTweetFromUser { get; set; } = "正在处理用户 {0} 的推文";

            public string DownloadConfigIsEmptyTips { get; set; } = "下载内容配置为空！";
            public string UnknownGetTypesModeTips { get; set; } = "未知的获取模式，请检查配置文件。";
            public string UnknownGetUserAccountMsgTips { get; set; } = "未获取到此Twitter用户名的对应账号信息，请检查您填入的信息是否有误。请填入 @ 后的由英文、数字组成的用户唯一名称。";

        }
    }
}
