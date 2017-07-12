using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {

    public float speed = 5.0f;
    float rotationspeed = 4.0f;
    float minSpeed = 5.0f;
    float maxSpeed = 7.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighborDistance = 20.0f;
    bool turning = false;
    public Vector3 newGoalPos;

    // Use this for initialization
    void Start () {
        speed = Random.Range(minSpeed, maxSpeed);
	}
	
    void OnTriggerEnter(Collider other)
    {
        if(!turning)
        {
            newGoalPos = this.transform.position - other.gameObject.transform.position;
        }
        turning = true;
    }

    void OnTriggerExit(Collider other)
    {
        turning = false;
    }

	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, Vector3.zero) >= globalflock.tanksize)
        {
            turning = true;
        }
        else
            turning = false;

        if (turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationspeed * Time.deltaTime);
            speed = Random.Range(minSpeed, maxSpeed);
        }
        else
        {
            if (Random.Range(0, 10) < 1)
                ApplyRules();
        }
        
        transform.Translate(0, 0, Time.deltaTime * speed);

	}
    void ApplyRules()
    {
        GameObject[] gos;
        gos = globalflock.allFish;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;

        float gSpeed = 5.0f;

        Vector3 goalpos = globalflock.goalpos;

        float dist;

        int groupsize = 0;
        foreach(GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if(dist <= neighborDistance)
                {
                    vcentre += go.transform.position;
                    groupsize++;

                    if(dist < 2.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }
                    flock anotherFlock = go.GetComponent<flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if(groupsize > 0)
        {
            vcentre = vcentre / groupsize + (goalpos - this.transform.position);
            speed = gSpeed / groupsize;

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationspeed * Time.deltaTime);
        }
    }
}
