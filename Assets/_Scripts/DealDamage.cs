using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [Header("Attributes")]
    public int damage;
    public ActualChakra actualChakra;

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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (dealDamageEvent != null)
            {
                if (actualChakra != collision.GetComponent<PlayerMovement>().actualChakra)
                {
                    dealDamageEvent(damage);
                }                

                // Depois substituir por anima��o
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.tag == "StopPoint")
        {
            Destroy(this.gameObject);
        }
    }

}
