using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HitShell : MonoBehaviour
{
    int monhp = 2;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "magic")
        {
            Destroy(coll.gameObject);
            monhp -= 1;
            if (monhp == 0)
            {
                Destroy(gameObject);  
            }
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
