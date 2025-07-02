using UnityEngine;
using UnityEngine.AI;

public class SlimeScript : MonoBehaviour
{
    public float detectionRange = 5f;
    public float attackCooldown = 2f;

    private NavMeshAgent agent;
    private GameObject player;
    private float lastAttackTime;
    private bool isDead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        SpawnAtRandomOutside();
    }

    void Update()
    {
        if (isDead) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        agent.SetDestination(player.transform.position);

        if (distance <= detectionRange && Time.time - lastAttackTime > attackCooldown)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(10);
            lastAttackTime = Time.time;
        }
    }

    void SpawnAtRandomOutside()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-30, -18), 0, Random.Range(-30, 30));
        transform.position = spawnPosition;
    }

    public void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "magic")
        {
            Die();            
            Destroy(other.gameObject);
        }
    }
}
