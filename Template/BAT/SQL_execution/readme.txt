SQL ServerにSQLファイルの作業を行うバッチファイル。
あんまり使うときなかったけど、顧客がＰＣ知識とかなくて
「ほよよ？？？？ＳＳＭＳ？？パス？？なにそれ～」
ってなってる時にはある程度有効。

今回のファイルはSQL Server接続情報を手入力にしてるけど、もちろん予め定義しておくことも可能。
てか、その方がいいと思う。
その場合注意しとかなきゃいけないことは顧客から貰った接続情報が本当に正しいのかどうか。
もちろん、接続情報が間違ってると53エラーが出るので注意。