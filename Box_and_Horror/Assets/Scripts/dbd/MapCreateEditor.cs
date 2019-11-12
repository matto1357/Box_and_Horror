using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreateEditor : MonoBehaviour
{
    int[,] mapGlid;
    [SerializeField] int[] glidLength = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        mapGlid = new int[glidLength[0], glidLength[1]];
        for (int i = 0;i< glidLength[0];i++)
        {
            for (int j = 0;j<glidLength[1];j++)
            {
                if(i != 3 && j != 3)
                {
                    mapGlid[i, j] = 1;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("in");
            for (int i = 0;i<glidLength[0];i++)
            {
                string str = "";
                for (int j = 0;j<glidLength[1];j++)
                {
                    str += mapGlid[i, j].ToString() + ",";
                }
                str = str.Substring(0,str.Length-1); ;
                GetComponent<CSVWritter>().WritingCSV(str);
            }
        }
    }
}
