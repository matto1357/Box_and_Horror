using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : SingletonMonoBehaviour<EnemySpawn>
{
    public GameObject[] enemy;

    public void SpawnEnemy(Vector3 position,int i) 
    {
        Instantiate(enemy[i], position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetEnemy();
    }

}
