using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCreateEditor : MonoBehaviour
{
    int[,] mapGlid;

    [SerializeField] int[] glidLength = new int[2];

    [SerializeField] GameObject parent;
    [SerializeField]GameObject obj;

    [SerializeField] InputField[] inputField;
    [SerializeField] Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        CreateMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("in");
            for (int i = 0;i<glidLength[0] + 2;i++)
            {
                string str = "";
                for (int j = 0;j<glidLength[1] + 2;j++)
                {
                    str += mapGlid[i, j].ToString() + ",";
                }
                str = str.Substring(0,str.Length-1); ;
                GetComponent<CSVWritter>().WritingCSV(str);
            }
        }
        //マップの再生成
        if (Input.GetKeyDown(KeyCode.Z))
        {
            glidLength = new int[2] { int.Parse(inputField[0].text), int.Parse(inputField[1].text) };
            Debug.Log(glidLength[0] + ":"+glidLength[1]);
            CreateMap();
        }
        //マウスクリックでのマップ編集
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = new Ray(mousePos, new Vector3(0, -10, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f))
        {
            GameObject obj = hit.collider.gameObject;
            //左クリック。変える
            if (Input.GetMouseButtonDown(0))
            {
                string[] str = obj.name.Split(':');
                if (mapGlid[int.Parse(str[0]), int.Parse(str[1])] >=0) {
                    int num = ++mapGlid[int.Parse(str[0]), int.Parse(str[1])];
                    if (num == 4)
                    {
                        mapGlid[int.Parse(str[0]), int.Parse(str[1])] = 0;
                        num = 0;
                    }
                    switch (num)
                    {
                        case 0:
                            obj.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
                            break;
                        case 1:
                            obj.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
                            break;
                        case 2:
                            obj.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
                            break;
                        case 3:
                            obj.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
                            break;
                    }
                }
                else
                {
                    int num = --mapGlid[int.Parse(str[0]), int.Parse(str[1])];
                    if (num == -4)
                    {
                        mapGlid[int.Parse(str[0]), int.Parse(str[1])] = -1;
                        num = -1;
                    }
                    switch (num)
                    {
                        case -1:
                            obj.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
                            break;
                        case -2:
                            obj.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
                            break;
                        case -3:
                            obj.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 1);
                            break;
                    }
                }
            }
            //選択の消去
            else if (Input.GetMouseButtonDown(1))
            {
                string[] str = obj.name.Split(':');
                if (mapGlid[int.Parse(str[0]),int.Parse(str[1])] >= 0)
                {
                    mapGlid[int.Parse(str[0]), int.Parse(str[1])] = 0;
                    obj.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
                }
                else
                {
                    mapGlid[int.Parse(str[0]), int.Parse(str[1])] = -1;
                    obj.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
                }
            }
            
        }
    }
    //マップエデタ用の
    private void CreateMap()
    {
        foreach (Transform trans in parent.transform)
        {
            Destroy(trans.gameObject);
        }

        mapGlid = new int[glidLength[0] + 2, glidLength[1] + 2];
        for (int i = 0; i < glidLength[0] + 2; i++)
        {
            for (int j = 0; j < glidLength[1] + 2; j++)
            {
                GameObject gameObj = Instantiate(obj, new Vector3(i, 0, j), Quaternion.identity, parent.transform);
                gameObj.transform.localScale *= 0.9f;
                gameObj.name = i + ":" + j;
                if (i == 0 || j == 0 || i == glidLength[0] + 1 || j == glidLength[1] + 1)
                {
                    mapGlid[i, j] = -1;
                    gameObj.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
                }
                else
                {
                    mapGlid[i, j] = 0;
                    gameObj.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
                }
            }
        }
        parent.transform.localPosition += new Vector3(-(glidLength[0] + 1f) / 2f, 0, -(glidLength[1] + 1f) / 2f);
        float num = 0f;
        if (glidLength[0] > glidLength[1])
        {
            num = glidLength[0];
        }
        else
        {
            num = glidLength[1];
        }
        if (num / 8 >= 1)
        {
            camera.orthographicSize = 5 + (num % 8);
        }else
        {
            camera.orthographicSize = 5;
        }
    }

    public void AllSelect()
    {
        for (int i = 1; i < glidLength[0] + 1; i++)
        {
            for (int j = 1; j < glidLength[1] + 1; j++)
            {
                mapGlid[i, j] = 0;
            }
        }
    }
}
