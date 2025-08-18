using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apxpdh : MonoBehaviour
{
    //public int level;
    private GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        monster = GameObject.FindWithTag("monster");
        //level = GetComponent<meteorsAoe>().meteorsaoelv;
        Destroy(gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*void /OnTriggerEnter(Collider coll)
    {
        if (level >= 3)
        {
            if (coll.gameObject.tag == "monster")
            {
                monster.GetComponent<TurtleScript>().Die();
            }
        }
    }*/
}
