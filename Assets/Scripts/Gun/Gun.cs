using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData _gunData;

    private bool _canShoot;
    
    
    public void Shoot()
    {
        if (!_canShoot) return;

        switch (_gunData.fireType)
        {
            case GunFireTypes.Single:
                _canShoot = false;
                print("Single Shoot");
                break;
            case GunFireTypes.Burst:
                _canShoot = false;
                for (int i = 0; i < _gunData.burstShotAmount; i++)
                {
                    print("Burst Shoot");
                }
                break;
            case GunFireTypes.Auto:
                print("Auto Shoot");
                break;
        }
    }

    public void EnableShooting()
    {
        _canShoot = true;
    }
}
