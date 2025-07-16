using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int PlayerHP = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        //Debug.Log("Damage "+damage+ " taken");
        PlayerHP = PlayerHP - damage;
        Debug.Log("HP" + PlayerHP);       
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "potion")
        {
            if (PlayerHP < 100)
            {
                PlayerHP += 10;
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
