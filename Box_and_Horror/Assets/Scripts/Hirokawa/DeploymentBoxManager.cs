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
    }
}
