using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class plexusAoe : MonoBehaviour
{
    public Transform plexusaoe;
    public float plexusaoeTime = 5.0f;
    public float plexusaoePassTime = 0.0f;
    public int plexusaoelv = 0;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (plexusaoelv >= 1)
        {
            //번개스폰
            Vector3 spawnPosition = new Vector3(Random.Range(-16, 16), 0, Random.Range(16, -16));
            transform.position = spawnPosition;

            if (plexusaoePassTime >= plexusaoeTime)
            {
                Instantiate(plexusaoe, transform.position, transform.rotation);
                plexusaoePassTime = 0.0f;
            }
            else
            {
                plexusaoePassTime += Time.deltaTime;
            }
        }   
        if (plexusaoelv >= 2)//레벨업당 쿨타임1초 감소
        {
            plexusaoeTime = 4.0f;
        }
        if (plexusaoelv >= 3)
        {
            plexusaoeTime = 3.0f;
        }
        if (plexusaoelv >= 4)
        {
            plexusaoeTime = 2.0f;
        }
        if (plexusaoelv >= 5)
        {
            plexusaoeTime = 1.0f;
        }
    }
}
