using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="MapData",fileName = "MapData")]
public class MapData : ScriptableObject
{
    [Header("ステージに使うCSVファイル")]
    public TextAsset assets;

    [Header("クリアに必要な箱の数")]
    public int boxCnt;

    [Header("出てくる敵の最大数")]
    public int enemyMax;
}
