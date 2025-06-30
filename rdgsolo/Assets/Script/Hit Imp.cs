using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitImp : MonoBehaviour
{
    int imphp = 5;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "magic")
        {
            Destroy(coll.gameObject);
            imphp -= 1;
            if (imphp == 0)
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
