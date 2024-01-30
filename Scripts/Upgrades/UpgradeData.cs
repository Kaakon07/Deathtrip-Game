using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Lager en enum med navnet upgradeType
public enum UpgradeType
{
    BulletUpgrade,
    StatUpgrade
}

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string Name;
    public string statType;
    public float amount;
    public float Rarity;
    public int amountLimit;
    public Sprite upgradePic;
}
