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

    public bool IsBox(List<Vector2Int> poses)
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

    /// <summary>
    /// 積んでるかどうか判定する
    /// </summary>
    /// <param name="map">Glidを入れてね</param>
    /// <returns>True -> つみです</returns>
    public bool IsStalemateCheck(int[,] map)
    {
        //x:5, y:2
        if(map.GetLength(1) >= 5 && map.GetLength(0) >= 2)
        {
            if (IsBoxAlive(map, new Vector2Int(5, 2)))
            {
                return false;
            }
        }
        //x:2, y:5
        if (map.GetLength(1) >= 2 && map.GetLength(0) >= 5)
        {
            if (IsBoxAlive(map, new Vector2Int(2, 5)))
            {
                return false;
            }
        }
        //x:3, y:4
        if (map.GetLength(1) >= 3 && map.GetLength(0) >= 4)
        {
            if (IsBoxAlive(map, new Vector2Int(3, 4)))
            {
                return false;
            }
        }
        //x:4, y:3
        if (map.GetLength(1) >= 4 && map.GetLength(0) >= 3)
        {
            if (IsBoxAlive(map, new Vector2Int(4, 3)))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 箱生成できるかどうか
    /// </summary>
    /// <param name="map"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    private bool IsBoxAlive(int[,] map, Vector2Int size)
    {
        for (int x = 0, xLen = map.GetLength(1) - (size.x - 1); x < xLen; x++)
        {
            for (int y = 0, yLen = map.GetLength(0) - (size.y - 1); y < yLen; y++)
            {
                int[,] glid = CreateGlid(map, size, new Vector2Int(x,y));
                List<Vector2Int> poses = GetPos(glid);
                if(poses.Count < 6)
                {
                    continue;
                }
                if(poses.Count == 6)
                {
                    if(IsBox(poses))
                    {
                        return true;
                    }
                }
                else
                {
                    List<int[]> comp = CreateComb(poses.Count);
                    foreach (int[] c in comp)
                    {
                        List<Vector2Int> p = new List<Vector2Int>();
                        for (int i = 0; i < c.Length; i++)
                        {
                            p.Add(poses[c[i]]);
                        }
                        if (IsBox(p))
                        {
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    /// <summary>
    /// 切り抜き
    /// </summary>
    /// <param name="map"></param>
    /// <param name="size"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    private int[,] CreateGlid(int[,] map, Vector2Int size, Vector2Int offset)
    {
        int[,] glid = new int[size.y, size.x];
        for(int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                glid[y, x] = map[y + offset.y, x + offset.x];
            }
        }
        return glid;
    }

    /// <summary>
    /// 床位置取得
    /// </summary>
    /// <param name="map"></param>
    /// <returns></returns>
    private List<Vector2Int> GetPos(int[,] map)
    {
        List<Vector2Int> poses = new List<Vector2Int>();
        for(int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if(map[y,x] == 0)
                {
                    poses.Add(new Vector2Int(x, y));
                }
            }
        }
        return poses;
    }

    /// <summary>
    /// 昆布...じゃなくて組み合わせを作る
    /// 組み合わせ方法思いつかねぇからクソコードが爆誕します
    /// </summary>
    private List<int[]> CreateComb(int count)
    {
        List<int[]> result = new List<int[]>();
        for(int a = 0,limitA = count - 6; a < limitA; a++)
        {
            for (int b = a + 1, limitB = limitA + 1; b < limitB; b++)
            {
                for (int c = b + 1, limitC = limitB + 1; c < limitC; c++)
                {
                    for (int d = c + 1, limitD = limitC + 1; d < limitD; d++)
                    {
                        for (int e = d + 1, limitE = limitD + 1; e < limitE; e++)
                        {
                            for (int f = e + 1, limitF = limitE + 1; f < limitF; f++)
                            {
                                int[] element = { a, b, c, d, e, f };
                                result.Add(element);
                            }
                        }
                    }
                }
            }
        }

        return result;
    }

    private void Start()
    {
        int[,] map =
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,0,0,0,0},
            {1,1,1,1,1,1,0,0,0,0},
            {1,1,1,1,1,1,0,0,0,0},
        };
        Debug.Log(IsStalemateCheck(map));
    }
}
