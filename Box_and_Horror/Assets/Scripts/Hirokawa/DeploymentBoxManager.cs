using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentBoxManager : SingletonMonoBehaviour<DeploymentBoxManager>
{
    private Vector2Int[] poses = { new Vector2Int(5, 5), new Vector2Int(5, 6), new Vector2Int(5, 7), new Vector2Int(6, 6), new Vector2Int(7, 6), new Vector2Int(8, 6) };

    private void Start()
    {
        Surfaces surfaces = new Surfaces(poses);
        Vector2Int[] hoge = surfaces.ConvertedPoses;
        foreach(Vector2Int data in hoge)
        {
            Debug.Log(data.x + ":" + data.y);
        }
        Debug.Log("size=" + surfaces.Size.x + ":" + surfaces.Size.y);
        Debug.Log("----------");
        Vector2Int[] huga = surfaces.RotatedPoses;
        foreach (Vector2Int data in huga)
        {
            Debug.Log(data.x + ":" + data.y);
        }
    }

    /// <summary>
    /// 展開図の判定
    /// </summary>
    /// <param name="surfaces">判定する展開図のデータ</param>
    /// <returns></returns>
    private bool BoxDetermine(Surfaces surfaces)
    {
        Vector2Int size = surfaces.Size;

        //立方体の展開図の法則で弾く
        if (size.x < 2 || 5 < size.x || size.x + size.y != 7)
        {
            return false;
        }

        //誰か...実装しても...ええんやぞ...
        //https://sugaku.fun/development-view-of-cube/



        return false;
    }
}
