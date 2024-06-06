using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("First Obstacle")]
    [SerializeField] private GameObject firstObstacle;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private float firstObstacleSpeed;
    [SerializeField] private float spawnRate;
    [SerializeField] private float timer = 0f;

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
        timer += Time.deltaTime;

        if (timer > spawnRate)
        {
            FirstObstacleSpawn();
            timer = 0f;
        }
    }

    private void FirstObstacleSpawn()
    {
        GameObject obstacle = Instantiate(firstObstacle, spawnPoint.transform);
        spawnPoint.transform.DetachChildren();
        obstacle.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, firstObstacleSpeed, 0f));

        spawnPoint.transform.position = new Vector3(Random.Range(-120f, 120f), -140f, 0f);
    }
}
