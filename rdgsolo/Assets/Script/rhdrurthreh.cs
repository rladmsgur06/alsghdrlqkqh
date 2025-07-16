using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhdrurthreh : MonoBehaviour
{
    public float bulletSpeed = 500.0f;
    public float rotateSpeed = 500.0f; // ȸ�� �ӵ�
    private Transform target;

    private Rigidbody rb;

    void Start()
    {
        target = GameObject.FindWithTag("monster")?.transform;
        //���� �±�(ǥ��) ã��

        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * bulletSpeed);
        //�� ó�� �߻�Ǵ� ��
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        //��ǥ ���� ����(��ǥ - ����ġ)

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, lookRotation, rotateSpeed * Time.fixedDeltaTime));
        //ȸ������

        rb.velocity = transform.forward * (rb.velocity.magnitude); // ���⸸ ����, �ӵ��� ����
    }
}
