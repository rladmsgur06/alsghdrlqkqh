using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int MAXHP = 100;
    public int PlayerHP = 100;
    private float healTime = 1.0f;
    private float healPassTime = 0.0f;
    public int autoheal = 0;

    public int EXP = 0;
    public int EXPToLevelUp = 100;
    public int level = 1;

    // UI 연결
    public Slider hpSlider;
    public Slider expSlider;

    public TMP_Text levelTxt;
    void Start()
    {
        if (hpSlider != null) hpSlider.maxValue = MAXHP;
        if (expSlider != null) expSlider.maxValue = EXPToLevelUp;
    }

    void Update()
    {
        Heal();
        UpdateUI();
    }

    void Heal()
    {
        if (PlayerHP < MAXHP)
        {
            if (healPassTime >= healTime)
            {
                PlayerHP += autoheal;
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

    void UpdateUI()
    {
        if (hpSlider != null) hpSlider.value = PlayerHP;
        if (expSlider != null) expSlider.value = EXP;
    }

    public void TakeDamage(int damage)
    {
        PlayerHP -= damage;
        if (PlayerHP <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Die");
        }
    }

    public void AddEXP(int amount)
    {
        EXP += amount;
        if (EXP >= EXPToLevelUp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        if (levelTxt != null)
            levelTxt.text = "Lv."+level;
 
        //Debug.Log("Level Up! 현재 레벨: " + level);
        
        EXP = 0;
        EXPToLevelUp += 50; // 다음 레벨업에 필요한 EXP 증가
        if (expSlider != null) expSlider.maxValue = EXPToLevelUp;

        Debug.Log("Level Up! 현재 레벨: " + level);

        // 여기서 선택지 UI 호출
        GetComponent<PlayerLevelSystem>()?.OnLevelUp();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("potion"))
        {
            Destroy(coll.gameObject);
            if (PlayerHP < MAXHP)
            {
                PlayerHP += 30;
            }
        }
    }
}
