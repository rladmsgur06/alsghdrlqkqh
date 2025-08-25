using UnityEngine;

public enum UpgradeType
{
    MaxHealth,
    Regen,
    Lightning,
    Meteor,
    Blizzard,
    //LightningAura
}

[System.Serializable]
public class Upgrade
{
    public UpgradeType type;
    public string name;
    public string description;
    public Sprite icon;
}
