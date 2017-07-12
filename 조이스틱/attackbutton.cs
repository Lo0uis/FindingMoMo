using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class attackbutton : MonoBehaviour 
{
	public Animator _playerAnim;
	public GameObject image;
	public GameObject image1;
	public GameObject image2;
	void Start(){
		image2.SetActive (false);
		image1.SetActive (false);
		StartCoroutine ("endfade");
	}
	public void Button_Click()
	{

		var player = GameObject.FindWithTag ("Player");

		//player.("mouth", true);
	}

	IEnumerator endfade(){
		yield return new WaitForSeconds (1.5f);
		image.SetActive (false);
	}
}
