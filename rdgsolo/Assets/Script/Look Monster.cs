using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;

public class LookMonster : MonoBehaviour
{
    //private GameObject monster;
    public Transform monster;

    // Start is called before the first frame update
    void Start()
    {
        //monster = GameObject.FindWithTag("monster");
        transform.LookAt(monster);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
