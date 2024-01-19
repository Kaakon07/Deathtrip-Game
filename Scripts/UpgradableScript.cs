    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradableScript : MonoBehaviour
{
    public BulletScript bulletScript;
    public ValueScript valueScript;

    public void StatUpgrade(float stat, float newStat)
    {
        stat += newStat;
    }

    public void ShowUpgrade()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void HideUpgrade()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
