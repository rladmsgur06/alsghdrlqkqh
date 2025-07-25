using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MAXHP = 100;
    public int PlayerHP = 100;
    private float healTime = 1.0f;
    private float healPassTime = 0.0f;
    public int autoheal = 0;
    public int EXP = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHP < MAXHP)
        {
            if (healPassTime >= healTime)
            {
                PlayerHP+=autoheal;
                healPassTime = 0.0f;
            }
            else
            {
                healPassTime += Time.deltaTime;
            }
            
        }
        else if (PlayerHP > MAXHP)
        {
            PlayerHP = MAXHP;
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
            Destroy(coll.gameObject);
            if (PlayerHP < MAXHP)
            {
                PlayerHP += 30;              
                Debug.Log("HP" + PlayerHP);
            }            
        }
    }
}
