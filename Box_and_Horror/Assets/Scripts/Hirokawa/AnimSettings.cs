using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSettings : ScriptableObject
{
    [SerializeField]
    private string startAnimationName;

    public string StartAnimationName
    {
        get { return startAnimationName; }
    }

    [SerializeField]
    private bool isAnimLoop;

    public bool IsAnimLoop
    {
        get { return isAnimLoop; }
    }
}
