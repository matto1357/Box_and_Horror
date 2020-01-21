using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{

    //**Scene camera also included!!
    void OnBecameVisible() 
    {
        Debug.Log("visible");    
    }

    void OnBecameInvisible() 
    {
        Debug.Log("Invisible");
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
