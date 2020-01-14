using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentBoxManager : SingletonMonoBehaviour<DeploymentBoxManager>
{
    //private Vector2Int[] poses = { new Vector2Int(5, 5), new Vector2Int(5, 6), new Vector2Int(5, 7), new Vector2Int(6, 6), new Vector2Int(7, 6), new Vector2Int(8, 6) };
    private Vector2Int[] poses = { new Vector2Int(0,0),
new Vector2Int(0,1),new Vector2Int(1,1),new Vector2Int(2,1),new Vector2Int(3,1),new Vector2Int(4,1), };


    private readonly Vector2Int[][] uniquePoses =
    {
        new Vector2Int[]{ new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(1,1), new Vector2Int(2,1), new Vector2Int(2,2), new Vector2Int(3,2) },
        new Vector2Int[]{ new Vector2Int(3,0), new Vector2Int(2,0), new Vector2Int(2,1), new Vector2Int(1,1), new Vector2Int(1,2), new Vector2Int(0,2) },
        new Vector2Int[]{ new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(2,0), new Vector2Int(2,1), new Vector2Int(3,1), new Vector2Int(4,1) },
        new Vector2Int[]{ new Vector2Int(4,0), new Vector2Int(3,0), new Vector2Int(2,0), new Vector2Int(2,1), new Vector2Int(1,1), new Vector2Int(0,1) },
    };

    private readonly Vector2Int[] boxPoses_141 =
    {
        new Vector2Int(0,1),new Vector2Int(1,1),new Vector2Int(2,1),new Vector2Int(3,1),
    };

    private readonly Vector2Int[][] AdditionalPoses_141 =
    {
        new Vector2Int[]{ new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(2,0), new Vector2Int(3,0)},
        new Vector2Int[]{ new Vector2Int(0,2), new Vector2Int(1,2), new Vector2Int(2,2), new Vector2Int(3,2)},
    };

    private readonly Vector2Int[][] boxPoses_132 =
    {
        new Vector2Int[]{new Vector2Int(1,1), new Vector2Int(2,1), new Vector2Int(3,1), new Vector2Int(0,2), new Vector2Int(1,2)},
        new Vector2Int[]{new Vector2Int(1,1), new Vector2Int(2,1), new Vector2Int(3,1), new Vector2Int(0,0), new Vector2Int(1,0)},
        new Vector2Int[]{new Vector2Int(0,1), new Vector2Int(1,1), new Vector2Int(2,1), new Vector2Int(2,2), new Vector2Int(3,2)},
        new Vector2Int[]{new Vector2Int(0,1), new Vector2Int(1,1), new Vector2Int(2,1), new Vector2Int(2,0), new Vector2Int(3,0)},
    };

    private readonly Vector2Int[][] AdditionalPoses_132 =
    {
        new Vector2Int[]{new Vector2Int(1,0), new Vector2Int(2,0), new Vector2Int(3,0)},
        new Vector2Int[]{new Vector2Int(1,2), new Vector2Int(2,2), new Vector2Int(3,2)},
        new Vector2Int[]{new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(2,0)},
        new Vector2Int[]{new Vector2Int(0,2), new Vector2Int(1,2), new Vector2Int(2,2)},
    };
    
    /// <summary>
    /// 判定するよ！！！
    /// </summary>
    /// <param name="poses"></param>
    /// <returns></returns>
    public bool IsBox(Vector2Int[] poses)
    {
        Surfaces surfaces = new Surfaces(poses);
        return BoxDetermine(surfaces);
    }

    /// <summary>
    /// 展開図の判定
    /// </summary>
    /// <param name="surfaces">判定する展開図のデータ</param>
    /// <returns></returns>
    private bool BoxDetermine(Surfaces surfaces)
    {
        Vector2Int size = surfaces.Size;
        Vector2Int[] poses;

        //立方体の展開図の法則で弾く
        if (size.x < 2 || 5 < size.x || size.x + size.y != 7)
        {
            return false;
        }
        
        //https://sugaku.fun/development-view-of-cube/

        if(size.x < size.y)
        {
            poses = surfaces.RotatedPoses;
        }
        else
        {
            poses = surfaces.ConvertedPoses;
        }

        bool isUnique = UniqueDetermine(poses);

        if(isUnique)
        {
            return true;
        }

        bool isBox = DiagramDetermine(poses);

        if(isBox)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 2-2-2型と3-3型の判定を行う
    /// </summary>
    /// <param name="poses">判定する展開図のデータ</param>
    /// <returns></returns>
    private bool UniqueDetermine(Vector2Int[] poses)
    {
        foreach(Vector2Int[] comp in uniquePoses)
        {
            bool isCorrect = true;
            foreach (Vector2Int pos in comp)
            {
                if(isCorrect && -1 == Array.IndexOf(poses, pos))
                {
                    isCorrect = false;
                }
            }
            if (isCorrect)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 1-4-1型と1-3-2型の判定を行う
    /// </summary>
    /// <param name="poses">判定する展開図のデータ</param>
    /// <returns></returns>
    private bool DiagramDetermine(Vector2Int[] poses)
    {
        List<Vector2Int> tooPoses = new List<Vector2Int>();

        //1-4-1型の判定
        foreach (Vector2Int pos in poses)
        {
            if(-1 == Array.IndexOf(boxPoses_141, pos))
            {
                tooPoses.Add(pos);
            }
        }

        if(tooPoses.Count == 2)
        {

            bool isCorrect = false;

            foreach (Vector2Int[] comp in AdditionalPoses_141)
            {
                isCorrect = false;
                for (int i = 0; i < tooPoses.Count; i++)
                {
                    if(-1 != Array.IndexOf(comp, tooPoses[i]))
                    {
                        isCorrect = true;
                    }
                }
                if (isCorrect == false)
                {
                    break;
                }
            }

            if(isCorrect)
            {
                return true;
            }
        }
        
        tooPoses = new List<Vector2Int>();

        //1-3-2型の判定
        for(int i = 0; i < boxPoses_132.Length; i++)
        {
            Vector2Int[] comp = boxPoses_132[i];

            foreach (Vector2Int pos in poses)
            {
                if(-1 == Array.IndexOf(comp, pos))
                {
                    tooPoses.Add(pos);
                }
            }

            if(tooPoses.Count == 1)
            {
                Vector2Int[] temp = AdditionalPoses_132[i];
                if(-1 != Array.IndexOf(temp, tooPoses[0]))
                {
                    return true;
                }
            }

            tooPoses = new List<Vector2Int>();
        }

        return false;
    }

    /// <summary>
    /// デバッグ出力
    /// </summary>
    /// <param name="pos"></param>
    private void ShowPoses(Vector2Int[] pos)
    {
        foreach (Vector2Int data in pos)
        {
            Debug.Log(data.x + ":" + data.y);
        }
    }
}
