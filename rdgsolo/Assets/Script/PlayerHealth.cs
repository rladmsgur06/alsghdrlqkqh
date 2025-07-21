using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int PlayerHP = 100;
    private float healTime = 1.0f;
    private float healPassTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHP < 100)
        {
            if (healPassTime >= healTime)
            {
                PlayerHP++;
                healPassTime = 0.0f;
            }
            else
            {
                healPassTime += Time.deltaTime;
            }
            
        }
        else if (PlayerHP > 100)
        {
            PlayerHP = 100;
        }
        
    }
    public void TakeDamage(int damage)
    {
        //Debug.Log("Damage "+damage+ " taken");
        PlayerHP = PlayerHP - damage;
        Debug.Log("HP" + PlayerHP);

        if (PlayerHP <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Die");
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "potion")
        {
            if (PlayerHP < 100)
            {
                PlayerHP += 30;
                Destroy(coll.gameObject);
                Debug.Log("HP" + PlayerHP);
            }
            else
            {
                Destroy(coll.gameObject);
            }
        }
    }
}
