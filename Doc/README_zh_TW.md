<div align="center"><strong>

# TwitterAccountMediaDownload

</strong></div>

[![GitHub license](https://img.shields.io/github/license/JDDKCN/TwitterAccountMediaDownload)](https://github.com/JDDKCN/TwitterAccountMediaDownload/blob/main/LICENSE)
[![GitHub stars](https://img.shields.io/github/stars/JDDKCN/TwitterAccountMediaDownload)](https://github.com/JDDKCN/TwitterAccountMediaDownload/stargazers)
[![Github All Releases](https://img.shields.io/github/downloads/JDDKCN/TwitterAccountMediaDownload/total.svg)](https://github.com/JDDKCN/TwitterAccountMediaDownload/releases)
[![GitHub release](https://img.shields.io/github/v/release/JDDKCN/TwitterAccountMediaDownload)](https://github.com/JDDKCN/TwitterAccountMediaDownload/releases/latest)
[![QQ Group](https://pub.idqqimg.com/wpa/images/group.png)](http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=_-W8U_Mrz_nOu3eD_u3VGiPICKe9t7zY&authKey=rB2PW5mIrIY3ARjMqqWtw%2F2Qpejm5EArmuy95Wq1GfC7gLzUzTRATTnULKUKtb76&noverify=0&group_code=1140538395)

![Github](https://socialify.git.ci/JDDKCN/TwitterAccountMediaDownload/image?description=1&forks=1&issues=1&language=1&logo=https%3A%2F%2Favatars.githubusercontent.com/u/103011451?v=4&name=1&owner=1&pulls=1&stargazers=1&theme=Light)

<div align="center"><strong>

[🇨🇳簡體中文](../README.md) | 🇹🇼繁體中文 | [🇺🇸English](./README_en_US.md) | [🇯🇵日本語](./README_ja_JP.md)

</strong></div>

## 📘 項目介紹

本項目是為 `Twitter (X)` 編寫的賬號點贊、書籤等媒體的爬蟲下載器。程序內核與GUI均使用 `.NET9` 構建。 本項目使用 `A-GPLv3` 開源協議。

### ✨ 實現功能
- 自訂抓取帳號按讚、書籤或全部內容的媒體檔案。
- 自訂抓取單一帳號、單一推文的媒體檔案。(新功能)
- 自訂下載類型，可多選圖片、影片、動圖。(新功能)
- 自訂推文過濾設定，支援關鍵字過濾、時間區間推文過濾。(新功能)
- 自訂連線逾時及下載重試設定。(新功能)
- 自動的下載資料統計。(新功能)
- 支援斷點續傳及增量更新，每次執行會依據上次進度繼續抓取。
- 簡便的代理伺服器設定。
- 重新設計的友善圖形介面，新手用戶更容易上手。(新功能)
- Core及GUI專案的完整多語系支援。(新功能)
- 下載內容自動分類，為每位用戶建立獨立資料夾儲存檔案。媒體檔案使用推文內容前25字作為檔名。(新功能)
- 簡單的詮釋資料(MetaData)管理功能。(新功能)

### 🐱 作者的話
> 因為大家的debug&issues，軟件才能越來越完善，歡迎Pr！將來可能還會寫一些方便的新功能，敬請期待喵！
>
> 歡迎加入QQ交流群 **1140538395** 反饋Bug。

### 🖼️ 軟件截圖

| ![APP_GUI](./images/image04.png) |
|:--:|
| **軟件界面 (TAMDownload.GUI)** |

| ![APP_Core](./images/image05.png) |
|:--:|
| **軟件界面 (TAMDownload.Core)** |

## 💾 軟件下載

### 下載二進制分發文件 (開箱即用)
請到最新 [**Releases**](https://github.com/JDDKCN/TwitterAccountMediaDownload/releases/) 處下載。

### 通過源代碼自行構建
請下載 [**項目源碼**](https://github.com/JDDKCN/TwitterAccountMediaDownload/archive/refs/heads/main.zip) 自行編譯，需要 `Visual Studio` 與 `.NET 9` 開發環境。

## 🚀 快速入門 · 賬號Cookies獲取

| ![APP_Core](./images/image01.png) |
|:--:|
| **Cookies獲取示意圖** |

1. 首先在瀏覽器中登錄賬號
2. 進入<個人資料>頁面，點擊 `喜歡的內容`
3. 停留在此頁面，按 `F12` 或 `Fn+F12` 喚出開發者工具
4. 在開發者工具頂欄中找到並進入 `網絡 (Internet)` 項
5. 點擊篩選欄右側的 `Fetch/XHR` 篩選按鈕，在篩選欄左側的過濾器輸入框中輸入 `like`
6. 點擊過濾出的項，查看右側 `標頭` 項的 `請求標頭` - `Cookie`
7. 複製完整Cookie文字到控制台中即可

## 🖥️ 系統支持

| 系統 | 可用性 | 支持版本 |
|------|--------|---------|
| Windows | 完整支持 (Windows 10 及以上版本) | x86、x64、Arm、Arm64 |
| Linux | 僅支持內核運行 | x64、Arm、Arm64 |
| Mac OS | 僅支持內核運行 | x64、Arm64 |

> - Linux與Mac OS未經實際編譯測試，不保證可用性。

## ⚠️ 免責聲明
本項目僅供研究交流用，禁止用於商業及非法用途。使用本項目造成的事故與損失，與作者無關。本項目完全免費，如果您是花錢買的，説明您被騙了。請儘快退款，以減少您的損失。

## 🌐 其他平台
前往我的 [**B站主頁**](https://space.bilibili.com/475547854/) : 劇毒的KCN

關注我的 [**Twitter賬號**](https://twitter.com/2233KCN03) : @2233kcn03

加入我的 [**QQ交流群**](http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=_-W8U_Mrz_nOu3eD_u3VGiPICKe9t7zY&authKey=rB2PW5mIrIY3ARjMqqWtw%2F2Qpejm5EArmuy95Wq1GfC7gLzUzTRATTnULKUKtb76&noverify=0&group_code=1140538395) : 1140538395