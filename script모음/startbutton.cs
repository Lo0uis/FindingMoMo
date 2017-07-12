using UnityEngine;
using System.Collections;

public class startbutton : MonoBehaviour {
	public GameObject image;
	public AudioClip button_sound;

	public void startbut(){
		AudioSource.PlayClipAtPoint (button_sound, transform.position);
		StartCoroutine ("start");
	}

	public void exitbut(){
		AudioSource.PlayClipAtPoint (button_sound, transform.position);
		StartCoroutine ("end");
	}

	public void retrybut(){
		AudioSource.PlayClipAtPoint (button_sound, transform.position);
		StartCoroutine ("retry");
	}

	IEnumerator start(){
		image.SetActive (true);
		yield return new WaitForSeconds (1.5f);
		Application.LoadLevel ("12");
	}

	IEnumerator end(){
		Application.Quit ();
		yield return new WaitForSeconds (1.5f);

	}
	IEnumerator retry(){
		yield return new WaitForSeconds (1.0f);
		Application.LoadLevel ("maingame");

	}
}
