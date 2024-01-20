    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradableScript : MonoBehaviour
{
    public BulletScript bulletScript;
    public ValueScript valueScript;
    public GameObject player;
    public List<UpgradeButton> upgradeButton;

    private void Start()
    {
        HideText();
    }
    public void StatUpgrade(float stat, float newStat)
    {
        stat += newStat;
    }

    public void ShowUpgrade(List<UpgradeData> upgradeData)
    {
        Clean();
        gameObject.SetActive(true);
        Time.timeScale = 0;

        for (int i = 0; i < upgradeButton.Count; i++)
        
        {
            upgradeButton[i].gameObject.SetActive(true);
        }

        for(int i=0; i <upgradeData.Count;i++) 
        {
            upgradeButton[i].SetText(upgradeData[i]);
        }
    }

    public void Clean()
    {
        for (int i=0;i <upgradeButton.Count;i++) 
        {
            upgradeButton[i].Clean();
        }
    }

    public void Upgrade(int pressedButtonID)
    {
        player.GetComponent<ValueScript>().Upgrade(pressedButtonID);
    }
    public void HideUpgrade()
    {
        HideText();
        gameObject.SetActive(false);
        Time.timeScale = 1;


    }

    private void HideText()
    {
        for (int i = 0; i < upgradeButton.Count; i++)

        {
            upgradeButton[i].gameObject.SetActive(false);
        }
    }
}
