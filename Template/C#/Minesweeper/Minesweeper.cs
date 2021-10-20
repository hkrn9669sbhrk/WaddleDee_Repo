// ■マインスイーパソースプログラム
//   ソースプログラムをコピー＆ペーストしたあと、Form1を選択状態にした状態で、
//   イベントハンドラを指定できるようにして、
//   （プロパティウィンドウでイベントアイコンをクリック)
//   Form1のMuseClickイベントハンドラをForm1_MouseClickに設定して下さい。
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace mineSweeper2
{
    public partial class Form1 : Form
    {
        public const int SZ = 20;         //  セルサイズ
        public const int S9 = SZ - 1;     //  (枠線表示用)セルサイズ-1
        public const int S8 = SZ - 2;     //  (枠線表示用)セルサイズ-2
        public Image image = new Bitmap(1000, 1000);//表示用ビットマップ
        public static Graphics g;             //  表示用グラフィックオブジェクト
        public mineSweeper mineS;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)//再表示
        {
            base.OnPaint(e); e.Graphics.DrawImage(image, 10, 10);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = Graphics.FromImage(image); mineS = new mineSweeper(10, 10, 10);
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {   //ゲーム中のときセル選択処理, 終わっているとき最初から処理
            if (mineS.exeMode) mineS.cellSelect((e.X - 10) / SZ, (e.Y - 10) / SZ);
            else mineS.Initialize();
            this.Invalidate();
            if(mineS.AX!=0) MessageBox.Show("残念！そこは爆弾です");
            else if (!mineS.exeMode) MessageBox.Show("終了です");
         }
        public class mineSweeper
        {
            public const int Bomb   = -100;   //  爆弾を示す定数
            public const int Hiden0 =  -50;   //  隠された個数0を示す定数
            public Boolean exeMode = true;    //  実行中フラグ
            public int AX, AY;                //  爆発場所（０のとき正常）
           
            private int numX;                 //  X方向のセル数
            private int numY;                 //　Y方向のセル数
            private int numB;                 //  爆弾の個数
            private int[,] DT;                //  状態を示す配列

            private Pen   pBlack   = new Pen(Color.Black     , 1);      　//ペン
            private Pen   pBlack2  = new Pen(Color.Black     , 2);         　
            private Pen   pWhite   = new Pen(Color.White     , 1);
            private Pen   pGray    = new Pen(Color.Gray      , 1);
            private Pen   pDGray   = new Pen(Color.DarkGray  , 1);
            private Pen   pLGray   = new Pen(Color.LightGray , 1);
            private Brush bRed     = new SolidBrush(Color.Red        ); 　// ブラシ
            private Brush bYellow  = new SolidBrush(Color.Yellow     );
            private Brush bLYellow = new SolidBrush(Color.LightYellow);
            private Brush bWhite   = new SolidBrush(Color.White      );
            private Brush bLGray   = new SolidBrush(Color.LightGray  );
            private Brush bBlack   = new SolidBrush(Color.Black      );
            private Brush bGreen   = new SolidBrush(Color.LightGreen );
            private Font font = new 
                Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            public mineSweeper(int NX, int NY, int NB)
            {
                numX = NX; numY = NY; numB = NB;
                DT = new int[numX + 2, numY + 2]; Initialize();
            }
            private int countB(int count, int X, int Y)// 爆弾の個数カウント
            {
                if (DT[X, Y] == Bomb) return count + 1; else return count;
            }
            private void setBomb(Random rn) //  爆弾の生成
            {
                int X, Y;
                do { X = rn.Next(numX) + 1; Y = rn.Next(numY) + 1; }
                while (DT[X, Y] == Bomb);
                DT[X, Y] = Bomb;
            }
            private void countSetNum(int X, int Y)
            {   //爆弾の数をカウントしてセットする。
                int count = 0;
                for (int i = X - 1; i <= X + 1; i++) for (int j = Y - 1; j <= Y + 1; j++)
                        if (i != X || j != Y) count = countB(count, i, j);
                if (count > 0) DT[X, Y] = -count;
            }
            public void Initialize() //　初期化
            {
                AX = 0; exeMode = true; Random rn = new Random();
                for (int X = 0; X < numX + 2; X++)　　　　　　//  初期値は隠された0とする
                    for (int Y = 0; Y < numY + 2; Y++) DT[X, Y] = Hiden0;
                for (int i = 0; i < numB; i++) setBomb(rn);   //  爆弾の生成
                for (int X = 1; X <= numX; X++)   　　　　　　//  周囲の爆弾の個数カウント
                    for (int Y = 1; Y <= numY; Y++)
                        if (DT[X, Y] != Bomb) countSetNum(X, Y);
                display();
            }
            private Boolean openCheck(Boolean sw, int X, int Y)　//  隠された0を開かれた0にする
            {                                                       // 開かれた0にしたらtrue
                if (DT[X, Y] == Hiden0) { DT[X, Y] = 0; return true; }
                else if (DT[X, Y] != Bomb & DT[X,Y]<0) DT[X, Y] = -DT[X, Y];
                return sw;
            }
            private Boolean UDLR(Boolean sw, int X, int Y)// 上下左右を検査
            {
                if (DT[X, Y] == 0) return openCheck(openCheck(openCheck(openCheck
                                  (sw, X, Y + 1), X, Y - 1), X - 1, Y), X + 1, Y);
                else return sw;
            }
            private void sweep()//掃き出し
            {
                Boolean sw = true; int X, Y;
                while (sw)
                {
                    sw = false;
                    for (X = 1; X <= numX; X++) for (Y = 1; Y <= numY; Y++) sw = UDLR(sw, X, Y);
                    for (Y = numY; Y >= 1; Y--) for (X = 1; X <= numX; X++) sw = UDLR(sw, X, Y);
                    for (X = numX; X >= 1; X--) for (Y = 1; Y <= numY; Y++) sw = UDLR(sw, X, Y);
                    for (Y = 1; Y <= numY; Y++) for (X = numX; X >= 1; X--) sw = UDLR(sw, X, Y);
      		    for (X = 1; X <= numX; X++) for (Y = 1; Y <= numY; Y++) 
			sw = openCheck(openCheck(openCheck(openCheck
                                  (sw, X-1, Y-1), X-1, Y + 1), X +1, Y-1), X + 1, Y+1);
             
                }
            }
            private Boolean continueCheck()// 終了のチェック
            {
                for (int X = 1; X <= numX; X++) for (int Y = 1; Y <= numY; Y++)
                        if (DT[X, Y] < 0 && DT[X, Y] != Bomb) return true;
                return false;
            }
            private void endDisplay()// 終了時の表示
            {
                for (int X = 1; X <= numX; X++) for (int Y = 1; Y <= numY; Y++)
                        if (DT[X, Y] == Bomb) drawBomb(X, Y);
                        else if (DT[X, Y] == Hiden0 || DT[X, Y] == 0) drawSpace(X, Y);
                        else drawNum(Math.Abs(DT[X, Y]), X, Y);
            }
            private void display()// ゲーム時の表示
            {
                for (int X = 1; X <= numX; X++) for (int Y = 1; Y <= numY; Y++)
                        if (DT[X, Y] < 0) drawHide(X, Y);
                        else if (DT[X, Y] > 0) drawNum(DT[X, Y], X, Y);
                        else drawSpace(X, Y);
            }
            private void drawNum(int V, int X, int Y)// 爆弾個数の表示
            {
                float XX = (float)(X * SZ), YY = (float)(Y * SZ);
                drawFlat(bGreen, X, Y);
                g.DrawString(V.ToString(), font, bBlack, XX + 2, YY + 1);
            }
            private void drawFlat(Brush b, int X, int Y)
            {
                float XX = (float)(X * SZ), YY = (float)(Y * SZ);
                g.FillRectangle(b, XX, YY, SZ, SZ);
                g.DrawRectangle(pBlack, XX, YY, SZ, SZ);
            }
            private void drawBomb(int X, int Y)// 爆弾の表示
            {
                if (AX == X && AY == Y) drawFlat(bRed, X, Y);
                else drawFlat(bYellow, X, Y);
                float XX = (float)(X * SZ), YY = (float)(Y * SZ);
                g.FillEllipse(bBlack, XX + SZ/4, YY + SZ/4, SZ/2, SZ/2);
                g.DrawLine(pBlack2, XX + SZ/2, YY + SZ/2, XX + SZ/2+5, YY + 2);
            }
            private void drawSpace(int X, int Y)// 空白の表示
            {
                float XX = (float)(X * SZ), YY = (float)(Y * SZ);
                g.FillRectangle(bLYellow, XX, YY, SZ, SZ);
                g.DrawRectangle(pBlack, XX, YY, SZ, SZ);
                g.DrawLine(pGray , XX +  1, YY +  1, XX + S9, YY + 1);
                g.DrawLine(pGray , XX +  2, YY +  2, XX + S8, YY + 2);
                g.DrawLine(pLGray, XX +  1, YY +  1, XX +  1, YY + S9);
                g.DrawLine(pLGray, XX +  2, YY +  2, XX +  2, YY + S8);
                g.DrawLine(pWhite, XX +  1, YY + S9, XX + S9, YY + S9);
                g.DrawLine(pWhite, XX +  2, YY + S8, XX + S8, YY + S8);
                g.DrawLine(pWhite, XX + S9, YY +  1, XX + S9, YY + S9);
                g.DrawLine(pWhite, XX + S8, YY +  2, XX + S8, YY + S8);
            }
            private void drawHide(int X, int Y)// 隠された状態の表示
            {
                float XX = (float)(X * SZ), YY = (float)(Y * SZ);
                g.FillRectangle(bLGray, XX, YY, SZ, SZ);
                g.DrawLine(pWhite, XX     , YY     , XX + SZ, YY     );
                g.DrawLine(pWhite, XX     , YY     , XX     , YY + SZ);
                g.DrawLine(pBlack, XX     , YY + SZ, XX + SZ, YY + SZ);
                g.DrawLine(pBlack, XX + SZ, YY     , XX + SZ, YY + SZ);
                g.DrawLine(pGray , XX     , YY + S9, XX + S9, YY + S9);
                g.DrawLine(pGray , XX + S9, YY     , XX + S9, YY + S9);
                g.DrawLine(pGray , XX +  1, YY + S8, XX + S8, YY + S8);
                g.DrawLine(pGray , XX + S8, YY +  1, XX + S8, YY + S8);
            }
            public void cellSelect(int X, int Y)// セルが選択されたときの処理
            {
                if (X < 1 || X > numX || Y < 1 || Y >numY) return;
                if (DT[X, Y] == 0) return;
                if (DT[X, Y] == Bomb)// 爆弾位置が選択されたとき
                {
                    AX = X; AY = Y; exeMode = false; endDisplay(); 
                }
                else                 // 爆弾位置でないセルが選択されたとき
                {
                    if (DT[X, Y] == Hiden0) { DT[X, Y] = 0; sweep(); }
                    else  if (DT[X, Y] <0) DT[X, Y] = -DT[X, Y];
                    exeMode = continueCheck();
                    if (exeMode) display(); else endDisplay(); 
                }
            }
        }
    }
}