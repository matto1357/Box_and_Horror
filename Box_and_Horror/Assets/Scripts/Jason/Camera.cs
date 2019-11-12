using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //incomplete

    public GameObject player;

    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position = player.transform.position;
    }
}
