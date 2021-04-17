using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour
{
    public float MaxTiltAngle = 15.0f;
    public float tiltSpeed = 30.0f; // tilting speed in degrees/second
    public Vector3 curRot;
    public float maxX;
    public float maxZ;
    public float minX;
    public float minZ;

    void Start()
    {
        // Get initial rotation
        curRot = this.transform.eulerAngles;
        // calculate limit angles:
        maxX = curRot.x + MaxTiltAngle;
        maxZ = curRot.z + MaxTiltAngle;
        minX = curRot.x - MaxTiltAngle;
        minZ = curRot.z - MaxTiltAngle;
    }

    void Update()
    {
        // "rotate" the angles mathematically:
        curRot.x += Input.GetAxis("Vertical") * Time.deltaTime * tiltSpeed;
        curRot.z -= Input.GetAxis("Horizontal") * Time.deltaTime * tiltSpeed;
        // Restrict rotation along x and z axes to the limit angles:
        curRot.x = Mathf.Clamp(curRot.x, minX, maxX);
        curRot.z = Mathf.Clamp(curRot.z, minZ, maxZ);

        // Set the object rotation
        this.transform.eulerAngles = curRot;

        if (!Input.anyKey)
        {
            if (curRot.x >= 0.1f)
            {
                for (float i = 0f; i < maxX; i++)
                    if (curRot.x >= i)
                        curRot.x -= 4f * Time.deltaTime;
            }
            if (curRot.x < 0f)
            {
                for (float i = 0f; i > minX; i--)
                    if (curRot.x <= i)
                        curRot.x += 4f * Time.deltaTime;
            }
            if (curRot.z >= 0.1f)
            {
                for (float i = 0f; i < maxZ; i++)
                    if (curRot.z >= i)
                        curRot.z -= 4f * Time.deltaTime;
            }
            if (curRot.z < 0f)
            {
                for (float i = 0f; i > minZ; i--)
                    if (curRot.z <= i)
                        curRot.z += 4f * Time.deltaTime;
            }
        }
    }
}
