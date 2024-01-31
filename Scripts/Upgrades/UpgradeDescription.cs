using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeDescription : MonoBehaviour
{
    // Referanse til texten den skall skifte
    public Text upgradeDescription;




    // Skifter texten til navnet på oppgradering som er valgt
    public void SetDescriptionText(UpgradeData upgradeData)
    {
        upgradeDescription.text = upgradeData.description;

    }


    //  Setter texten till null (ingenting)
    public void Clean()
    {
        upgradeDescription.text = null;
    }
}
