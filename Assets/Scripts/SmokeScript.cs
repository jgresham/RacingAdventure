using UnityEngine;
using System.Collections;

public class SmokeScript : MonoBehaviour {


	public ParticleSystem ps;
	float speed;
	float speed2;
	float dif;

	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		speed2 = speed;
		speed = WheelScript.kph;
		dif = speed - speed2;
		if (speed > 1.0f && speed < 15f && dif > 0.5f) {
			ps.enableEmission = true;
		} else {
			ps.enableEmission = false;
			
		}
	}
}
