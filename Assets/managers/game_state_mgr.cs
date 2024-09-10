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
        if (keystate_mgr.check_key_state(KeyCode.A, key_query_mode.kq_singlepress))
            SceneManager.LoadScene(1);
        


    }
}
