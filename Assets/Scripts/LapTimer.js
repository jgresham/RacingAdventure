#pragma strict

var laptime : float;
var time : float;
var lapTimeDisplayText : UnityEngine.UI.Text;

function Start () {

}

function Update () {
	time = Time.time;
}

function OnGUI() {
	lapTimeDisplayText.text = 'Lap time: ' + time;
}