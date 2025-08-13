using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowAoe : MonoBehaviour
{
    public Transform snowaoe;
    public float snowaoeTime = 10.0f;
    public float snowaoePassTime = 0.0f;
    public int snowaoelv = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (snowaoelv >= 1)
        {
            //얼음장판스폰
            Vector3 spawnPosition = new Vector3(Random.Range(-14, 14), 0, Random.Range(14, -14));
            transform.position = spawnPosition;

            if (snowaoePassTime >= snowaoeTime)
            {
                Instantiate(snowaoe, transform.position, transform.rotation);
                snowaoePassTime = 0.0f;
            }
            else
            {
                snowaoePassTime += Time.deltaTime;
            }
            if (snowaoelv >= 2)//레벨업당 쿨타임1초 감소
            {
                snowaoeTime = 8f;
            }
            if (snowaoelv >= 3)
            {
                snowaoeTime = 6f;
            }
            if (snowaoelv >= 4)
            {
                snowaoeTime = 4f;
            }
            if (snowaoelv >= 5)
            {
                snowaoeTime = 2f;
            }
        }
    }
}
