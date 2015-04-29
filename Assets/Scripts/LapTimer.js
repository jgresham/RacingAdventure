


var pastTime : float = 10F;
var myWC : WheelCollider;
var isFinished : boolean = false;
var lapTimeDisplayText : UnityEngine.UI.Text;

function Update () {
	var hit : WheelHit;
	
	if(myWC.GetGroundHit(hit)) {
		if(hit.collider.gameObject.tag == "Finish") {
			isFinished = true;
		}
	}
	
	if(!isFinished) {
		pastTime += Time.deltaTime;
	}
	
	
}

function OnGUI() {
	lapTimeDisplayText.text = 'Lap time: ' + pastTime;
}






/*
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
*/