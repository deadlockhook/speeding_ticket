using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_state_mgr : MonoBehaviour
{
    [HideInInspector]
    public key_state_mgr keystate_mgr = null;

    static bool initialized = false;
    void Awake()
    {
        if (!initialized)
        {
            GameObject.DontDestroyOnLoad(gameObject);
            initialized = true;
        }
        else
            GameObject.Destroy(gameObject);

        keystate_mgr = gameObject.GetComponent<key_state_mgr>();
    }
    void Start()
    {

    }
    void Update()
    {

    }
}
