using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [Header("Attributes")]
    public int damage;

    public delegate void dealDamageDelegate(int damage);
    public static event dealDamageDelegate dealDamageEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (dealDamageEvent != null)
            {
                dealDamageEvent(damage);

                // Depois substituir por animação
                Destroy(this.gameObject);
            }          
        } else if (collision.gameObject.tag == "StopPoint")
        {
            Destroy(this.gameObject);
        }
    }

}
