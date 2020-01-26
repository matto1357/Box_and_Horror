using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : SingletonMonoBehaviour<EnemySpawn>
{
    public GameObject[] enemy;


    public void SpawnEnemy(Vector3 position,int i) 
    {
        Instantiate(enemy[0], position, Quaternion.identity,transform);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetEnemy();
    }

    public void ResetEnemy()
    {
        foreach (Transform trns in this.transform)
        {
            trns.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetEnemy();
        }
    }

}
