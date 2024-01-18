    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradableScript : MonoBehaviour
{


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
