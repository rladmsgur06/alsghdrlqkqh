using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitSlime : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "magic")
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
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
