using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;
	public GameObject records;


	public void LoadScene(int option)
	{
		if (option == 2) {
			records.SetActive (true);		
		} else if (option == 3) {
			records.SetActive (false);
		} else {
			loadingImage.SetActive (true);
			Application.LoadLevel (option);
		}

	}


	public void showRecords()
	{
		records.SetActive (true);
	}




}