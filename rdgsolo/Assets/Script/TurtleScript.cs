using UnityEngine;
using UnityEngine.AI;

public class TurtleScript : MonoBehaviour
{
    public float detectionRange = 2f;
    public float attackCooldown = 5f;
    public int maxHealth = 2;
    private Animator anim;
    public float slowEffectDuration = 5f;

    private NavMeshAgent agent;
    private GameObject player;
    private float lastAttackTime;
    private int currentHealth;
    private bool isDead = false;
    private bool isSlowed = false;
    private float normalSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        Debug.Log("[TurtleScript] Player 오브젝트 찾음?" + player);
        currentHealth = maxHealth;
        //SpawnAtRandomOutside();
        normalSpeed = agent.speed;
    }

    void Update()
    {
        if (isDead) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        agent.SetDestination(player.transform.position);

        if (distance <= detectionRange && Time.time - lastAttackTime > attackCooldown)
        {
            anim.SetTrigger("attack");
            Debug.Log("[TurtleScript] Update 함수-> Player 오브젝트 찾음?" + (player == null ? "NULL" : "있음"));
            Debug.Log("[TurtleScript] PlayerHealth " +
          (player.GetComponent<PlayerHealth>() == null ? "NULL" : "있음"));
            //Debug.Log("[TurtleScript] PlayerHealth 찾음??" + player.GetComponent<PlayerHealth>());
            player.GetComponent<PlayerHealth>().TakeDamage(5);
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

    public void GetHit()
    {
        if (isDead) return;

        currentHealth--;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetTrigger("die");

        isDead = true;
       //GameObject player = GameObject.FindWithTag("Player");
        player?.GetComponent<PlayerHealth>()?.AddEXP(20);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("magic"))
        {
            GetHit();
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
