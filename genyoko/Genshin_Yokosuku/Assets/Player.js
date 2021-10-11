#pragma strict
private var speed: float = 15; // スピードを設定
var grounded: boolean = false;
var groundlayer: LayerMask;

function Start() {
    GetComponent.<Rigidbody2D>().fixedAngle = true;
}
function Update() {

    // 左右のキー入力を受け取る
    var x: float = Input.GetAxisRaw("Horizontal");

    // 移動する向きを求める
    var direction: Vector2 = new Vector2(x, 0).normalized;

    // 移動するスピードを求めて代入する
    GetComponent.<Rigidbody2D>().velocity = direction * speed;

    grounded = Physics2D.Linecast(transform.position,
        transform.position - transform.up * 4,
        groundlayer);

    if (Input.GetKeyDown("space") && grounded) {
        GetComponent.<Rigidbody2D>().AddForce(Vector2.up * 27500);
    }

}

function OnCollisionEnter2D(col: Collision2D) {

    if (col.gameObject.tag == "Enemy") { // ぶつかったオブジェクトの判別
        GUIController.damaged++;
    }
    else if (col.gameObject.tag == "GameOver") {
        Application.LoadLevel("main");
    }


}

function OnTriggerEnter2D(obj: Collider2D) {

    if (obj.gameObject.tag == "Goal") { // ぶつかったオブジェクトの判別
        GUIController.isGoaled = true;
    }

}