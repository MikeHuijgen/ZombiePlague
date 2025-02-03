using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData _gunData;
    //[SerializeField] private 

    private bool _canShoot;
    
    
    public void Shoot()
    {
        if (!_canShoot) return;

        switch (_gunData.fireType)
        {
            case GunFireTypes.Single:
                _canShoot = false;
                print("Shoot");
                break;
            case GunFireTypes.Burst:
                _canShoot = false;
                for (int i = 0; i < _gunData.burstShotAmount; i++)
                {
                    print("Shoot");
                }
                break;
            case GunFireTypes.Auto:
                print("Shoot");
                break;
        }
        
        /*if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hit)) return;

        var distanceBetweenHit = Vector3.Distance(transform.position, hit.point);
        Debug.DrawRay(transform.position, transform.forward * distanceBetweenHit, Color.red, .5f);

        if (!hit.transform.TryGetComponent(out Health health)) return;
        
        
        health.TakeDamage(_gunData.damage);*/
    }

    public void EnableShooting()
    {
        _canShoot = true;
    }
}
