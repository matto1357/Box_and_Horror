using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapCreate : MonoBehaviour
{
    [SerializeField] TextAsset textAsset;
    [SerializeField] GameObject mapObject;
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
                if (int.Parse(str[i]) != 0)
                {
                    InstanceFloor(new Vector3(i, 0,cnt));
                }
            }
            cnt++;
        }
    }
    
    private void InstanceFloor(Vector3 pos)
    {
        Instantiate(mapObject, pos, Quaternion.identity, this.transform);
    }
}
