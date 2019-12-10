using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapController : MonoBehaviour
{
    int[,] glid;
    List<int> pointList = new List<int>();

    [SerializeField]GameObject obj;
    int pointNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Point();
        }   
    }

    /// <summary>
    /// なんか
    /// </summary>
    /// <param name="num">すうち</param>
    public void SetGlidInfo(int[] nums,TextAsset textAsset)
    {
        StreamReader reader = new StreamReader((Application.dataPath + "/Resources/CSV/" + textAsset.name + ".csv"));
        glid = new int[nums[0], nums[1]];
        int cnt = 0;
        while (reader.Peek() > -1)
        {
            string[] str = reader.ReadLine().Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                if (int.Parse(str[i]) != 1)
                {
                    glid[cnt, i] = int.Parse(str[i]);
                }
            }
            cnt++;
        }

    }


    public void Point()
    {

        pointNum++;
        if(pointNum >= 6)
        {
            Debug.Log("てんかいすはんてい");
            pointNum = 0;
        }
    }
}
