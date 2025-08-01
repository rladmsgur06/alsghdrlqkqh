using UnityEngine;
using UnityEngine.AI;

public class TurtleScript : MonoBehaviour
{
    public float detectionRange = 2f;
    public float attackCooldown = 5f;
    public int maxHealth = 2;
    private Animator anim;

    private NavMeshAgent agent;
    private GameObject player;
    private float lastAttackTime;
    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        currentHealth = maxHealth;
        //SpawnAtRandomOutside();
    }

    void Update()
    {
        if (isDead) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        agent.SetDestination(player.transform.position);

        if (distance <= detectionRange && Time.time - lastAttackTime > attackCooldown)
        {
            anim.SetTrigger("attack");

            player.GetComponent<PlayerHealth>().TakeDamage(5);
            lastAttackTime = Time.time;
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
        
    }
}
