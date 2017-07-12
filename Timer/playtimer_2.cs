using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playtimer_2 : MonoBehaviour {

	public Text timerText;
	private float startTime;
	private bool finnished = false;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (finnished)
			return;
		float t = Time.time - startTime;

		string minutes = ((int) t / 60).ToString ();
		string seconds = (t % 60).ToString ("f0");

		timerText.text = minutes + " : " + seconds;
	}

	public void Finnish(){
		finnished = true;
		timerText.color = Color.red;
	}
}
