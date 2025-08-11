using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("HP")]
    public int MAXHP = 100;          // 최대체력
    public int PlayerHP = 100;       // 현재체력
    public float healTime = 1.0f;    // 자동회복 주기(초)
    private float healPassTime = 0f; // 경과시간
    public int autoheal = 0;         // 초당 회복량(틱당)
    public int autoheallv = 0;       // 체력재생력 업그레이드 레벨

    [Header("EXP / Level")]
    public int EXP = 0;              // 현재 경험치 (예: 슬라임 +3, 터틀 +5)
    public int EXPToLevelUp = 50;    // 레벨업 필요 경험치 (요구: 총 50 모이면 레벨업)
    public int level = 1;

    [Header("UI")]
    public Slider hpSlider;          // 상단 HP 슬라이더
    public Slider expSlider;         // 상단 EXP 슬라이더
    public TMP_Text levelTxt;        // "Lv.X" 텍스트

    void Start()
    {
        // UI 초기화
        if (hpSlider != null)
        {
            hpSlider.minValue = 0;
            hpSlider.maxValue = MAXHP;
            hpSlider.value = PlayerHP;
        }
        if (expSlider != null)
        {
            expSlider.minValue = 0;
            expSlider.maxValue = EXPToLevelUp;
            expSlider.value = EXP;
        }
        if (levelTxt != null)
        {
            levelTxt.text = $"Lv.{level}";
        }
    }

    void Update()
    {
        ApplyAutoHealLevel(); // autoheallv → autoheal 반영
        HealTick();           // 주기적 회복 처리
        ClampHP();            // HP 상한/하한 보정
        UpdateUI();           // 슬라이더/텍스트 갱신
    }

    // autoheallv 단계에 따른 회복량 매핑
    void ApplyAutoHealLevel()
    {
        // 필요 시 원하는 표로 자유롭게 조정 가능
        if (autoheallv >= 5) autoheal = 5;
        else if (autoheallv >= 4) autoheal = 3;
        else if (autoheallv >= 3) autoheal = 2;
        else if (autoheallv >= 2) autoheal = 1;
        else autoheal = 0;
    }

    void HealTick()
    {
        if (PlayerHP < MAXHP)
        {
            if (healPassTime >= healTime)
            {
                PlayerHP += autoheal;
                healPassTime = 0f;
            }
            else
            {
                healPassTime += Time.deltaTime;
            }
        }
    }

    void ClampHP()
    {
        if (PlayerHP > MAXHP) PlayerHP = MAXHP;
        if (PlayerHP < 0) PlayerHP = 0;
    }

    void UpdateUI()
    {
        if (hpSlider != null) hpSlider.value = PlayerHP;
        if (expSlider != null) expSlider.value = EXP;
        if (levelTxt != null) levelTxt.text = $"Lv.{level}";
    }

    public void TakeDamage(int damage)
    {
        PlayerHP -= damage;
        if (PlayerHP <= 0)
        {
            // 사망 처리
            Debug.Log("Die");
            Destroy(gameObject);
        }
    }

    public void AddEXP(int amount)
    {
        EXP += amount;
        // 여러 번에 걸쳐 초과될 수도 있으므로 while 사용 가능
        if (EXP >= EXPToLevelUp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        Debug.Log("Level Up! 현재 레벨: " + level);

        // 경험치 리셋 및 다음 요구치 증가(원하면 고정 50 유지도 가능)
        EXP = 0;
        EXPToLevelUp += 50; // 다음 레벨 요구치 증가. 고정 50을 원하면 이 줄 삭제.
        if (expSlider != null) expSlider.maxValue = EXPToLevelUp;

        // 레벨 텍스트는 UpdateUI에서 갱신되지만 즉시 반영 원하면 아래 유지
        if (levelTxt != null) levelTxt.text = $"Lv.{level}";

        // 레벨업 선택지 UI 오픈
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
                if (PlayerHP > MAXHP) PlayerHP = MAXHP;
            }
        }
    }

    // MAXHP가 업그레이드로 변경될 때 호출하면 슬라이더도 함께 갱신됨
    public void RefreshHPMax()
    {
        if (hpSlider != null) hpSlider.maxValue = MAXHP;
        if (PlayerHP > MAXHP) PlayerHP = MAXHP;
        UpdateUI();
    }
}
