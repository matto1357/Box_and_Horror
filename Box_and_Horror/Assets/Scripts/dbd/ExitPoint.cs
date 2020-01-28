using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPoint : MonoBehaviour
{
    MapCreate map;
    MapController controller;
    GameObject obj;
    private void Start()
    {
        map = GameObject.Find("MapCreater").GetComponent<MapCreate>();
        controller = GameObject.Find("MapController").GetComponent<MapController>();
        obj = GameObject.Find("Text");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") {
        }
        if (other.gameObject.GetComponent<Player>().boxCnt < map.assets[map.mapCnt].boxCnt)
        {
            obj.GetComponent<Text>().text = "箱の数が足りない...";
            Debug.Log("たりないよ！！");
            return;
        }
        Debug.Log("clear");
        map.ReLoadMap(true);
        controller.boxCnt = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        obj.GetComponent<Text>().text = "";
    }
}
