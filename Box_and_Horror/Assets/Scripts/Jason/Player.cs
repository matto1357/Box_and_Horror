using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    public float playerFallvalue = -10.0f;

    
    void Update()
    {
        PlayerMovementUpdate();
        GameOverUpdate();
    }

    void PlayerMovementUpdate() 
    {
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            this.transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        } 
        else if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            this.transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.UpArrow)) 
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movementSpeed * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.DownArrow)) 
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - movementSpeed * Time.deltaTime);
        }
    }

    void GameOverUpdate() 
    {
        if(this.transform.position.y < playerFallvalue) 
        {
            //Debug.Log("gameover");
            //Do something here
        }
    }
}
