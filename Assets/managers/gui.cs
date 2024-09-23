using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class gui : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject main_ui_object = null;

    [SerializeField] GameObject main_menu_screen_object = null;
    [SerializeField] GameObject options_screen_object = null;
    [SerializeField] GameObject ingame_overlay_screen_object = null;
    [SerializeField] GameObject game_win_screen_object = null;
    [SerializeField] GameObject upgrades_screen_object = null;
    enum screen_index : int
    {
        inactive = 0,
        main_menu,
        options_screen,
        ingame_overlay,
        game_win,
        upgdrades,
        max_screens
    }


    GameObject[] screen_objects;

    void Start()
    {
        screen_objects = new GameObject[(int)screen_index.max_screens];

        screen_objects[(int)screen_index.main_menu] = main_menu_screen_object;
        screen_objects[(int)screen_index.options_screen] = options_screen_object;
        screen_objects[(int)screen_index.ingame_overlay] = ingame_overlay_screen_object;
        screen_objects[(int)screen_index.game_win] = game_win_screen_object;
        screen_objects[(int)screen_index.upgdrades] = upgrades_screen_object;

    }

    void switch_screen(screen_index new_index)
    {
        for (int current = (int)screen_index.main_menu;current < (int)screen_index.max_screens;current++)
        {
            screen_objects[current].SetActive(current == (int)new_index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
