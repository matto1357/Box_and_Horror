using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager sSingleton { get { return _sSingleton; } }
    static AudioManager _sSingleton;

    public AudioSource EnemyDistanceAudio;

    void Awake() 
    {
        if (_sSingleton != null && _sSingleton != this) Destroy(this.gameObject);
        else _sSingleton = this;

        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
