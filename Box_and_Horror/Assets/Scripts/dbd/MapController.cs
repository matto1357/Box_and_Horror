using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapController : MonoBehaviour
{
    int[,] glid;
    public List<Vector3> infometionGlid = new List<Vector3>();
    public List<int> pointList = new List<int>();
    private int[] size = new int[2];

    [SerializeField]GameObject obj;
    int pointNum;
    [SerializeField] MapCreate map;

    int boxCnt;

    [SerializeField] GameObject player;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject enemy;
    [SerializeField] README _r;
    [SerializeField]private int masuObjScale;

    public GameObject parentObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Point();
        }
        
    }
    public void Init()
    {
        bool trig = true;
        int cnt = 0;
        while (cnt < pointList.Count)
        {
            switch (pointList[cnt])
            {
                case 2:
                    Debug.Log(cnt);
                    MovePlayer(cnt);
                    break;
                case -3:
                    Debug.Log(cnt);
                    Text(cnt);
                    break;

            }
            cnt++;
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
                size[1] = i+1;
            }
            cnt++;
        }
        size[0] = cnt;
    }

    GameObject[] objs = new GameObject[6];
    Vector2Int[] vec2 = new Vector2Int[6];

    public void Point()
    {
        //マウスクリックでのマップ編集
        Ray ray = new Ray(player.transform.position, new Vector3(0, -10, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f))
        {
            string[] str = hit.transform.name.Split(':');
            Debug.Log(str[0] + ":" + str[1]);
            for (int i = 0;i < vec2.Length;i++)
            {
                if(vec2[i] == new Vector2Int(int.Parse(str[0]), int.Parse(str[1])))
                {
                    Debug.Log("out");
                    return;
                }
            }
            objs[pointNum] = hit.collider.gameObject;
            hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            vec2[pointNum] = new Vector2Int(int.Parse(str[0]), int.Parse(str[1]));

            pointNum++;


            if (pointNum >= 6)
            {
                Debug.Log("てんかいすはんてい");
                bool judge = DeploymentBoxManager.instance.IsBox(vec2);
                Debug.Log(judge);
                if (judge)
                {
                    StartCoroutine(MapDeleteCoroutine(objs));
                }
                else
                {
                    for (int i = 0; i < objs.Length; i++)
                    {
                        objs[i].GetComponent<MeshRenderer>().material.color = Color.white;
                    }
                }
                pointNum = 0;
                vec2 = new Vector2Int[6];
            }
        }
        
    }

    IEnumerator MapDeleteCoroutine(GameObject[] obj)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            obj[i].GetComponent<MeshRenderer>().material.color = Color.black;
        }
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < objs.Length; i++)
        {
            obj[i].GetComponent<MeshRenderer>().material.color = Color.red;
        }
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < objs.Length; i++)
        {
            obj[i].GetComponent<MeshRenderer>().material.color = Color.black;
        }
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < objs.Length; i++)
        {
            obj[i].GetComponent<MeshRenderer>().material.color = Color.red;
        }
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < objs.Length; i++)
        {
            Destroy(objs[i]);
        }
        _r.UpdateNav();
        player.GetComponent<Player>().boxCnt++;
        Debug.Log(player.GetComponent<Player>().boxCnt);
        objs = new GameObject[6];
    }

    private void MovePlayer(int cnt)
    {
        Debug.Log(infometionGlid[cnt]*masuObjScale);
        player.transform.localPosition = infometionGlid[cnt]*masuObjScale;
        player.transform.LookAt(new Vector3(-size[0] / 2 * masuObjScale, player.transform.position.y, -size[1] / 2 * masuObjScale));
        camera.transform.localRotation = player.transform.localRotation;

    }

    private void Text(int cnt)
    {
        var text = new GameObject();
        text.transform.parent = parentObj.transform;
        text.AddComponent<TextMesh>().text = "箱 * "+map.assets[0].boxCnt+"個";
        text.GetComponent<TextMesh>().fontSize = 50;
        text.transform.localPosition = infometionGlid[cnt] * masuObjScale;
        Debug.Log(infometionGlid[cnt]);
        text.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        if (infometionGlid[cnt].x ==0)
        {
            text.transform.Rotate(new Vector3(0,270,0));
        }
        else if(infometionGlid[cnt].x == size[0] - 1)
        {
            text.transform.Rotate(new Vector3(0, 90, 0));
        }
        else if (infometionGlid[cnt].z == 0)
        {
            text.transform.Rotate(new Vector3(0, 180, 0));
        }
        else if(infometionGlid[cnt].z == size[1] -1)
        {
            text.transform.Rotate(new Vector3(0, 0, 0));
        }
        //向きがあってないから直してね
    }

    private void SetCharactorPosition()
    {

    }
}

