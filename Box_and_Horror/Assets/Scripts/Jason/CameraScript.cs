using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //incomplete

    public GameObject player;

    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position = player.transform.position;//これでいいみたい

        GetComponentInChildren<Light>().intensity -= 0.02f * Time.deltaTime;
    }
}
