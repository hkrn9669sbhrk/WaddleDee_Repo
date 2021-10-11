using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ■プレイヤー
public class Player : MonoBehaviour {
  // スプライト番号定義
  const int SPR_FALL = 0; // 落下中
  const int SPR_JUMP = 1; // ジャンプ中

  [SerializeField]
  float JUMP_VELOCITY = 1000; // ジャンプ力の定義
  public Sprite[] SPR_LIST; // アニメーション用スプライトの保持
  public GameObject gameMgr; // ①ゲーム管理

  Rigidbody2D _rigidbody; // 物理挙動コンポーネント保持用
  SpriteRenderer _renderer; // スプライト描画
  GameMgr _gameMgr; // ②ゲーム管理スクリプト

  // 開始処理
  void Start() {
    // 物理挙動コンポーネントを取得
    _rigidbody = GetComponent<Rigidbody2D>();
    // スプライト描画コンポーネントを取得
    _renderer = GetComponent<SpriteRenderer>();
    // ③ゲーム管理スクリプトを取得
    _gameMgr = gameMgr.GetComponent<GameMgr>();
  }

  // 更新
  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      // Spaceキーを押したのでジャンプ処理
      _rigidbody.velocity = Vector2.zero; // 落下速度を一度リセットする
      _rigidbody.AddForce(new Vector2(0, JUMP_VELOCITY)); // 上方向に力を加える
    }

    // 状態でスプライトを切り替える
    if (_rigidbody.velocity.y < 0) {
      // 落下中
      _renderer.sprite = SPR_LIST[SPR_FALL];
    } else {
      // 上昇中
      _renderer.sprite = SPR_LIST[SPR_JUMP];
    }
  }

  // 固定フレーム更新
  private void FixedUpdate() {
    // 座標を取得
    Vector3 position = transform.position;
    float y = transform.position.y;
    // 画面外に出ないようにする
    if (y > GetTop()) {
      _rigidbody.velocity = Vector2.zero; // 速度を一度リセットする
      position.y = GetTop(); // 押し戻しする
    }
    if (y < GetBottom()) {
      // 下に落ちたらオートジャンプ
      _rigidbody.velocity = Vector2.zero; // 落下速度を一度リセットする
      _rigidbody.AddForce(new Vector2(0, JUMP_VELOCITY));
      position.y = GetBottom(); // 押し戻しする
    }

    // 座標を反映する
    transform.position = position;
  }

  // 画面上を取得する
  float GetTop() {
    // 画面の右上のワールド座標を取得する
    Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
    return max.y;
  }

  // 画面下を取得する
  float GetBottom() {
    // 画面の左下のワールド座標を取得する
    Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
    return min.y;
  }

  // 衝突判定
  private void OnTriggerEnter2D(Collider2D collision) {
    // 衝突したので消滅
    Destroy(gameObject);
    // ④ゲームオーバーを通知
    _gameMgr.StartGameOver();
  }
}
