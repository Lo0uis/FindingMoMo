using UnityEngine;
using System.Collections;

public class heart : MonoBehaviour {

	public GameObject []heartitem = new GameObject[5];
	public AudioClip item_sound;

	void OnTriggerEnter(Collider col)
	{
		if(col.tag.Equals("Item5")&&!gameObject.tag.Equals("parent"))
		{			
			AudioSource.PlayClipAtPoint (item_sound, transform.position);
			
			col.gameObject.SetActive (false);
			if (heartitem [3].activeSelf == false)
				heartitem [3].SetActive (true);
			else if (heartitem [2].activeSelf == false)
				heartitem [2].SetActive (true);
			else if (heartitem [1].activeSelf == false)
				heartitem [1].SetActive (true);
			else if (heartitem [0].activeSelf == false){
				heartitem [0].SetActive (true);
			}
		}
	}
}
