using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPowerUp_Behaviour : MonoBehaviour
{
    public delegate void addHeartDelegate();
    public static event addHeartDelegate addHeartEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (addHeartEvent != null)
            {
                addHeartEvent();

                // Depois substituir por animação
                Destroy(this.gameObject);
            }
        }
    }

    public void AddSlot()
    {

    }

}
