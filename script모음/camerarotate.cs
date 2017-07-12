using UnityEngine;
using System.Collections;

public class camerarotate : MonoBehaviour
{

    public float sensitivityX = 8F;
    public float sensitivityY = 8F;
    int check = 0;
    float mHdg = 0F;
    float mPitch = 0F;

    void Start()
    {
        
    }

    void Update()
    {
        if (!(Input.GetMouseButton(0) || Input.GetMouseButton(1)))
            return;

        float deltaX = Input.GetAxis("Mouse X") * sensitivityX;
        float deltaY = Input.GetAxis("Mouse Y") * sensitivityY;

        if (Input.GetMouseButton(0))
        {
            ChangeHeading(deltaX);
            ChangeHeight(deltaY);
        }
    }

    void ChangeHeight(float aVal)
    {
        if (transform.position.y > -20F)
        {
            check = 1;
            if (aVal < 0F)
                check = 0;
        }
        if (transform.position.y < -50F) {
            check = 1;
            if (aVal > 0F)
                check = 0;
        }

        if (check == 0)
            transform.position += aVal * Vector3.up;
    }

    void ChangeHeading(float aVal)
    {
      	mHdg += aVal;
       // WrapAngle(ref mHdg);
        transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
    }

   public static void WrapAngle(ref float angle)
    {
   /*     if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
*/    }
}
