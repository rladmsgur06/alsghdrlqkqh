using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{

    private Animator animator;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent ������Ʈ ��������
        animator = GetComponent<Animator>();  // Animator ������Ʈ ��������

        if (Input.GetKey(KeyCode.W))
        { 
            animator.SetBool("isWalking", true);  // isWalking �Ķ���͸� true�� ����
        }
        else
        {
            animator.SetBool("isWalking", false);  // isWalking �Ķ���͸� false�� ����
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
