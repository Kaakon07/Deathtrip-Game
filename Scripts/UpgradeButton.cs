using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text upgradeText;

    public void SetText(UpgradeData upgradeData)
    {
            upgradeText.text = upgradeData.Name;

    }

    public void Clean()
    {
        upgradeText.text = null;
    }
}
