using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton : MonoBehaviour
{
    public static Object owning_object =null;
    void Awake()
    {
        if (owning_object == null)
        {
            owning_object = this;
        }
        else if (owning_object != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }
}
