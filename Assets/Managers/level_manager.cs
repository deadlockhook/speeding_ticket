using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static gui;

public class LevelManager : MonoBehaviour
{
    [SerializeField] gui guiManager = null;
    void Start()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        Debug.Log("Loading Scene " + sceneName);
        SceneManager.LoadScene(sceneName);

        if (sceneName == "MainMenu")
            guiManager.SwitchScreen(ScreenIndex.MainMenu,true);
        else
            guiManager.SwitchScreen(ScreenIndex.Overlay, false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
