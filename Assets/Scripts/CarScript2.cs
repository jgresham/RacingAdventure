using UnityEngine;
using System.Collections;

public class CarScript2 : MonoBehaviour {
	
	public float initialVelocity;
	public float finalVelocity;
	public static float currentVelocity;
	public float accelerationRate;
	public float decelerationRate;
	public float restingDecelerationRate;


	public float turningVelocity;
	public float turningFinalVelocityLeft;
	public float turningFinalVelocityRight;
	public float turningAccelerationRate;
	
	// Use this for initialization
	void Start () {
		initialVelocity = 0.0f;
		finalVelocity = 1.0f;
		currentVelocity = 0.0f;
		accelerationRate = 0.005f;
		decelerationRate = 0.01f;
		restingDecelerationRate = 0.005f;

		turningVelocity = 0.0f;
		turningAccelerationRate = 35.0f;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (currentVelocity);
		if (currentVelocity > 0.30f) {
			accelerationRate = 0.001f;		
		} else if (currentVelocity > 0.50f) {
			accelerationRate = 0.0008f;	
		} else if (currentVelocity > 0.80f) {
			accelerationRate = 0.0003f;	
		} else if (currentVelocity <= 0.30f) {
			accelerationRate = 0.005f;	
		}
		

		//speed logic
		if (Input.GetKey (KeyCode.X)) {
			currentVelocity += accelerationRate;		
		} else {
			currentVelocity -= restingDecelerationRate;
		}

		if (Input.GetKey (KeyCode.Z)) {
			currentVelocity -= decelerationRate;
		}

		if (currentVelocity > finalVelocity) {
			currentVelocity = finalVelocity;
		}
		if (currentVelocity < initialVelocity) {
			currentVelocity = initialVelocity;
		}

		turningVelocity = Input.GetAxis ("Horizontal") * turningAccelerationRate;
		turningVelocity *= Time.deltaTime;



		transform.Translate (0, 0, currentVelocity);
		transform.Rotate (0, turningVelocity, 0);


	}
}
