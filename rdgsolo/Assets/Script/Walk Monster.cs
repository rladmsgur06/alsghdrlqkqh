using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMonster : MonoBehaviour
{

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        this.transform.Translate(new Vector3(0.0f, 0.0f, 1.5f * Time.deltaTime));
        transform.LookAt(player);
    }
}
