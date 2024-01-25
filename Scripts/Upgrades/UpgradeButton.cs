using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    // Referanse til texten den skall skifte
    public Text upgradeText;



    // Skifter texten til navnet på oppgradering som er valgt
    public void SetText(UpgradeData upgradeData)
    {
            upgradeText.text = upgradeData.Name;

    }
    //  Setter texten till null (ingenting)
    public void Clean()
    {
        upgradeText.text = null;
    }
}
