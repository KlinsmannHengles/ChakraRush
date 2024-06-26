using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public int initialHearts;
    public int actualHearts;
    public GameObject[] hearts;
    public GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.onLoseHealthEvent += LoseHeart;
        HeartPowerUp_Behaviour.addHeartEvent += AddHeartSlot;

        actualHearts = initialHearts;
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

    public void AddHeart()
    {
        foreach (var heart in hearts)
        {
            if (heart.activeInHierarchy == true && playerHealth.health <= 5)
            {
                playerHealth.health++;
                heart.SetActive(true);
                return;
            }
        }
    }

    public void AddHeartSlot()
    {
        if (slots[3].activeInHierarchy == false)
        {
            actualHearts++;
            slots[3].SetActive(true);
            AddHeart();
        } else if (slots[4].activeInHierarchy == false)
        {
            actualHearts++;
            slots[4].SetActive(true);
            AddHeart();
        } else
        {
            Debug.Log("You have enough hearts: The max is 5!!!");
        }
    }
}
