using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndRoll : MonoBehaviour
{
    private Vector3 moveAfter;

    [SerializeField]
    private float stepTime = 1;

    [SerializeField]
    Text text;

    [SerializeField]
    private float time;

    private void Awake()
    {
        //xは画面の解像度の半分、yはテキストのサイズと解像度の高さ分
        moveAfter.x = 960;
        moveAfter.y = text.rectTransform.sizeDelta.y + 1080;
    }

    private void Update()
    {
        if (text.transform.position != moveAfter)
        {
            Move();
        }
        else
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                GameSceneManager.GameStart();
            }
        }

    }

    private void Move()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, moveAfter, stepTime * 10 * Time.deltaTime);
    }
}
