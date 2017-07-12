using UnityEngine;
using System.Collections;

public class globalflock : MonoBehaviour {

    public GameObject fishPrefab;

    static int numFish = 20;
    public static GameObject[] allFish = new GameObject[numFish];
    public static Vector3 goalpos = Vector3.zero;
    public static int tanksize = 50;

	// Use this for initialization
	void Start () {

        RenderSettings.fogColor = Camera.main.backgroundColor;
        RenderSettings.fogDensity = 0.03F;
        RenderSettings.fog = true;
        for (int i=0; i<numFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-97, 108), Random.Range(-45, -10), Random.Range(-55, 66));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0, 10000) < 50)
        {
            goalpos = new Vector3(Random.Range(-97, 108), Random.Range(-5, 74), Random.Range(-55, 66));
        }
	}
}
