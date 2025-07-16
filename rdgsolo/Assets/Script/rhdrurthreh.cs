using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhdrurthreh : MonoBehaviour
{
    public float bulletSpeed = 500.0f;
    public float rotateSpeed = 5.0f;

    private Transform target;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = FindClosestTarget();
     
        rb.AddForce(transform.forward * bulletSpeed);
        //맨 처음 발사되는 힘

        Destroy(gameObject, 5f);//5초후사라지게!

    }

    void FixedUpdate()
    {
        if (target == null) return;

        // 목표 방향벡터(목표-현위치)
        Vector3 direction = (target.position - transform.position).normalized;

        // 회전 방향 설정
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, lookRotation, rotateSpeed * Time.fixedDeltaTime));

        //방향만 바꾸고 속도 유지
        rb.velocity = transform.forward * rb.velocity.magnitude;
    }

    Transform FindClosestTarget() //가장 가까운 적 찾는 로직(이게왜돼?)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("monster");
        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = enemy.transform;
            }
        }

        return closest;
    }
}
