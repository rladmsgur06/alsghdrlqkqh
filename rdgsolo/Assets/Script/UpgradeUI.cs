using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public GameObject panel;
    public UpgradeButton[] buttons;

    public void ShowChoices(List<Upgrade> upgrades, System.Action<Upgrade> onSelect)
    {
        panel.SetActive(true);
        Time.timeScale = 0f;

        for (int i = 0; i < buttons.Length; i++)
        {
            var iLocal = i;
            if (i < upgrades.Count)
            {
                buttons[i].Setup(upgrades[i], () =>
                {
                    panel.SetActive(false);
                    Time.timeScale = 1f; // 재개(선택)
                    onSelect(upgrades[iLocal]);
                });
                buttons[i].gameObject.SetActive(true);
            }
            else
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }
}
