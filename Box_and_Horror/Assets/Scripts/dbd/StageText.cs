using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageText : MonoBehaviour
{
    GameObject player;
    float lookDistance = 4f;
    TextMesh mesh;
    string text;
    bool flag = false;
    private void Start()
    {
        mesh = GetComponent<TextMesh>();
        text = mesh.text;
        player = GameObject.FindGameObjectWithTag("Player");
        mesh.text = "";
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(player.transform.position,this.transform.position);
        if (distance <= lookDistance)
        {   
            mesh.text = text;
            flag = true;
        }
        else if(flag)
        {
            text = mesh.text;
            mesh.text = "";
            flag = false;
        }
    }
    
}
