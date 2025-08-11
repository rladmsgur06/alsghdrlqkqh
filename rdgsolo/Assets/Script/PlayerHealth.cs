using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MAXHP = 100;//최대체력
    public int PlayerHP = 100;//현재체력
    private float healTime = 1.0f;
    private float healPassTime = 0.0f;
    public int autoheal = 0; //체력재생력
    public int autoheallv = 0;
    public int EXP = 0;//슬라임3, 터틀슬라임5 총 50모이면 레벨업

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
        if (autoheallv >= 2)
        {
            autoheal = 1;
        }
        if (autoheallv >= 3)
        {
            autoheal = 2;
        }
        if (autoheallv >= 4)
        {
            autoheal = 3;
        }
        if (autoheallv >= 5)
        {
            autoheal = 5;
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
