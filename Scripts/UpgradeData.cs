using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
