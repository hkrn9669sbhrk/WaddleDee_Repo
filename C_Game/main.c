#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main(void)
{
	int event;
	int hp=100;
	int power=10;
	int speed=10;
	int defence=10;
	int luk;
	int damage;
	int loop=0;
	float time;
	
	int love1=0;
	int love2=0;
	int love3=0;
	
	//タイトル
	printf("\n\n\n\n\n\n\n\n\n\n\n\n\n                                                    はっくんげ-む\n\n\n\n\n\n\n\n                                                   クリックスタ-ト\n\n\n");
	getchar();
	
	
	//はじめに
	printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
	
	printf("こんにちは！僕はっくん！このゲ-ムの作者だよ！▽");
	getchar();
	
	printf("事前に伝えておかなきゃいけない事があったから この場を借りて言わせてもらうよ！▽");
	getchar();
	
	printf("このゲ-ムやン-スコ-ドは完全なフリ-だよ！著作権を放棄しているよ！▽");
	getchar();
	
	printf("だから自作発言やン-ス改変も自由だよ！自由に使ってね！▽");
	getchar();
	
	
	//注意書き
	printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
	printf("\n\n");
	printf("※開発環境の仕様の為、使用できない文字が多数あります。その為、ちょくちょくおかしいところがあります。\n");
	printf("　非常に見づらいと思いますが、上記二点の把握をお願い致します。脳内補完をしろ、脳内補完を。");
	getchar();
	
	
	//プロローグ
	printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
	
	printf("はっくん\n");
	printf("僕、はっくん！彼女欲しい！▽");
	getchar();
	
	printf("今日から高校二年生やし、頑張ってめんこい女と付き合うねん！▽");
	getchar();
	
	printf("\n※このゲ-ムのジャンルは育成恋愛です。ときメモ4と近いジャンルです。");
	getchar();
	
	printf("　はっくんのステ-タスをあげると、それに対応した女の子の好感度が上がっていきます。");
	getchar();
	
	printf("　なので、気に入った女の子がどのステ-タスを好きか見極めてステ-タス上げをするといいと思います。");
	getchar();
	
	
	//ここから育成になる。ループさせまくる。
	for(loop=0;loop<100;loop++){
		printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
		printf("%d日目\n\n",loop +1);
		
		printf("ステ-タス\n体力%d\n力　%d\n守　%d\n速　%d",hp,power,defence,speed);
		printf("\n\n");
		printf("はっくん\n今日は何をしようかな？▽");
		getchar();
		
		
	}
	
	//エンディング
	return 0;
}