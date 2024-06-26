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

    public delegate void activeObstacleDelegate(int obstacle);
    public static event activeObstacleDelegate activeObstacleEvent;

    public delegate void spawnHeartDelegate();
    public static event spawnHeartDelegate spawnHeartEvent;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreFloat = 0f;
    }

    private void FixedUpdate()
    {
        scoreFloat += (10 * Time.deltaTime);
        score = ((int)scoreFloat);
        scoreText.text = score.ToString();

        ObstaclesOrder();
    }

    // Futuramente é melhor mover isso aqui pra outro lugar, tipo o GameManager
    private void ObstaclesOrder()
    {
        if (score > 30 && score < 50)
        {
            activeObstacleEvent(1);
        } else if (score > 300 && score < 350)
        {
            spawnHeartEvent();
        } else if (score > 500 && score < 550)
        {
            activeObstacleEvent(2);
        } else if (score > 1000 && score < 1050)
        {
            activeObstacleEvent(3);
        }
    }
}
