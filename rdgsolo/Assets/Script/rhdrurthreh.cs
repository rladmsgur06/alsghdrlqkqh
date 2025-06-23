using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhdrurthreh : MonoBehaviour
{
    private float bulletSpeed = 500.0f;
    private Transform thisTransform;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        FireBullet();
    }

    void FireBullet()
    {
        GetComponent<Rigidbody>().AddForce(thisTransform.forward * bulletSpeed);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
