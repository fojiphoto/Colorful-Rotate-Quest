using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed;

    private float rotZ;

    private bool rotation = false;

    private float cacheZ;

    public Block block;

    private void Awake()
    {
        rotZ = transform.rotation.z;
        cacheZ = rotZ;
    }

    private void OnMouseDown()
    {
        if (!rotation)
        {
            rotation = true;
            block.canCheck = false; 
        }
    }

    private void Update()
    {
        if (rotation)
        {
            rotZ -= Time.deltaTime * rotationSpeed;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            if (rotZ <= (cacheZ - 90f))
            {
                rotZ = cacheZ - 90f;
                cacheZ = rotZ;
                transform.rotation = Quaternion.Euler(0, 0, rotZ);
                block.canCheck = true;
                rotation = false;
            }
        }
    }
}
