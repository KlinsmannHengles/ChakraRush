using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChakraPowerUp : MonoBehaviour
{
    public delegate void addChakraDelegate(CHAKRA_COLOR color);
    public static event addChakraDelegate addChakraEvent;

    public CHAKRA_COLOR color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (addChakraEvent != null)
            {
                addChakraEvent(color);

                // Depois substituir por animação
                Destroy(this.gameObject);
            }
        }
    }
}
