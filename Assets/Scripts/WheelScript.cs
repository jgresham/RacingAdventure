using UnityEngine;
using System.Collections;

public class WheelScript : MonoBehaviour {

	public WheelCollider WheelLF, WheelLR, WheelRF, WheelRR;
	public Transform WheelLFTrans, WheelLRTrans, WheelRFTrans, WheelRRTrans;
	public float maxTorque = 50;

	// Use this for initialization
	void Start () {
//		WheelLF = transform.FindChild("WheelColliders").FindChild("Wheel_LF").GetComponent<WheelCollider>();
//		WheelLR = transform.FindChild("WheelColliders").FindChild("Wheel_LR").GetComponent<WheelCollider>(); 
//		WheelRF = transform.FindChild("WheelColliders").FindChild("Wheel_RF").GetComponent<WheelCollider>(); 
//		WheelRR = transform.FindChild("WheelColliders").FindChild("Wheel_RR").GetComponent<WheelCollider>(); 
	}

	void FixedUpdate () {
		WheelRR.motorTorque = -maxTorque * Input.GetAxis ("Vertical");
		WheelLR.motorTorque = -maxTorque * Input.GetAxis ("Vertical");
		WheelLF.steerAngle = 10 * Input.GetAxis ("Horizontal");
		WheelRF.steerAngle = 10 * Input.GetAxis ("Horizontal");
	}

	// Update is called once per frame
	void Update () {
		WheelLFTrans.Rotate (WheelLF.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		WheelLRTrans.Rotate (WheelLR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		WheelRFTrans.Rotate (WheelRF.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		WheelRRTrans.Rotate (WheelRR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
	}
}
