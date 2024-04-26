using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunStats", menuName = "GunStats")]

public class Gun_Stats : ScriptableObject
{
    public float damageMult;
    public float fireRateMult;
    public float fireForceMult;
    public float reloadTimeMult;
    public int chamberSizeAdd;
    public int chamberSizeMult;
}
