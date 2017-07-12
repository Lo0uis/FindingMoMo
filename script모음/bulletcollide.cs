using UnityEngine;
using System.Collections;

public class bulletcollide : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(!col.tag.Equals("Player")&&!col.tag.Equals("Bullet"))
			Destroy (gameObject);
	}
}
