//------------------------------------------------------------
// WFramework
// Copyright © 2023-2023 WangPengCheng. All rights reserved.
// Homepage: 
// Feedback: 
//------------------------------------------------------------

using UnityEngine;

public class MonoSigleton<T> : MonoBehaviour where T : MonoSigleton<T>
{
    protected static T s_Instance;
    public static T Instance => s_Instance;
    public static bool IsInitiated => s_Instance != null;

    protected virtual void Awake()
    {
        if (s_Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Instance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        if (s_Instance == this)
        {
            s_Instance = null;
        }
    }
}