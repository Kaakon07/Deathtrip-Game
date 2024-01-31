        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradableScript : MonoBehaviour
{
    // referanser til scripter og objekter
    public BulletScript bulletScript;
    public ValueScript valueScript;
    public GameObject player;


    // Lager en liste som du putter teksten du vill skifte i
    public List<UpgradeButton> upgradeText;

    public List<UpgradeDescription> upgradeDescription;

    public List<UpgradeImage> upgradeImage;

    // Metode som lar deg legge till et nummer til en predefinert stat
    public void StatUpgrade(float stat, float newStat)
    {
        stat += newStat;
    }

    // viser oppgraderings menyen
    public void ShowUpgrade(List<UpgradeData> upgradeData)
    {
        // kaller clean metoden, definert nedenfor
        Clean();

        // viser oppgraderings menyen
        gameObject.SetActive(true);

        // pauser spillet
        Time.timeScale = 0;

        // skifter teksten på oppgraderings menyen til vilken oppgradering den har valgt
        for (int i = 0; i < upgradeData.Count; i++)
        {
            upgradeText[i].SetUpgradeText(upgradeData[i]);
        }
        for (int i = 0; i < upgradeData.Count; i++)
        {
            upgradeImage[i].SetImage(upgradeData[i]);
        }
        for (int i = 0; i < upgradeData.Count; i++)
        {
            upgradeDescription[i].SetDescriptionText(upgradeData[i]);
        }



    }
    // setter all teksten till null
    public void Clean()
    {
        for (int i=0;i < upgradeText.Count;i++) 
        {
            upgradeText[i].Clean();
        }
        for (int i = 0; i < upgradeImage.Count; i++)
        {
            upgradeImage[i].CleanImage();
        }

    }


    // kaller metoden Upgrade() fra ValueScript scripten, og legger til parametern pressedButtonID som parameter til den metoden
    public void Upgrade(int pressedButtonID)
    {
        player.GetComponent<ValueScript>().Upgrade(pressedButtonID);
    }

    // Gjemmer oppgraderings menyen
    public void HideUpgrade()
    {

        gameObject.SetActive(false);
        Time.timeScale = 1;


    }


}
