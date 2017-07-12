using UnityEngine;
using System.Collections;

public class blackhole : MonoBehaviour {
	public GameObject image2;
	public AudioClip blackhole_sound;
	void OnTriggerEnter(Collider col)
	{


		if (col.tag.Equals ("Player") || col.tag.Equals ("shadow")) {
			AudioSource.PlayClipAtPoint (blackhole_sound, transform.position);
			StartCoroutine ("startfade");
		}
	}

	IEnumerator startfade(){
		image2.SetActive (true);
		yield return new WaitForSeconds (1.5f);
			Application.LoadLevel("maingame");
	}
}
