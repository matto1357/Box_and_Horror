using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapCreate : MonoBehaviour
{
    [SerializeField] TextAsset textAsset;
    [SerializeField] GameObject mapObject;
    //ミニマップ用。場所は変更する
    [SerializeField] GameObject minimap;
    // Start is called before the first frame update
    void Start()
    {
        //本来ここでtextAssetの読み込み。多分managerから
        //csvの読み込み
        StreamReader reader = new StreamReader((Application.dataPath + "/Resources/CSV/" + textAsset.name + ".csv"));
        int cnt = 0;
        while(reader.Peek() > -1)
        {
            string[] str = reader.ReadLine().Split(',');
            for (int i = 0;i< str.Length;i++)
            {
                if (int.Parse(str[i]) != 1)
                {
                    InstanceFloor(new Vector3(i, 0,cnt),int.Parse(str[i]));

                }
            }
            cnt++;
        }

        
    }

    private void Update()
    {
        //マップ表示。書く場所はあとでplayerに行くだろうな
        if (Input.GetKey(KeyCode.Q))
        {
            minimap.SetActive(true);
        }
        else
        {
            minimap.SetActive(false);
        }
    }

    private void InstanceFloor(Vector3 pos,int num)
    {
        //オブジェクトに持たせるかもしれないし変わる可能性アリ
        GameObject obj = Instantiate(mapObject, pos, Quaternion.identity, this.transform);
        switch (num)
        {
            
            case 0:
                obj.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
                break;
            case 2:
                obj.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
                break;
            case 3:
                obj.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
                break;
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
