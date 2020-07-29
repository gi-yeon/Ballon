using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase
{
    public float maxHp;
    public float currentHp;
    public float damage;

    protected float playerRealizedRange = 10f;
    protected float attackRange = 5f;
    protected float attackCoolTime = 5f;
    protected float attackCoolTimeCacl = 5f;

    protected float moveSpeed = 2f;
    protected GameObject Player;
    protected float distance;

    void SearchEnemy()
    {

    }

    void AttakEnemy()
    {

    }
}
//public class SpawnManager : MonoBehaviour
//{
//    public float spawnTime = 3f;
//    public float curTime;
//    public Transform[] spawnPoints;
//    public GameObject enemy;

//    private void Update()
//    {
//        if (curTime >= spawnTime)
//        {
//            int x = Random.Range(0, spawnPoints.Length);
//            SpawnEnemy(x);
//        }
//        curTime += Time.deltaTime;
//    }
//    public void SpawnEnemy(int ranNum)
//    {
//        curTime = 0;
//        Instantiate(enemy, spawnPoints[ranNum]);
//    }

//}