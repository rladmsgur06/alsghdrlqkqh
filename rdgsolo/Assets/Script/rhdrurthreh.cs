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
        //�� ó�� �߻�Ǵ� ��

        Destroy(gameObject, 5f);//5���Ļ������!

    }

    void FixedUpdate()
    {
        if (target == null) return;

        // ��ǥ ���⺤��(��ǥ-����ġ)
        Vector3 direction = (target.position - transform.position).normalized;

        // ȸ�� ���� ����
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, lookRotation, rotateSpeed * Time.fixedDeltaTime));

        //���⸸ �ٲٰ� �ӵ� ����
        rb.velocity = transform.forward * rb.velocity.magnitude;
    }

    Transform FindClosestTarget() //���� ����� �� ã�� ����(�̰Կֵ�?)
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
