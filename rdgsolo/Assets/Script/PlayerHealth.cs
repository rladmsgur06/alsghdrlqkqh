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
        Debug.Log("Damage "+damage+ " taken");
        Debug.Log("HP" + PlayerHP);
        PlayerHP = PlayerHP - damage;
    }
}
