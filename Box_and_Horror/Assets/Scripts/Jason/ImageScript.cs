using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ImageScript : MonoBehaviour
{
    public RawImage[] rawImage;
    public float appearanceTime = 0.1f;
    public float minRandTimer = 5f;
    public float maxRandTimer = 10f;

    public AudioClip audio;

    float timer;
    float temp;
    bool isCollectedBox = false;
    bool isRunning = false;


    void Start()
    {
        temp = RandomTimer(minRandTimer, maxRandTimer);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            StartCoroutine(PopImageInOut(rawImage[RandomImage()], appearanceTime));
            isCollectedBox = true;
        }

        if (isCollectedBox) 
        {
            Timer(temp);
        }
    }

    public void Function()
    {
        StartCoroutine(PopImageInOut(rawImage[RandomImage()], appearanceTime));
        isCollectedBox = true;
    }

    void Timer(float val) 
    {
        timer += Time.deltaTime;
        if (timer > val) 
        {
            StartCoroutine(PopImageInOut(rawImage[RandomImage()], appearanceTime));
            temp = RandomTimer(minRandTimer, maxRandTimer);
            timer = 0f;
        }
        //Debug.Log(timer + "  " + val);
    }



    float RandomTimer(float min, float max) 
    {
        float value = UnityEngine.Random.Range(min, max);
        return value;
    }

    int RandomImage() 
    {
        int rand = UnityEngine.Random.Range(0, rawImage.Length);
        return rand;
    }

    IEnumerator PopImageInOut(RawImage img, float speed) 
    {
        SoundManager.sSingleton.PlaySingle(audio);
        img.enabled = true;
        yield return new WaitForSeconds(speed);
        img.enabled = false;
    }

}
