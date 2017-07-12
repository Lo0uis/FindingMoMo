using UnityEngine;
using System.Collections;

public class FinishTimer : MonoBehaviour {
	private void OnTriggerEnter(Collider other)
	{
		GameObject.Find("player").SendMessage("Finnish");
	}


}
