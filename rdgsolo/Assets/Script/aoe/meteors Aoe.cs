using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorsAoe : MonoBehaviour
{
    public Transform meteorsaoe;
    public float meteorsaoeTime = 10.0f;
    public float meteorsaoePassTime = 0.0f;
    public int meteorsaoelv = 0;
    //private GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        //monster = GameObject.FindWithTag("monster");
    }

    // Update is called once per frame
    void Update()
    {
        if (meteorsaoelv >= 1)
        {
            //메테오스폰
            Vector3 spawnPosition = new Vector3(Random.Range(-14, 14), 0, Random.Range(14, -14));
            transform.position = spawnPosition;

            if (meteorsaoePassTime >= meteorsaoeTime)
            {
                Instantiate(meteorsaoe, transform.position, transform.rotation);
                meteorsaoePassTime = 0.0f;
            }
            else
            {
                meteorsaoePassTime += Time.deltaTime;
            }
            if (meteorsaoelv >= 2)//레벨업당 쿨타임 감소
            {
                meteorsaoeTime = 9.0f; 
            }
            if (meteorsaoelv >= 3)
            {
                meteorsaoeTime = 8.0f;         
            }
            if (meteorsaoelv >= 4)
            {
                meteorsaoeTime = 7.0f;
            }
            if (meteorsaoelv >= 5)
            {
                meteorsaoeTime = 6.0f;
            }
        }
    }
}
