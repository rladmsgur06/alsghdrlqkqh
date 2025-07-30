using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSystem : MonoBehaviour
{
    public List<Upgrade> allUpgrades;           // 모든 강화 목록 (Inspector에서 등록)
    public UpgradeUI upgradeUI;                 // UI 프리팹

    public void OnLevelUp()
    {
        List<Upgrade> choices = GetRandomUpgrades(3);
        upgradeUI.ShowChoices(choices, ApplyUpgrade);
    }

    List<Upgrade> GetRandomUpgrades(int count)
    {
        List<Upgrade> pool = new List<Upgrade>(allUpgrades);
        List<Upgrade> result = new List<Upgrade>();

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int index = Random.Range(0, pool.Count);
            result.Add(pool[index]);
            pool.RemoveAt(index);
        }

        return result;
    }

    void ApplyUpgrade(Upgrade upgrade)
    {
        Debug.Log("선택한 강화: " + upgrade.name);

        var stats = GetComponent<PlayerHealth>();
        var skills = GetComponent<PlayerSkillManager>(); // 아래에서 정의할 클래스

        switch (upgrade.type)
        {
            case UpgradeType.MaxHealth:
                stats.MAXHP += 20;
                stats.PlayerHP = stats.MAXHP;
                break;

            case UpgradeType.Regen:
                stats.autoheal += 1;
                break;

            case UpgradeType.Lightning:
                skills?.UpgradeLightning();
                break;

            case UpgradeType.Meteor:
                skills?.UpgradeMeteor();
                break;

            case UpgradeType.Blizzard:
                skills?.UpgradeBlizzard();
                break;

            case UpgradeType.LightningAura:
                skills?.UpgradeLightningAura();
                break;
        }
    }
}
