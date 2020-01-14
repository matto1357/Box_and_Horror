using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// どのホラー演出か
/// </summary>
public enum HorrorProductionType
{
    //
}

/// <summary>
/// 演出の種類
/// </summary>
public enum ProductionType
{
    Animation = 0,

}

public class HorrorProductionManager : SingletonMonoBehaviour<HorrorProductionManager>
{
    private Dictionary<HorrorProductionType, GameObject> horrorProductionDic = new Dictionary<HorrorProductionType, GameObject>();
    [SerializeField]
    private List<HorrorProductionSettings> horrorProductions;

    public void HorrorProductionsInsert(List<HorrorProductionSettings> data)
    {
        horrorProductions = data;
    }

    private void Init()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
