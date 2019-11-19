using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 面の情報を入れる
/// </summary>
public class Surfaces
{
    private Vector2Int[] poses;
    private Vector2Int[] convertedPoses;
    private Vector2Int[] rotatedPoses;

    public Vector2Int[] Poses
    {
        set
        {
            if(value.Length != 6)
            {
                Debug.LogError("posesの要素数が6ではありません");
                return;
            }
            this.poses = value;
        }
    }
    public Vector2Int[] ConvertedPoses
    {
        get
        {
            if(convertedPoses == null)
            {
                this.convertedPoses = ConvertPoses(this.poses);
            }
            return this.convertedPoses;
        }
    }
    public Vector2Int[] RotatedPoses
    {
        get
        {
            if(rotatedPoses == null)
            {
                this.rotatedPoses = RotatePoses();
            }
            return this.rotatedPoses;
        }
    }
    public Vector2Int Size { get; set; }
    
    private Vector2Int[] ConvertPoses(Vector2Int[] data)
    {
        Vector2Int[] result = new Vector2Int[6];
        Vector2Int min = data[0];
        Vector2Int max = data[0];
        for(int i = 1; i < result.Length; i++)
        {
            Vector2Int pos = data[i];
            if(min.x > pos.x)
            {
                min.x = pos.x;
            }
            else if(max.x < pos.x)
            {
                max.x = pos.x;
            }

            if (min.y > pos.y)
            {
                min.y = pos.y;
            }
            else if (max.y < pos.y)
            {
                max.y = pos.y;
            }
        }

        Debug.Log("min x:" + min.x + ", y:" + min.y);
        Debug.Log("max x:" + max.x + ", y:" + max.y);

        for(int i = 0; i < result.Length; i++)
        {
            Vector2Int pos = data[i];
            result[i] = new Vector2Int(pos.x - min.x, pos.y - min.y);
        }

        Size = new Vector2Int(max.x - min.x + 1, max.y - min.y + 1);

        return result;
    }

    /// <summary>
    /// 右方向に回転する
    /// </summary>
    /// <returns></returns>
    private Vector2Int[] RotatePoses()
    {
        Vector2Int[] result = new Vector2Int[6];
        for(int i = 0; i < result.Length; i++)
        {
            Vector2Int data = convertedPoses[i];
            result[i] = new Vector2Int(Size.y - 1 - data.y, data.x);
        }
        return result;
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Surfaces()
    {

    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="_poses">要素数は6で</param>
    public Surfaces(Vector2Int[] _poses)
    {
        Poses = _poses;
    }
}
