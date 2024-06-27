using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CHAKRA_COLOR { PURPLE, DARK_BLUE, LIGHT_BLUE};
public class ChakraManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject chakra_purple;
    public GameObject chakra_darkBlue;
    public GameObject chakra_lightBlue;

    [Header("Chakras")]
    public GameObject purple;
    public GameObject darkBlue;
    public GameObject lightBlue;

    private bool purpleSpawned = false;
    private bool darkBlueSpawned = false;
    private bool lightBlueSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        ChakraPowerUp.addChakraEvent += AddChakra;
        ScoreManager.spawnChakraEvent += SpawnChakra;
    }

    private void OnDisable()
    {
        ChakraPowerUp.addChakraEvent -= AddChakra;
        ScoreManager.spawnChakraEvent -= SpawnChakra;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddChakra(CHAKRA_COLOR color)
    {
        if (color == CHAKRA_COLOR.PURPLE)
        {
            chakra_purple.SetActive(true);
        } else if (color == CHAKRA_COLOR.DARK_BLUE)
        {
            chakra_darkBlue.SetActive(true);
        } else if (color == CHAKRA_COLOR.LIGHT_BLUE)
        {
            chakra_lightBlue.SetActive(true);
        }
    }

    public void SpawnChakra(CHAKRA_COLOR color)
    {
        if (color == CHAKRA_COLOR.PURPLE && purpleSpawned == false)
        {
            Instantiate(purple, new Vector3(-90f, -40f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            purpleSpawned = true;
        }
        else if (color == CHAKRA_COLOR.DARK_BLUE && darkBlueSpawned == false)
        {
            Instantiate(darkBlue, new Vector3(-20f, -60f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            darkBlueSpawned = true;
        }
        else if (color == CHAKRA_COLOR.LIGHT_BLUE && lightBlueSpawned == false)
        {
            Instantiate(lightBlue, new Vector3(90f, -50f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            lightBlueSpawned = true;
        }
    }
}
