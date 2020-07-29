using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject monster;
    List<GameObject> enemy = new List<GameObject>();
    public Transform[] spawnPoints;

    public bool enableSpawn = false; //리스폰 여부를 결정
    private float randomX;
    private float randomY;

    public float spawnTime = 3f;
    public float curTime;

    public int enemyCount=0;
    public int enemyMaxCount = 10;

    private void SpawnLocation()
    {
        randomX = Random.Range(-100.0f, 100.0f); //리스폰 될 랜덤한 x좌표 설정
        randomY = Random.Range(-100.0f, 100.0f); //리스폰 될 랜덤한 y좌표 설정
        monster.SetActive(true);
    }
    private void SpawnEnemy()
    {
        enemyCount += 1;
        SpawnLocation();
        Instantiate(monster, new Vector3(randomX, randomY, 0f), Quaternion.identity);
        enemy.Add(monster.gameObject);
        monster.SetActive(false);
    }

    private void Update()
    {
        if (curTime >= spawnTime&&enemyCount<enemyMaxCount)
        {
            curTime = 0;
            SpawnEnemy();
        }
        curTime += Time.deltaTime;
    }
}

