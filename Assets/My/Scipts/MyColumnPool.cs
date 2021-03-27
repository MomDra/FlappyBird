using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyColumnPool : MonoBehaviour
{
    [SerializeField]
    int columnPoolSize = 5;
    [SerializeField]
    GameObject columnPrefab;
    [SerializeField]
    float spawnRate = 4f;
    [SerializeField]
    float columnMin = -1f;
    [SerializeField]
    float columnMax = 3.5f;

    GameObject[] columns;
    Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    float timeSinceLsatSpawned = 0f;
    float spawnXPosition = 10f;
    int currentColumn = 0;

    void Awake()
    {
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i<columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLsatSpawned += Time.deltaTime;
        
        if(!MyGameController.instance.gameOver && timeSinceLsatSpawned >= spawnRate)
        {
            timeSinceLsatSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
