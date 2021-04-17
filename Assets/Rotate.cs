using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    
    //Rotational Speed
    public float speed = 0f;
    

    //Forward Direction
    public bool ForwardX = false;
    public bool ForwardY = false;
    public bool ForwardZ = false;

    //Reverse Direction
    public bool ReverseX = false;
    public bool ReverseY = false;
    public bool ReverseZ = false;

    void Update()
    {
        //Forward Direction
        if (ForwardX == true)
        {
            transform.Rotate(Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (ForwardY == true)
        {
            transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
        }
        if (ForwardZ == true)
        {
            transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
        }
        //Reverse Direction
        if (ReverseX == true)
        {
            transform.Rotate(-Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (speed != 0 && ReverseY == true)
        {
            speed -= 10f * Time.deltaTime;
            transform.Rotate(0, -Time.deltaTime * speed, 0, Space.Self);
            if (speed <= 0f)
            {
                ReverseY = false;
            }
        }
        if (ReverseZ == true)
        {
            transform.Rotate(0, 0, -Time.deltaTime * speed, Space.Self);
        }

    }

    public void BoostSpeed()
    {
        if(speed <= 1000f)
            speed += 2000f;
    }
    
}
