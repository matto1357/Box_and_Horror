using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    MapCreate map;
    MapController controller;
    private void Start()
    {
        map = GameObject.Find("MapCreater").GetComponent<MapCreate>();
        controller = GameObject.Find("MapController").GetComponent<MapController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        if (other.gameObject.GetComponent<Player>().boxCnt < map.assets[map.mapCnt].boxCnt)
        {
            Debug.Log("たりないよ！！");
            return;
        }
        Debug.Log("clear");
        map.ReLoadMap(true);
        controller.boxCnt = 0;
    }
}
