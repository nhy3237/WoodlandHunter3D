using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VianArrowShoot : MonoBehaviour
{
    private float shootForce = 5f;
    Rigidbody arrowRigidbody;
    bool isShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        arrowRigidbody = GetComponent<Rigidbody>();
        arrowRigidbody.useGravity = false;
    }

    private void Update()
    {
        if(isShoot)
        {
            transform.forward = GetComponent<Rigidbody>().velocity;
        }
    }

    public void ShootArrow()
    {
        arrowRigidbody.useGravity = true;
        arrowRigidbody.velocity = transform.forward * shootForce;
        isShoot = true;
    }
}

   
