using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhdrurthreh : MonoBehaviour
{
    public float bulletSpeed = 500.0f;
    public float rotateSpeed = 500.0f; // 회전 속도
    private Transform target;

    private Rigidbody rb;

    void Start()
    {
        target = GameObject.FindWithTag("monster")?.transform;
        //몬스터 태그(표적) 찾기

        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * bulletSpeed);
        //맨 처음 발사되는 힘
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        //목표 방향 벡터(목표 - 현위치)

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, lookRotation, rotateSpeed * Time.fixedDeltaTime));
        //회전설정

        rb.velocity = transform.forward * (rb.velocity.magnitude); // 방향만 조정, 속도는 유지
    }
}
