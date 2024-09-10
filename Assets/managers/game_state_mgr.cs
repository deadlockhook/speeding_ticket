using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_state_mgr : MonoBehaviour
{
    public key_state_mgr keystate_mgr = null;
    void Awake()
    {
        keystate_mgr = gameObject.GetComponent<key_state_mgr>();
    }
    void Update()
    {

    }
}
