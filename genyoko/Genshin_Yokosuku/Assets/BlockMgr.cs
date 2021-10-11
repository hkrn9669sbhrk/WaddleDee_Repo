using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMgr : MonoBehaviour {
  // 生成するBlockオブジェクト
  public GameObject block;

  // 0になったらBlockオブジェクトを生成
  float _timer = 0;
  // トータルの経過時間を保持
  float _totalTime = 0;
  // ①ブロック生成回数
  int _cnt = 0;

  void Start() {
  }

  void Update() {
    // 経過時間を差し引く
    _timer -= Time.deltaTime;
    // トータル時間を加算
    _totalTime += Time.deltaTime;

    if(_timer < 0) {
      // 0になったのでBlock生成
      // BlockMgrの場所から生成
      Vector3 position = transform.position;
      // ※上下(±3)のランダムな位置に出現させる
      position.y = Random.Range(-4, 4);
      // プレハブをもとにBlock生成
      GameObject obj = Instantiate(block, position, Quaternion.identity);
      // Blockオブジェクトの「Block」スクリプトを取得する
      Block blockScript = obj.GetComponent<Block>();
      // 速度を計算して設定
      // 基本速度100に、経過時間x10を加える
      float speed = 100 + (_totalTime * 10);
      blockScript.SetSpeed(-speed); // 左方向なのでマイナス

      // ②生成回数をカウントアップ
      _cnt++;
      if(_cnt%10 < 3) {
        // 0.1秒後にまた生成する
        _timer += 0.1f;
      } else {
        // 1秒後にまた生成する
        _timer += 1;
      }
    }
  }
}
