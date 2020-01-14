using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{

    public AudioClip sfxSound1;
    public AudioClip sfxSound2;
    public AudioClip sfxSound3;

    EnemySpawn enemySpawn;
    public Transform spawnPosition;

    void Start() 
    {
        enemySpawn = GetComponent<EnemySpawn>();    
    }

    void Update()
    {
        //Play 1
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            SoundManager.sSingleton.PlaySingle(sfxSound1);
            enemySpawn.SpawnEnemy1(spawnPosition.position);
        }

        //Play 1 of the multiple choices
        else if (Input.GetKeyDown(KeyCode.Y)) 
        {
            SoundManager.sSingleton.RandomizeSfx(sfxSound1,sfxSound2,sfxSound3);
        }
    }
}
