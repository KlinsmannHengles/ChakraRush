using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int score;
    private float scoreFloat;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    private bool alreadySet = false;

    public delegate void activeObstacleDelegate(int obstacle);
    public static event activeObstacleDelegate activeObstacleEvent;

    public delegate void spawnHeartDelegate();
    public static event spawnHeartDelegate spawnHeartEvent;

    public delegate void spawnChakraDelegate(CHAKRA_COLOR color);
    public static event spawnChakraDelegate spawnChakraEvent;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.onDieEvent += SetFinalScore;

        score = 0;
        scoreFloat = 0f;
    }

    private void OnDisable()
    {
        PlayerHealth.onDieEvent -= SetFinalScore;
    }

    private void FixedUpdate()
    {
        scoreFloat += (10 * Time.deltaTime);
        score = ((int)scoreFloat);
        scoreText.text = score.ToString();

        ObstaclesOrder();
    }

    private void SetFinalScore()
    {
        if (alreadySet == false)
        {
            finalScoreText.text = scoreText.text;
            alreadySet = true;
        }       
    }

    // Futuramente é melhor mover isso aqui pra outro lugar, tipo o GameManager
    private void ObstaclesOrder()
    {
        if (score > 40 && score < 50)
        {     
            activeObstacleEvent(4);                   
        } else if (score > 200 && score < 210)
        {
            spawnHeartEvent();
            activeObstacleEvent(1);
        } else if (score > 300 && score < 310)
        {
            spawnHeartEvent();
            spawnChakraEvent(CHAKRA_COLOR.PURPLE);
        } else if (score > 400 && score < 410)
        {
            activeObstacleEvent(3);
        } else if (score > 500 && score < 510)
        {   
            spawnHeartEvent();
        } else if (score > 600 && score < 610)
        {
            spawnChakraEvent(CHAKRA_COLOR.DARK_BLUE);
        } else if (score > 700 && score < 710)
        {
            spawnHeartEvent();           
        } else if (score > 800 && score < 810)
        {
            spawnHeartEvent();
        } else if (score > 900 && score < 910)
        {
            spawnChakraEvent(CHAKRA_COLOR.LIGHT_BLUE);
        } else if (score > 1000 && score < 1010)
        {
            activeObstacleEvent(2);
            spawnHeartEvent();
        } else if (score > 1100 && score < 1110)
        {
            spawnHeartEvent();
        } else if (score > 1200 && score < 1210)
        {
            activeObstacleEvent(3);
        }
        else if (score > 1300 && score < 1310)
        {
            spawnHeartEvent();
        }
        else if (score > 1400 && score < 1410)
        {
            spawnHeartEvent();
        }
        else if (score > 1500 && score < 1510)
        {
            activeObstacleEvent(3);
        }
        else if (score > 1600 && score < 1610)
        {
            spawnHeartEvent();
        }
        else if (score > 1700 && score < 1710)
        {
            spawnHeartEvent();
        }
        else if (score > 1800 && score < 1810)
        {
            activeObstacleEvent(3);
        }
        else if (score > 1900 && score < 1910)
        {
            spawnHeartEvent();
        }
        else if (score > 2000 && score < 2010)
        {
            spawnHeartEvent();
        }
    }
}
