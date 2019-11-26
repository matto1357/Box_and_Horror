using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="stage/Create StageAsset",fileName = "stage")]
public class Scriptable : ScriptableObject
{
    [Header("なんのステージを利用するのかな？")]
    [SerializeField]
    TextAsset[] assets;
}
