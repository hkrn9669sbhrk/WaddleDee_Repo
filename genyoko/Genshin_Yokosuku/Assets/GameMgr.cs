using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ①シーンの読み直しに必要
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour {
  // 状態定数
  enum State {
    Main, // メインゲーム
    GameOver, // ゲームオーバー
  }

  // スコア
  int _score = 0;
  // 状態
  State _state = State.Main;

  // ゲームオーバーの開始
  public void StartGameOver() {
    _state = State.GameOver;
  }

  void Start() {
  }

  void Update() {
  }

  private void FixedUpdate() {
    if(_state == State.Main) {
      // メインゲーム中のみスコア上昇
      _score += 1;
    }
  }

  private void OnGUI() {
    // スコアを描画
    _DrawScore();

    // 画面の中心座標を計算する
    float CenterX = Screen.width / 2;
    float CenterY = Screen.height / 2;
    if(_state == State.GameOver) {
      // ゲームオーバーの描画
      _DrawGameOver(CenterX, CenterY);
      // ②リトライボタンの描画
      if(_DrawRetryButton(CenterX, CenterY)) {
        // ③クリックしたらやり直しする
        SceneManager.LoadScene("SampleScene");
      }
    }
  }

  // リトライボタンの描画
  bool _DrawRetryButton(float CenterX, float CenterY) {
    float ofsY = 40;
    float w = 100;
    float h = 64;
    Rect rect = new Rect(CenterX - w / 2, CenterY + ofsY, w, h);
    if (GUI.Button(rect, "RETRY")) {
      // ボタンを押した
      return true;
    }
    return false;
  }

  // ゲームオーバーの描画
  void _DrawGameOver(float CenterX, float CenterY) {
    // 中央揃え
    GUI.skin.label.alignment = TextAnchor.MiddleCenter;
    float w = 400;
    float h = 100;
    Rect position = new Rect(CenterX - w / 2, CenterY - h / 2, w, h);
    GUI.Label(position, "GAME OVER");
  }

  // スコアの描画
  void _DrawScore() {
    // 文字を大きくする
    GUI.skin.label.fontSize = 32;
    // 左揃え
    GUI.skin.label.alignment = TextAnchor.MiddleLeft;
    Rect position = new Rect(8, 8, 400, 100);
    GUI.Label(position, string.Format("score:{0}", _score));
  }
}
