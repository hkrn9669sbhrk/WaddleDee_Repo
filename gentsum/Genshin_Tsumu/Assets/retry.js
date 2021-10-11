#pragma strict


function Start () {


}


function Update () {
    checkClick();
}
// クリックした処理を行う関数
function checkClick(){
    // ボタンを押したかチェック
    if(Input.GetMouseButtonDown(0)){
        // クリックしたオブジェクトを調べる
        var obj = getClickObj();
        // クリックしたのが"Sphere"かチェック
        if (obj != null && obj.name == "retry"){
            // "map"シーンをロードする
            Application.LoadLevel("Main");
        }
    }
}
// クリックしたオブジェクトを調べる関数
function getClickObj(){
    var ray : Ray;
    var hit : RaycastHit;
    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, hit, 100)) {
        return hit.collider.gameObject;
    } else {
        return null;
    }
}
