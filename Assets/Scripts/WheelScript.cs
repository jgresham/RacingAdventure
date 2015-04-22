using UnityEngine;
using System.Collections;

public class WheelScript : MonoBehaviour {

	public WheelCollider WheelLF, WheelLR, WheelRF, WheelRR;
	public Transform WheelLFTrans, WheelLRTrans, WheelRFTrans, WheelRRTrans;
	public float maxTorque = 50;
	public float lowSpeedSteerAngle = 10, highSpeedSteerAngle = 1;
	public float antiRollControl = 5000;
	public float currentSpeed, topSpeed = 150;

	// Use this for initialization
	void Start () {
		rigidbody.centerOfMass = new Vector3 (0, -0.2f, 0);
	}

	void FixedUpdate () {
		// Wheel translation (moves Car)
		WheelRR.motorTorque = -maxTorque * Input.GetAxis ("Vertical");
		WheelLR.motorTorque = -maxTorque * Input.GetAxis ("Vertical");
		WheelLF.steerAngle = 10 * Input.GetAxis ("Horizontal");
		WheelRF.steerAngle = 10 * Input.GetAxis ("Horizontal");


		// Speed limit (km/hr)
		currentSpeed = 2 * 3.141f * WheelLF.radius * WheelLF.rpm * (60 / 1000);
		if(currentSpeed > topSpeed || currentSpeed < -topSpeed) {
			WheelRR.motorTorque = 0;
			WheelLR.motorTorque = 0;
		}

		// Antil-Roll bars
		float travelLF = 1.0f, travelLR = 1.0f, travelRF = 1.0f, travelRR = 1.0f;
		WheelHit hit;

		bool groundedLF = WheelLF.GetGroundHit (out hit);
		if (groundedLF)
			travelLF = (-WheelLF.transform.InverseTransformPoint (hit.point).y - WheelLF.radius) / WheelLF.suspensionDistance;
		bool groundedLR = WheelLR.GetGroundHit (out hit);
		if (groundedLR)
			travelLR = (-WheelLR.transform.InverseTransformPoint (hit.point).y - WheelLR.radius) / WheelLR.suspensionDistance;
		bool groundedRF = WheelRF.GetGroundHit (out hit);
		if (groundedRF)
			travelRF = (-WheelRF.transform.InverseTransformPoint (hit.point).y - WheelRF.radius) / WheelRF.suspensionDistance;
		bool groundedRR = WheelRR.GetGroundHit (out hit);
		if (groundedRR)
			travelRR = (-WheelRR.transform.InverseTransformPoint (hit.point).y - WheelRR.radius) / WheelRR.suspensionDistance;

		float antiRollFrontAxle = (travelLF = travelRF)*antiRollControl;
		float antiRollRearAxle = (travelLR = travelRR)*antiRollControl;

		if (groundedLF)
			rigidbody.AddForceAtPosition (WheelLF.transform.up * -antiRollFrontAxle, WheelLF.transform.position);
		if (groundedLR)
			rigidbody.AddForceAtPosition (WheelLR.transform.up * -antiRollRearAxle, WheelLR.transform.position);
		if (groundedRF)
			rigidbody.AddForceAtPosition (WheelRF.transform.up * -antiRollFrontAxle, WheelRF.transform.position);
		if (groundedRR)
			rigidbody.AddForceAtPosition (WheelRR.transform.up * -antiRollRearAxle, WheelRR.transform.position);
	}

	// Update is called once per frame
	void Update () {
		// Wheel forward and backward rotation
		WheelLFTrans.Rotate (WheelLF.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		WheelLRTrans.Rotate (WheelLR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		WheelRFTrans.Rotate (WheelRF.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		WheelRRTrans.Rotate (WheelRR.rpm / 60 * 360 * Time.deltaTime, 0, 0);

		//Wheel turning rotation
		WheelLFTrans.localEulerAngles = new Vector3(0, WheelLF.steerAngle, 0);
		WheelRFTrans.localEulerAngles = new Vector3(0, WheelRF.steerAngle, 0);

	}
}
