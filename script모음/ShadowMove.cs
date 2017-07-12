using UnityEngine;
using System.Collections;

public class ShadowMove : MonoBehaviour {

	turn Cturn;
	public AudioClip item_sound;
	void Awake()
	{
		Cturn = GetComponent<turn> ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag.Equals("Item3")&&!gameObject.tag.Equals("parent"))
		{
			AudioSource.PlayClipAtPoint (item_sound, transform.position);

			Cturn.Shadow ();	
			col.gameObject.SetActive (false);
		}
	}
}
