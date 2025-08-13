using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image icon;
    public Button button;

    public void Setup(Upgrade upgrade, System.Action onClick)
    {
        nameText.text = upgrade.name;
        descriptionText.text = upgrade.description;
        icon.sprite = upgrade.icon;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => onClick());
    }
}
