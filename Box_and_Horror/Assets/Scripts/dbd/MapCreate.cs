using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using UnityEngine.SceneManagement;

public class MapCreate : MonoBehaviour
{
    public MapData[] assets;
    [SerializeField] GameObject mapObject;
    //ミニマップ用。場所は変更する
    [SerializeField] GameObject minimapCamera;
    [SerializeField] GameObject minimap;

    GameObject endPosition;

    [SerializeField] MapController mapController;
    README _r;
    [SerializeField] Material mat;

    GameObject parentObj;
    // Start is called before the first frame update
    void Start()
    {
        _r = GetComponent<README>();
        //本来ここでtextAssetの読み込み。多分managerから
        //csvの読み込み
        TextAssetReader();
        //TextAssetReader();
        
    }


    private void Update()
    {
        //マップ表示。書く場所はあとでplayerに行くだろうな
        if (Input.GetKey(KeyCode.Q))
        {
            minimapCamera.SetActive(true);
            minimap.SetActive(true);
        }
        else
        {
            minimapCamera.SetActive(false);
            minimap.SetActive(false);
        }
        
    }

    private void TextAssetReader()
    {
        StreamReader reader = new StreamReader((Application.dataPath + "/Resources/CSV/" + assets[mapCnt].assets.name + ".csv"));
        int cnt = 0;
        int num = 0;
        GameObject obj = new GameObject();
        mapController.parentObj = obj;
        while (reader.Peek() > -1)
        {
            string[] str = reader.ReadLine().Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                if (int.Parse(str[i]) != 1)
                {
                    GameObject a = InstanceFloor(new Vector3(i * mapObject.transform.localScale.x, 0, cnt * mapObject.transform.localScale.x), int.Parse(str[i]),new int[]{i,cnt});
                    a.transform.parent = obj.transform;
                    a.name = cnt + ":" + i;
                }
            }
            cnt++;
            num = str.Length;
        }
        //obj.transform.position = new Vector3(-num * mapObject.transform.localScale.x / 2,0,-cnt * mapObject.transform.localScale.x / 2);
        mapController.SetGlidInfo(new int[2] { cnt, num }, assets[mapCnt].assets);
        mapController.Init();
        minimapCamera.transform.localPosition = new Vector3((float)cnt / 2f * mapObject.transform.localScale.x, 10, (float)num / 2f * mapObject.transform.localScale.x);
        minimapCamera.GetComponent<Camera>().orthographicSize = cnt * 1.5f;
        _r.UpdateNav();

        if (endPosition != null)
        {
            //Vector3 vec = endPosition.transform.localPosition - ;
        }
    }

    private GameObject InstanceFloor(Vector3 pos,int num,int[] nums)
    {
        //オブジェクトに持たせるかもしれないし変わる可能性アリ
        GameObject obj = Instantiate(mapObject, pos, Quaternion.identity);
        switch (num)
        {
            
            case 0:
                obj.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
                break;
            case 2:
                obj.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
                mapController.infometionGlid.Add(new Vector3(nums[0],1,nums[1]));
                mapController.pointList.Add(num);
                break;
            case 3:
                obj.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
                mapController.infometionGlid.Add(new Vector3(nums[0],1, nums[1]));
                mapController.pointList.Add(num);
                break;
            case -1:
                obj.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
                obj.transform.localScale += new Vector3(0,10,0);
                obj.GetComponent<MeshRenderer>().material = mat;
                break;
            case -2:
                obj.GetComponent<BoxCollider>().size = new Vector3(1,2,1);
                var col = obj.AddComponent<BoxCollider>();
                col.center += new Vector3(0, 1, 0);
                col.isTrigger = true;
                obj.AddComponent<ExitPoint>();
                obj.transform.localScale = new Vector3(obj.transform.localScale.x,0.1f,obj.transform.localScale.z);
                mapController.infometionGlid.Add(new Vector3(nums[0],1, nums[1]));
                mapController.pointList.Add(num);
                endPosition = obj;
                break;
            case -3:
                obj.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 1);
                obj.GetComponent<BoxCollider>().size = new Vector3(1, 0.1f, 1);
                obj.GetComponent<BoxCollider>().center = new Vector3(0, -0.5f, 0);
                obj.transform.localScale += new Vector3(0, 10, 0);
                obj.GetComponent<MeshRenderer>().material = mat;
                mapController.infometionGlid.Add(new Vector3(nums[0],1, nums[1]));
                mapController.pointList.Add(num);
                break;
                
        }
        return obj;
    }

    public int mapCnt = 0;
    public void ReLoadMap(bool trig)
    {
        if (trig)mapCnt++;
        if (mapCnt >= assets.Length)
        {
            SceneManager.LoadScene("GameClear");
        }
        else
        {
            mapController.parentObj.SetActive(false);
            TextAssetReader();
            EnemySpawn.instance.ResetEnemy();
            
        }
    }

}
