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

[🇨🇳简体中文](../README.md) | [🇹🇼繁體中文](./README_zh_TW.md) | [🇺🇸English](./README_en_US.md) | 🇯🇵日本語

</strong></div>

## 📘 プロジェクト紹介

本プロジェクトは `Twitter (X)` のアカウントのいいね、ブックマークなどのメディアをダウンロードするクローラーです。プログラムのコアとGUIは `.NET9` で構築されています。`A-GPLv3` ライセンスのもとでオープンソース化されています。

### ✨ 主な機能
- アカウントのいいね、ブックマーク、または全コンテンツのメディアファイルを自由にクロール。
- 単一アカウントや単一ツイートのメディアファイルを選択的にクロール。(新機能)
- 画像、動画、GIF画像を複数選択可能なダウンロード種別設定。(新機能)
- キーワードブロックや期間指定によるツイートフィルタリング設定。(新機能)
- 接続タイムアウトとダウンロード再試行の詳細設定。(新機能)
- ダウンロード統計の自動追跡。(新機能)
- 中断点からの再開と差分更新に対応。前回の進捗状況から継続してクロール可能。
- シンプルなプロキシ設定。
- 初心者でも使いやすい新デザインのGUIインターフェース。(新機能)
- CoreとGUIプロジェクトの完全な多言語対応。(新機能)
- コンテンツの自動分類。ユーザーごとに個別フォルダを作成し、メディアファイルはツイート本文の先頭25文字をファイル名として使用。(新機能)
- 基本的なメタデータ管理機能。(新機能)

### 🐱 開発者より
> みなさんのデバッグレポートとissuesのおかげで、ソフトウェアは日々改善されています。PRも大歓迎です！今後も便利な新機能を追加していく予定ですので、お楽しみに！
>
> バグ報告はQQグループ **1140538395** にご参加ください。

### 🖼️ スクリーンショット

| ![APP_GUI](./images/image04.png) |
|:--:|
| **ソフトウェアインターフェース (TAMDownload.GUI)** |

| ![APP_Core](./images/image05.png) |
|:--:|
| **ソフトウェアインターフェース (TAMDownload.Core)** |

## 💾 ダウンロード

### バイナリ配布ファイルのダウンロード（すぐに使用可能）
最新の [**Releases**](https://github.com/JDDKCN/TwitterAccountMediaDownload/releases/) からダウンロードしてください。

### ソースコードからビルド
[**プロジェクトのソースコード**](https://github.com/JDDKCN/TwitterAccountMediaDownload/archive/refs/heads/main.zip) をダウンロードし、`Visual Studio` と `.NET 9` 開発環境でビルドしてください。

## 🚀 クイックスタート · アカウントのCookies取得

| ![APP_Core](./images/image01.png) |
|:--:|
| **Cookies取得の説明図** |

1. まずブラウザでアカウントにログインします
2. <プロフィール>ページに移動し、`いいね`をクリックします
3. そのページで `F12` または `Fn+F12` を押して開発者ツールを開きます
4. 開発者ツールの上部で `ネットワーク (Network)` タブを見つけて開きます
5. フィルターバーの右側にある `Fetch/XHR` フィルターをクリックし、左側の検索ボックスに `like` と入力します
6. フィルタリングされた項目をクリックし、右側の `ヘッダー` の `リクエストヘッダー` から `Cookie` を確認します
7. Cookie全文をコンソールにコピーして使用します

## 🖥️ システム対応

| OS | 対応状況 | サポートバージョン |
|------|--------|---------|
| Windows | 完全対応 (Windows 10以降) | x86、x64、Arm、Arm64 |
| Linux | コアのみ対応 | x64、Arm、Arm64 |
| Mac OS | コアのみ対応 | x64、Arm64 |

> - LinuxとMac OSは実際のテストは行っていないため、動作は保証できません。

## ⚠️ 免責事項
本プロジェクトは研究・交流目的のみで使用可能です。商業利用および違法な目的での使用は禁止されています。本プロジェクトの使用によって生じた事故や損失について、作者は一切の責任を負いません。本プロジェクトは完全無料です。もし有料で購入された場合は詐欺の被害に遭っています。損失を最小限に抑えるため、速やかに返金を求めてください。

## 🌐 その他のプラットフォーム
[**Bilibili**](https://space.bilibili.com/475547854/) : 剧毒的KCN

[**Twitter**](https://twitter.com/2233KCN03) : @2233kcn03

[**QQグループ**](http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=_-W8U_Mrz_nOu3eD_u3VGiPICKe9t7zY&authKey=rB2PW5mIrIY3ARjMqqWtw%2F2Qpejm5EArmuy95Wq1GfC7gLzUzTRATTnULKUKtb76&noverify=0&group_code=1140538395) : 1140538395