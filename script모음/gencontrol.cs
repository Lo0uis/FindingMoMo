using UnityEngine;
using System.Collections;

public class gencontrol : MonoBehaviour {

	public float gensec=10f;
	public GameObject target; 
	int check=0;
	void Update()
	{
		if (target.activeSelf == false && check==0) {
			check = 1;
			StartCoroutine ("gen");
		}
	}

	IEnumerator gen()
	{
		yield return new WaitForSeconds (gensec);
		target.SetActive (true);
		check = 0;
	}
}
