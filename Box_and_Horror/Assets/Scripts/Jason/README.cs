using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//これいれる

public class README : MonoBehaviour
{

    //合体したあとでやる
    //Hierarchyで NavMesh (NavMeshSurface) の追加
    //以下のコードはマップ作ると床消える時入れる

    public NavMeshSurface surface;

    void Start()
    {
        //マップ作った後これ入れる
        //床一部消えた時もこれでアップデートする
        //surface.BuildNavMesh();
    }

    public void UpdateNav()
    {
        surface.BuildNavMesh();
    }

}
