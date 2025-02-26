# BveZuikiDenshadeGoControllerInterface

BVE Trainsimで瑞起製「電車でGO!!」コントローラーを使用するためのプラグインです。

## 概要

このプラグインを使用することで、BVE Trainsimで瑞起製の「電車でGO!!」コントローラーを操作デバイスとして使用できます。

## 対応環境

* BVE Trainsim [BVE5.8 及び BVE6以降]
* 瑞起製「電車でGO!!」コントローラー
* .NET Framework 3.5 (BVE5.8)
* .NET Framework 4.8 (BVE6以降)

## インストール手順

1.  [リリースページ](https://github.com/ricald/BveZuikiDenshadeGoControllerInterface/releases)から最新の`Ricald.ZuikiMasconInterface.dll`をダウンロードします。
2.  ダウンロードしたDLLファイルをBVE Trainsimのバージョンに合わせて、以下のフォルダにコピーします。
    * BVE5.8の場合:
        * `Ricald.ZuikiMasconInterface.dll (.NET Framework 3.5)` を `C:\Program Files (x86)\mackoy\BveTs5\Input Devices` にコピーします。
    * BVE6の場合:
        * `Ricald.ZuikiMasconInterface.dll (.NET Framework 4.8)` を `C:\Program Files\mackoy\BveTs6\Input Devices` にコピーします。

## 使用方法

1.  BVE Trainsimを起動します。
2.  右クリックメニューの設定画面を開きます。
3.  入力デバイスタブを開き、「ZuikiMasconBvePlugin」にチェックを入れて、OKを押下します。

## コントローラー設定

### コントローラーのボタン配置

* マスコン:
    * EB: 非常ブレーキ
    * B8-B1: ブレーキ8-1
    * N: ノッチオフ
    * P1-P5: 力行1-5
* Yボタン: 定速運転
* Bボタン: 電笛
* Aボタン: 空笛
* Xボタン: EBリセット
* ↑ボタン: レバーサ前進
* ↓ボタン: レバーサ後退
* -ボタン: 時刻表表示切り替え
* Homeボタン: ATS復帰

## 開発環境

* .NET Framework 3.5 (BVE5.8)
* .NET Framework 4.8 (BVE6以降)

## ライセンス

このソフトウェアはMIT Licenseの下で公開されています。
