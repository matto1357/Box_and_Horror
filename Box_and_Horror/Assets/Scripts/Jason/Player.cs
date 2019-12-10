using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float movementSpeed = 5.0f; //playerの速さ
    public float rotationSpeed = 5.0f; //playerの曲がりの速さ
    public float playerFallvalue = -10.0f; //どこまで落ちたらgameover

    Rigidbody rb;

   
    void Start() 
    {
        rb = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        PlayerMovementUpdate();
        GameOverUpdate();
        PlayerRotate();
    }


    void PlayerMovementUpdate() 
    {
        /*
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
        */
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        } 
        else if (Input.GetKey(KeyCode.D)) 
        {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            transform.position -= transform.right * Time.deltaTime * movementSpeed;
        }
    }

    void PlayerRotate() 
    {
        float v = rotationSpeed * Input.GetAxis("Mouse X");

        transform.Rotate(0, v, 0);
    }

    void GameOverUpdate() 
    {
        if(this.transform.position.y < playerFallvalue) 
        {
            //Debug.Log("gameover");
            //Do something here
            //落ちたら何々する
        }
    }
}
