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

    // Start is called before the first frame update
    void Start()
    {
        ChakraPowerUp.addChakraEvent += AddChakra;
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
}
