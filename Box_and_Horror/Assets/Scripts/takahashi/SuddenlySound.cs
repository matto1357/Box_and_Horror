using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenlySound : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClip;
    AudioSource audioSource;

    int timeManagement = 6;
    float timeUP;
    [SerializeField]
    int maxInterval;
    [SerializeField]
    int miniInterval;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeUP += Time.deltaTime;
        if(timeUP > timeManagement)
        {
            suddenly();
            timeManagement = Random.Range(miniInterval, maxInterval);
            timeUP = 0;
        }
    }

    private void suddenly()
    {
        int soundNum = Random.Range(0, 6);
        audioSource.clip = audioClip[soundNum];
        audioSource.Play();
    }
}
