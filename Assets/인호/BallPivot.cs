using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPivot : MonoBehaviour
{
    Moving thePlayer;

    private Vector2 vector;

    public float angle;         // 공이 바라보는 방향을 설정할 예정   
                                // pivot에서 이를 설정하면 ballScript에서는 한방향만 고려해도 됨

    private bool CanRotate = true;     // 공을 차서 멀리있는 동안 방향을 움직여 각도를 바꾸면 어색해 보이기 때문에    
                                       // 공이 돌아오기 전까지는 CanRotate를 false로 둬서 각도가 바뀌지 않도록 한다.\
    private float rememberAngle;



    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Moving>();
        this.transform.rotation = Quaternion.Euler(180, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanRotate)
        {
            Debug.Log("!");
            GetAngle();
        }

        this.transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void GetAngle()
    {

        vector = thePlayer.arrow;

        angle = Mathf.Atan(vector.y / vector.x) * 180.0f / Mathf.PI;

        if (vector.x > 0) 
        {

            if (vector.y > 0)
            { }
            else if (vector.y == 0)
            { }
            else if (vector.y < 0)
            { }
        }
        else if (vector.x == 0)
        {

            if (vector.y > 0)
            {

            }
            else if (vector.y < 0)
            {

            }
            else if (vector.y == 0)
            {
                angle = rememberAngle;
            }
        }
        else if (vector.x<0)
        {

            angle += 180;

        }
        rememberAngle = angle;

    }

    public void StopRotateBall()
    {
        CanRotate = false;
    }

    public void CanRotateBall()
    {
        CanRotate = true;
    }


}
