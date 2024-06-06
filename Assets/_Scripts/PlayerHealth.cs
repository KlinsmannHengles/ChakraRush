using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public delegate void OnLoseHealth(int damage);
    public static event OnLoseHealth onLoseHealthEvent;

    // Start is called before the first frame update
    void Start()
    {
        DealDamage.dealDamageEvent += LoseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoseHealth(int damage)
    {
        health = health - damage;

        if (health < 0)
        {
            health = 0;
        }

        if (onLoseHealthEvent != null)
        {
            onLoseHealthEvent(damage);
        }
    }
}
