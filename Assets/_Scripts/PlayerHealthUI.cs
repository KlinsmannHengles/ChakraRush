using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public int initialHearts;
    public GameObject[] hearts;
    public GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.onLoseHealthEvent += LoseHeart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHeart(int damage)
    {
        if (playerHealth.health > -1)
        {
            hearts[playerHealth.health].SetActive(false);
        }
        
    }
}
