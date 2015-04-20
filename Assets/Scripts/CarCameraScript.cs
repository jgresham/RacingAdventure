using UnityEngine;
using System.Collections;

public class CarCameraScript : MonoBehaviour {

	public Transform Car;
	public float distance = 5.4f, height = 1.4f, rotationDamping = 3.0f, heightDamping = 2.0f, zoomRatio = 10.0f;
	private Vector3 rotationVector = new Vector3();
	public float localVelocity;

	public float defaultFOV = 60; 

	void LateUpdate () {
		float wantedAngle = rotationVector.y;
		float wantedHeight = Car.position.y + height;
		float myAngle = transform.eulerAngles.y;
		float myHeight = transform.position.y;

		myAngle = Mathf.LerpAngle (myAngle, wantedAngle, rotationDamping * Time.deltaTime);
		myHeight = Mathf.Lerp (myHeight, wantedHeight, heightDamping * Time.deltaTime);

		Quaternion currentRotation = Quaternion.Euler (0, myAngle, 0);
		transform.position = Car.position;
		transform.position -= currentRotation*Vector3.forward * distance;
		transform.position = new Vector3(transform.position.x, myHeight, transform.position.z);
		transform.LookAt (Car);
	}

	void FixedUpdate () {
		localVelocity = Car.InverseTransformDirection (Car.rigidbody.velocity).z;
		if (localVelocity < -0.5f) {
			rotationVector = new Vector3(0, Car.eulerAngles.y + 180, 0);
		} else {
			rotationVector = new Vector3(0, Car.eulerAngles.y, 0);
		}
		float acc = Car.rigidbody.velocity.magnitude;
		camera.fieldOfView = defaultFOV + acc*zoomRatio*Time.deltaTime;
	}
}
