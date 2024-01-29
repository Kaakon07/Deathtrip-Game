using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeImage : MonoBehaviour
{
    // Referanse til texten den skall skifte
    public Image upgradeImage;




    // Skifter texten til navnet på oppgradering som er valgt
    public void SetImage(UpgradeData upgradeData)
    {
        upgradeImage.sprite = upgradeData.upgradePic;

    }


    //  Setter texten till null (ingenting)
    public void CleanImage()
    {
        upgradeImage.sprite = null;
    }
}
