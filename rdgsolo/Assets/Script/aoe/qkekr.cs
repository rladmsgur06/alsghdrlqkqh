using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class qkekr : MonoBehaviour
{

    private GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        monster = GameObject.FindWithTag("monster");
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "monster")
        {
            monster.GetComponent<TurtleScript>().GetHit();        
        }
    }
}
