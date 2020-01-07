using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public void SpawnEnemy1(Vector3 position) 
    {
        Instantiate(enemy1, position, Quaternion.identity);
    }

    public void SpawnEnemy2(Vector3 position) 
    {
        Instantiate(enemy2, position, Quaternion.identity);
    }

    public void SpawnEnemy3(Vector3 position) 
    {
        Instantiate(enemy3, position, Quaternion.identity);
    }
}
