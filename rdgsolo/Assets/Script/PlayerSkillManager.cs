using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    public int lightningLevel = 0;
    public int meteorLevel = 0;
    public int blizzardLevel = 0;
    public int auraLevel = 0;

    public void UpgradeLightning() => lightningLevel++;
    public void UpgradeMeteor() => meteorLevel++;
    public void UpgradeBlizzard() => blizzardLevel++;
    public void UpgradeLightningAura() => auraLevel++;
}
