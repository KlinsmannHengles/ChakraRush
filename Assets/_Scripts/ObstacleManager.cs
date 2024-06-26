using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

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
    [SerializeField] private GameObject secondObstacle3;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (isActive2)
        {
            timer2 += Time.deltaTime;

            if (timer2 > spawnRate2)
            {
                SecondObstacleSpawn();
                timer2 = 0f;
            }
        }
        
    }

    private void FirstObstacleSpawn()
    {
        GameObject obstacle = Instantiate(firstObstacle, spawnPoint.transform);
        spawnPoint.transform.DetachChildren();
        obstacle.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, firstObstacleSpeed, 0f));

        spawnPoint.transform.position = new Vector3(Random.Range(-120f, 120f), -140f, 0f);
    }

    private void SecondObstacleSpawn()
    {
        GameObject obstacle = Instantiate(secondObstacle, spawnPoint2.transform);
        spawnPoint2.transform.DetachChildren();
        obstacle.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, firstObstacleSpeed, 0f));
    }

    private void ThirdObstacleBehaviour()
    {

    }
}
