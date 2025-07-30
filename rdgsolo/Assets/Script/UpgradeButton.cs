using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text nameText;
    public Text descriptionText;
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
