using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

public class gui : MonoBehaviour
{

    [SerializeField] KeyStateManager keyStateManager = null;

    [SerializeField] GameObject menuBackgroundImageObject = null;
    [SerializeField] GameObject mainMenuScreenObject = null;
    [SerializeField] GameObject optionsScreenObject = null;
    [SerializeField] GameObject ingameOverlayScreenObject = null;
    [SerializeField] GameObject gameWinScreenObject = null;
    [SerializeField] GameObject upgradesScreenObject = null;
    [SerializeField] GameObject pauseScreenObject = null;
    public enum ScreenIndex : int
    {
        Inactive = 0,
        MainMenu,
        Options,
        Overlay,
        GameWin,
        Upgrades,
        Pause,
        MaxScreens
    }

    private ScreenIndex currentScreen;

    GameObject[] screenObjects;

    void Start()
    {
        screenObjects = new GameObject[(int)ScreenIndex.MaxScreens];

        screenObjects[(int)ScreenIndex.MainMenu] = mainMenuScreenObject;
        screenObjects[(int)ScreenIndex.Options] = optionsScreenObject;
        screenObjects[(int)ScreenIndex.Overlay] = ingameOverlayScreenObject;
        screenObjects[(int)ScreenIndex.GameWin] = gameWinScreenObject;
        screenObjects[(int)ScreenIndex.Upgrades] = upgradesScreenObject;
        screenObjects[(int)ScreenIndex.Pause] = pauseScreenObject;

        SwitchScreen(ScreenIndex.MainMenu, true);
    }

    public void SwitchScreen(ScreenIndex new_index, bool bg_active)
    {
        currentScreen = new_index;
        menuBackgroundImageObject.SetActive(bg_active);

        for (int current = (int)ScreenIndex.MainMenu; current < (int)ScreenIndex.MaxScreens; current++)
        {
            screenObjects[current].SetActive(current == (int)new_index);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SwitchScreen(ScreenIndex.MainMenu, true);
    }

    // Update is called once per frame
    void Update()
    {

        if (keyStateManager.CheckKeyState(KeyCode.Escape, key_query_mode.kq_singlepress))
        {
            if (currentScreen == ScreenIndex.Overlay)
                SwitchScreen(ScreenIndex.Pause, true);
            else if (currentScreen == ScreenIndex.Pause)
                SwitchScreen(ScreenIndex.Overlay, false);
        }



    }
}
