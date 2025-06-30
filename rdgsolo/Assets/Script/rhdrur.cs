using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhdrur : MonoBehaviour
{
    public Transform NM;
    public float fireTime = 1.0f;
    public float firePassTime = 0.0f;
    public Transform BulletFirePos;

    //public Transform LookatObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Instantiate(NM, BulletFirePos.position, BulletFirePos.rotation);
            //transform.LookAt(LookatObj);
        }*/

        if (firePassTime >= fireTime)
        {
            Instantiate(NM, BulletFirePos.position, BulletFirePos.rotation);
            firePassTime = 0.0f;
        }
        else
        {
            firePassTime += Time.deltaTime;
        }
    }
}
