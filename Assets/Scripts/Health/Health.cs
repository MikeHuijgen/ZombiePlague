using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool isInvincible;
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 && !isInvincible)
        {
            Destroy(gameObject);
        }
    }
}
