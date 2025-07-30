using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public GameObject panel;
    public UpgradeButton[] buttons;

    public void ShowChoices(List<Upgrade> upgrades, System.Action<Upgrade> onSelect)
    {
        panel.SetActive(true);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < upgrades.Count)
            {
                buttons[i].Setup(upgrades[i], () =>
                {
                    panel.SetActive(false);
                    onSelect(upgrades[i]);
                });
            }
            else
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }
}
