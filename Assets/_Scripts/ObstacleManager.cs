using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using DG.Tweening;

public class ObstacleManager : MonoBehaviour
{
    [Header("First Obstacle")]
    [SerializeField] private bool isActive;
    [SerializeField] private GameObject firstObstacle;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private float firstObstacleSpeed;
    [SerializeField] private float spawnRate;
    [SerializeField] private float timer = 0f;

    [Header("Second Obstacle")]
    [SerializeField] private bool isActive2;
    [SerializeField] private GameObject secondObstacle;
    [SerializeField] private GameObject spawnPoint2;
    [SerializeField] private float secondObstacleSpeed;
    [SerializeField] private float spawnRate2;
    [SerializeField] private float timer2 = 0f;

    [Header("Third Obstacle")]
    [SerializeField] private bool isActive3;
    [SerializeField] private GameObject thirdObstacle;
    private bool canActive = true;
    [SerializeField] public Vector3[] path;

    [Header("Fourth Obstacle")]
    [SerializeField] private bool isActive4;
    [SerializeField] private GameObject fourthObstacle;
    [SerializeField] private GameObject spawnPoint3;
    [SerializeField] private float fourthObstacleSpeed;
    [SerializeField] private float spawnRate4;
    [SerializeField] private float timer4 = 0f;

    [Header("HeartAppearingManager")]
    [SerializeField] private bool isActiveHeart;
    private bool canActiveHeartPowerUp = true;
    [SerializeField] private GameObject heartPowerUp;
    [SerializeField] private float heartSpeed;


    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.activeObstacleEvent += ActiveObstacles;
        ScoreManager.spawnHeartEvent += SpawnHeartUpgrade;
    }

    private void OnDisable()
    {
        ScoreManager.activeObstacleEvent -= ActiveObstacles;
        ScoreManager.spawnHeartEvent -= SpawnHeartUpgrade;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            timer += Time.deltaTime;

            if (timer > spawnRate)
            {
                FirstObstacleSpawn();
                timer = 0f;
            }
        }

        if (isActive4)
        {
            timer4 += Time.deltaTime;

            if (timer4 > spawnRate4)
            {
                FourthObstacleSpawn();
                timer4 = 0f;
            }
        }

        if (isActive2)
        {
            timer2 += Time.deltaTime;

            if (timer2 > spawnRate2)
            {
                SecondObstacleSpawn();
                timer2 = 0f;
            }
        }

        if (isActive3 && canActive)
        {
            ThirdObstacleBehaviour1();
            canActive = false;
        }
        
    }

    private void ActiveObstacles(int obstacle)
    {
        if (obstacle == 1)
        {
            isActive = true;
        } else if (obstacle == 2)
        {
            isActive2 = true;
        } else if (obstacle == 3)
        {
            isActive3 = true;
        } else if (obstacle == 4)
        {
            isActive4 = true;
        } else
        {
            Debug.Log("N�o tem obstaculo pra ativar");
        }
    }

    private void FirstObstacleSpawn()
    {
        GameObject obstacle = Instantiate(firstObstacle, spawnPoint.transform);
        spawnPoint.transform.DetachChildren();
        obstacle.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, firstObstacleSpeed, 0f));

        spawnPoint.transform.position = new Vector3(Random.Range(-100f, 100f), -140f, 0f);
    }

    private void FourthObstacleSpawn()
    {
        GameObject obstacle = Instantiate(fourthObstacle, spawnPoint3.transform);
        spawnPoint3.transform.DetachChildren();
        obstacle.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, fourthObstacleSpeed, 0f));

        spawnPoint3.transform.position = new Vector3(Random.Range(-90f, 90f), -140f, 0f);
    }

    private void SecondObstacleSpawn()
    {
        GameObject obstacle = Instantiate(secondObstacle, spawnPoint2.transform);
        spawnPoint2.transform.DetachChildren();
        obstacle.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, firstObstacleSpeed, 0f));
    }

    private void ThirdObstacleBehaviour1()
    {
        thirdObstacle.transform.DOScale(new Vector3(0.5f, 0.5f, 1f), 7f).onComplete = ThirdObstacleBehaviour2;
    }

    private void ThirdObstacleBehaviour2()
    {
        thirdObstacle.transform.DOPath(path, 40f).SetEase(Ease.Linear).onComplete = ThirdObstacleBehaviour3;
    }

    private void ThirdObstacleBehaviour3()
    {
        thirdObstacle.transform.DOScale(new Vector3(1f, 1f, 1f), 10f).onComplete = EnableThirdObstacleAgain;
    }

    private void EnableThirdObstacleAgain()
    {
        isActive3 = false;
        canActive = true;
    }

    private void SpawnHeartUpgrade()
    {
        if (canActiveHeartPowerUp)
        {
            GameObject heart = Instantiate(heartPowerUp, spawnPoint.transform);
            spawnPoint.transform.DetachChildren();
            heart.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, heartSpeed, 0f));

            canActiveHeartPowerUp = false;
        }
    }
}
