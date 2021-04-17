using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    public RotateHead rotateHead;
    public Rotate rotate;
    public int movementspeed = 0;
    // Use this for initialization
    void Start()
    {
        
        if (rotate.speed == 1000f)
            movementspeed = 2;
        else if (rotate.speed == 2000f)
            movementspeed = 4;
        else if (rotate.speed == 3000f)
            movementspeed = 6;

    }

    // Update is called once per frame
    void Update()
    {
        if (rotate.speed <= 1000f)
            movementspeed = 2;
        else if (rotate.speed <= 2000f)
            movementspeed = 4;
        else if (rotate.speed >= 1000f && rotate.speed >= 2000f && rotate.speed <= 4000f)
            movementspeed = 6;

        if (rotate.ReverseY == true)
        {
            if (rotateHead.curRot.x >= 8f)
            {
                transform.Translate(Vector3.forward * movementspeed * Time.deltaTime);
                EualarFix(1);
            }
            if (rotateHead.curRot.x <= -8f)
            {
                transform.Translate(Vector3.back * movementspeed * Time.deltaTime);
                EualarFix(1);
            }
            if (rotateHead.curRot.z >= 8f)
            {
                transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
                EualarFix(2);
            }
            if (rotateHead.curRot.z <= -8f)
            {
                transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
                EualarFix(2);
            }
        }
    }

    void EualarFix(int x =1,int z = 2)
    {
        if(x == 1){
            if (rotateHead.curRot.z >= 0.1f)
            {
                for (float i = 0f; i < rotateHead.maxZ; i++)
                    if (rotateHead.curRot.z >= i)
                        rotateHead.curRot.z -= 4f * Time.deltaTime;
            }
            if (rotateHead.curRot.z < 0f)
            {
                for (float i = 0f; i > rotateHead.minZ; i--)
                    if (rotateHead.curRot.z <= i)
                        rotateHead.curRot.z += 4f * Time.deltaTime;
            }
        }

        if (z == 2)
        {
            if (rotateHead.curRot.x >= 0.1f)
            {
                for (float i = 0f; i < rotateHead.maxX; i++)
                    if (rotateHead.curRot.x >= i)
                        rotateHead.curRot.x -= 4f * Time.deltaTime;
            }
            if (rotateHead.curRot.x < 0f)
            {
                for (float i = 0f; i > rotateHead.minX; i--)
                    if (rotateHead.curRot.x <= i)
                        rotateHead.curRot.x += 4f * Time.deltaTime;
            }
        }


    }
}
