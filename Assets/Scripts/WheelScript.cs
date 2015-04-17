using UnityEngine;
using System.Collections;

public class WheelScript : MonoBehaviour {

	WheelCollider WheelLF, WheelLR, WheelRF, WheelRR;
	float maxTorque = 50;

	// Use this for initialization
	void Start () {
		WheelLF = transform.FindChild("WheelColliders").FindChild("Wheel_LF").GetComponent<WheelCollider>();
		WheelLR = transform.FindChild("WheelColliders").FindChild("Wheel_LR").GetComponent<WheelCollider>(); 
		WheelRF = transform.FindChild("WheelColliders").FindChild("Wheel_RF").GetComponent<WheelCollider>(); 
		WheelRR = transform.FindChild("WheelColliders").FindChild("Wheel_RR").GetComponent<WheelCollider>(); 
	}
	
	// Update is called once per frame
	void Update () {
		WheelRR.motorTorque = -maxTorque * Input.GetAxis ("Vertical");
		WheelLR.motorTorque = -maxTorque * Input.GetAxis ("Vertical");
		WheelLF.steerAngle = 10 * Input.GetAxis ("Horizontal");
		WheelRF.steerAngle = 10 * Input.GetAxis ("Horizontal");
	}
}
