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
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent 컴포넌트 가져오기
        animator = GetComponent<Animator>();  // Animator 컴포넌트 가져오기

        if (Input.GetKey(KeyCode.W))
        { 
            animator.SetBool("isWalking", true);  // isWalking 파라미터를 true로 설정
        }
        else
        {
            animator.SetBool("isWalking", false);  // isWalking 파라미터를 false로 설정
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
