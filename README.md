# Simline2 - ASP.NET Core 3.0 Server


本リファレンスは登記・供託オンライン申請システムAPIリファレンスとなります。

登記・供託オンライン申請システムAPIを利用することで、オンライン申請、処理状況の確認、公文書取得等を行うことができます。

本リファレンスは「API一覧」と「リクエスト・レスポンス一覧」で構成されており、それぞれ以下の内容を記しています。

■API一覧
  
  各APIの仕様について記しています。

■リクエスト・レスポンス一覧
  
  各APIのリクエスト及びレスポンスの構造や各API共通で扱う共通エラーレスポンスの構造を記しています。なお、Exampleの値はSwaggerファイルと異なる表記となる場合がありますので、別途提供するSwaggerファイルをあわせて確認してください。

共通エラーレスポンスは以下の4種類です。詳細についてはリクエスト・レスポンス一覧の内容を確認してください。

  ・HTTP403（Forbidden）

  ・HTTP404（Not Found）
  
  ・HTTP500（Internal Server Error）
  
  ・HTTP503（Service unavailable）
  


## Run

Linux/OS X:

```
sh build.sh
```

Windows:

```
build.bat
```
## Run in Docker

```
cd src/Simline2
docker build -t simline2 .
docker run -p 5000:8080 simline2
```
