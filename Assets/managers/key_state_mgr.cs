using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum key_query_mode
{
    kq_singlepress = 0,
    kq_onhotkey,
    kq_offhotkey,
    kq_ontoggle
}

public class key_state_mgr : MonoBehaviour
{
    // Start is called before the first frame update
    const int max_keys = (int)KeyCode.Joystick8Button19 + 1;

    bool[] toggle_state;
    bool[] current_state;
    bool[] single_press_state;
    void Start()
    {
        toggle_state = new bool[max_keys];
        current_state = new bool[max_keys];
        single_press_state = new bool[max_keys];
    }

    public bool check_key_state(KeyCode code, key_query_mode mode = key_query_mode.kq_onhotkey)
    {
        if ((int)code >= max_keys)
        {
            Debug.Log("unsupported key " + (int)code);
            return false;
        }

        switch (mode)
        {
            case key_query_mode.kq_singlepress:
                return single_press_state[(int)code];
            case key_query_mode.kq_onhotkey:
                return current_state[(int)code];
            case key_query_mode.kq_offhotkey:
                return !current_state[(int)code];
            case key_query_mode.kq_ontoggle:
                return toggle_state[(int)code];
            default:
                return false;
        }
    }
    void Update()
    {
        for (int current_index = 0; current_index < toggle_state.Length; current_index++)
        {
            current_state[current_index] = Input.GetKey((KeyCode)current_index);
            single_press_state[current_index] = Input.GetKeyDown((KeyCode)current_index);

            if (single_press_state[current_index])
                toggle_state[current_index] = !toggle_state[current_index];

        }
    }
}