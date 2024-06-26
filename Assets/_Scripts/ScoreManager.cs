using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    private float scoreFloat;
    [SerializeField] private TextMeshProUGUI scoreText;

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
    }
}
