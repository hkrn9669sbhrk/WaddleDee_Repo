@echo off

rem 正常終了
set resNormal=0
rem 異常終了
set resError=99
rem 出力するファイル名称_log
set fileNameLog=logdata.log
rem 出力するファイル名称_一時ファイル
set fileNameTxt=response.txt
rem sqlcmd接続情報
rem set sqlcmd=sqlcmd -S サーバー名 -d DB名 -U ユーザー名 -P パスワード -i

set /p SERVERNAME="Server name -> "
set /p USERNAME="User name -> "
set /p PASSWORD="Password -> "

set sqlcmd=sqlcmd -S %SERVERNAME% -U %USERNAME% -P %PASSWORD% -i

rem sqlパラメータ
set sqlParam=''

echo プログラムを実行します。
echo エンターキーを押してください。

rem 一時停止
pause

rem 画面メッセージのクリア
cls

rem -------処理記載------

rem SQLSERVERに接続
rem [実行するSQLファイルのパス]に実際のパスを入力

%sqlcmd% [実行するSQLファイルのパス] -v param=%sqlParam% -b -s, >> %fileNameLog%  2>&1

rem sqlcmd実行結果で処理を分岐
rem 0:正常終了 99:異常終了

if %errorlevel% equ 0 (
 echo 正常終了 > %fileNameLog%
 > %fileNameTxt% echo %resNormal%
)

 else (
 echo 異常終了 > %fileNameLog%
 type %~dp0\%fileNameLog%
 > %fileNameTxt% echo %resError%
)

rem -------処理記載------

echo プログラムが終了しました。

pause
exit