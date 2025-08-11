using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{
    public Transform Potion;
    public float potionTime = 15.0f;
    public float potionPassTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //포션스폰
        Vector3 spawnPosition = new Vector3(Random.Range(-16, 16), 0, Random.Range(16, -16));
        transform.position = spawnPosition;

        if (potionPassTime >= potionTime)
        {
            Instantiate(Potion, transform.position, transform.rotation);
            potionPassTime = 0.0f;
        }
        else
        {
            potionPassTime += Time.deltaTime;
        }
    }
}
