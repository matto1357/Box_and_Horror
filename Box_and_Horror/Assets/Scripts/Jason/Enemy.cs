using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject playerObject;

    public float chasingSpeed;
    public float turnSpeed;

    Quaternion targetQuaternion;

    public NavMeshAgent agent;


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

    void Update()
    {
        //HeadTowards(playerObject.transform.position, chasingSpeed, Vector3.zero);
        agent.SetDestination(playerObject.transform.position);
        //CheckDistance();
    }

    void HeadTowards(Vector3 target,float speed, Vector3 advanceSpeed) 
    {
        if ((target - transform.position).sqrMagnitude < 1f) 
        {
            Debug.Log("GameOver");
            //ここで敵がplayerを捕まえたら何々する
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

    void CheckDistance() 
    {
        float dis = Vector3.Distance(playerObject.transform.position, transform.position);
        Debug.Log(dis);
        if (dis <1.0f) 
        {
            agent.Stop();
            Debug.Log("weee");
        }
    }

    public void Warp(Vector3 pos)
    {
        agent.Warp(pos);
    }
}
