using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject playerObject;

    public float chasingSpeed;
    public float turnSpeed;

    Quaternion targetQuaternion;


    void Start()
    {
        if(playerObject == null) 
        {
            try 
            {
                playerObject = GameObject.FindGameObjectWithTag("Player");
            } 
            catch 
            {
                Debug.Log("player not found");
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HeadTowards(playerObject.transform.position, chasingSpeed, Vector3.zero);
    }

    void HeadTowards(Vector3 target,float speed, Vector3 advanceSpeed) 
    {
        if ((target - transform.position).sqrMagnitude < 1f) 
        {
            Debug.Log("GameOver");
            //Do something
            return;
        }
        Vector3 moveSpeed = (target + advanceSpeed - transform.position).normalized * speed * Time.deltaTime;
        transform.position += moveSpeed;
        if(target - transform.position != Vector3.zero) 
        {
            targetQuaternion = Quaternion.LookRotation(moveSpeed, Vector3.up);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, turnSpeed);
    }
}
