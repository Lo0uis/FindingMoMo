using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Fadingout : MonoBehaviour {

	//public Image image;
	Color color;
	float flo = 0f;
	// Use this for initialization
	void Awake () {
		color = GameObject.Find ("Image").GetComponent<Image> ().color;
	}
	void Start(){
		GameObject.Find ("Image").SetActive (false);
	
	}
	// Update is called once per frame
	void Update () {

	}

	/*public void fadeout(){
		StartCoroutine ("fade");
	}

	IEnumerator fade(){
		while(color.a != 1){
			flo = flo + 5.0f;
			color.a = flo / 100f;
			GameObject.Find ("Image").GetComponent<Image> ().color =new Color(color.r, color.g, color.b, color.a);
			yield return new WaitForSeconds (Time.deltaTime);

		}

	}*/
}