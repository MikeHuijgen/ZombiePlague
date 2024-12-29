using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int damage;

    //Even met een ray cast uiteindelijk veranderen naar projects of iets meer visual
    public void Shoot()
    {
        if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hit)) return;
        
        Debug.DrawLine(transform.position, hit.transform.position, Color.red, .5f);

        if (!hit.transform.TryGetComponent(out Health health)) return;
        
        
        health.TakeDamage(damage);
    }
}
