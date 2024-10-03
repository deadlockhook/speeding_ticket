using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using Unity.VisualScripting;

[Serializable]
public class GlobalGameSaveData
{
    public int playerHealth = 0;
    public int playerShield = 0;
    public int currentXP = 0;
    public int currentScore = 0;
    public int damageModifier = 0;
    public int scoreModifier = 0;
}
public class game_manager : MonoBehaviour
{
    [HideInInspector]
    public KeyStateManager keyStateMgr = null;

    static bool initialized = false;

    public int playerHealth = 0;
    public int playerShield = 0;
    public int currentXP = 0;
    public int currentScore = 0;
    public int damageModifier = 0;
    public int scoreModifier = 0;

    static private int gameManagerCount = 0;
    void Awake()
    {
        if (!initialized)
        {
            GameObject.DontDestroyOnLoad(gameObject);
            gameManagerCount += 1;
            initialized = true;
        }
        else
            GameObject.Destroy(gameObject);

        keyStateMgr = gameObject.GetComponent<KeyStateManager>();
    }

    public void ExitApp()
    {
        Application.Quit();
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), "currentLevel: " + SceneManager.GetActiveScene().name);
        GUI.Label(new Rect(10, 40, 200, 30), "gameManagerCount: " + gameManagerCount);
        GUI.Label(new Rect(10, 70, 200, 30), "playerHealth: " + playerHealth);
        GUI.Label(new Rect(10, 100, 200, 30), "playerShield: " + playerShield);
        GUI.Label(new Rect(10, 130, 200, 30), "currentXP: " + currentXP);
        GUI.Label(new Rect(10, 160, 200, 30), "currentScore: " + currentScore);
        GUI.Label(new Rect(10, 190, 200, 30), "damageModifier: " + damageModifier);
        GUI.Label(new Rect(10, 220, 200, 30), "scoreModifier: " + scoreModifier);

        if (GUI.Button(new Rect(10,300,100,30),"Health up"))
        {
            playerHealth += 10;
        }

        if (GUI.Button(new Rect(10, 340, 100, 30), "Health down"))
        {
            playerHealth -= 10;
        }

        if (GUI.Button(new Rect(10, 380, 100, 30), "Score up"))
        {
            currentScore += 10;
        }

        if (GUI.Button(new Rect(10, 420, 100, 30), "Score down"))
        {
            currentScore -= 10;
        }

        if (GUI.Button(new Rect(10, 460, 100, 30), "Save"))
        {
            SaveGlobalGameSaveData();
        }

        if (GUI.Button(new Rect(10, 500, 100, 30), "Load"))
        {
            LoadGlobalGameSaveData();
        }
    }

    public void SaveGlobalGameSaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/GlobalGameState.dat", FileMode.OpenOrCreate);
        Debug.Log(file.Name);
        GlobalGameSaveData saveData = new GlobalGameSaveData();
        saveData.playerHealth = playerHealth;
        saveData.playerShield = playerShield;
        saveData.currentXP = currentXP;
        saveData.currentScore = currentScore;
        saveData.damageModifier = damageModifier;
        saveData.scoreModifier = scoreModifier;
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void LoadGlobalGameSaveData()
    {
        if (File.Exists(Application.persistentDataPath + "/GlobalGameState.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GlobalGameState.dat", FileMode.Open);
            GlobalGameSaveData saveData = (GlobalGameSaveData)bf.Deserialize(file);
           playerHealth = saveData.playerHealth;
            playerShield = saveData.playerShield;
            currentXP = saveData.currentXP;
            currentScore = saveData.currentScore;
            damageModifier = saveData.damageModifier;
            scoreModifier = saveData.scoreModifier;

            file.Close();
        } 
    }
    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene(0);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene(1);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            SceneManager.LoadScene(2);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            SceneManager.LoadScene(3);

    }
}
