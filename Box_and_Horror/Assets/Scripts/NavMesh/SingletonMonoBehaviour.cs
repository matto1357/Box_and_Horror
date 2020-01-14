using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シングルトン
/// </summary>
/// <typeparam name="T"></typeparam>

//マネージャー系は先に実行させるテスト
//ダメだったら個別に付けよう
[DefaultExecutionOrder(-1)]
public class SingletonMonoBehaviour<T> : 
    MonoBehaviour where T: MonoBehaviour
{
    public static T instance;

    protected virtual void Awake()
    {
        if(instance == null)
        {
            //シングルトン化
            instance = this as T;
        }
        else
        {
            //Destroy
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
}
