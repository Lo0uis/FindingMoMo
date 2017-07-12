using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class newmodel : MonoBehaviour 
{

	public void Button_Click()
	{
		
		var player = GameObject.FindWithTag ("Player");
		player.transform.Translate (0, 5, 0);
	}
}
