using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GunData")]
public class GunData : ScriptableObject
{
    public int damage;
    public GunFireTypes fireType;
    public int burstShotAmount;
}
