#pragma strict
var guitext: GUIText;
static var damaged: int = 0;
static var isGoaled: boolean = false;
var lifemax: int = 5;

function Start() {
    damaged == false;
    isGoaled = false;
}

function Update() {
    if (isGoaled) guitext.text = "GOAL!";
    else if ((lifemax - damaged) >= 0) guitext.text = "LIFE: " + (lifemax - damaged);
    else Application.LoadLevel("main");
}
