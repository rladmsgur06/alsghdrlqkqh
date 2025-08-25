using UnityEngine;
using UnityEngine.AI;

public class SlimeScript : MonoBehaviour
{
    public float detectionRange = 2f;
    public float attackCooldown = 5f;
    public float slowEffectDuration = 5f;  // 느려지는 시간

    private NavMeshAgent agent;
    private Animator anim;
    private GameObject player;
    private float lastAttackTime;
    private bool isDead = false;
    private bool isSlowed = false;
    private float normalSpeed;


    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        //SpawnAtRandomOutside();
        normalSpeed = agent.speed;  // 원래 속도를 저장
    }

    void Update()
    {
        if (isDead) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        agent.SetDestination(player.transform.position);

        if (distance <= detectionRange && Time.time - lastAttackTime > attackCooldown)
        {
            anim.SetTrigger("attack");
            player.GetComponent<PlayerHealth>().TakeDamage(3);
            lastAttackTime = Time.time;
        }
        if (isSlowed && Time.time - lastAttackTime > slowEffectDuration)
        {
            RestoreSpeed();
        }
    }
    /*
    void SpawnAtRandomOutside()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-30, -18), 0, Random.Range(-30, 30));
        transform.position = spawnPosition;
    }
    */
    public void Die()
    {
        anim.SetTrigger("die");
        isDead = true;
        Debug.Log("slimedead");
        //GameObject player = GameObject.FindWithTag("Player");
        player?.GetComponent<PlayerHealth>()?.AddEXP(20);
        Debug.Log("EXP +20");
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "magic")
        {
            Die();            
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Aoe")
        {
            Die();           
        }
        if (other.gameObject.tag == "slow")  // slow 태그에 닿으면 속도 감소
        {
            SlowDown();
        }
    }
    void SlowDown()
    {
        if (!isSlowed)
        {
            isSlowed = true;
            agent.speed /= 2;  // 속도 절반으로 줄이기
            lastAttackTime = Time.time;  // 느려지기 시작한 시간 기록
        }
    }

    // 속도 원래대로 복구
    void RestoreSpeed()
    {
        agent.speed = normalSpeed;
        isSlowed = false;
    }
}
