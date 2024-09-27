using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;
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

    public GlobalGameSaveData _GlobalGameSaveData;

    void Awake()
    {
        if (!initialized)
        {
            GameObject.DontDestroyOnLoad(gameObject);
            initialized = true;
        }
        else
            GameObject.Destroy(gameObject);

        keyStateMgr = gameObject.GetComponent<KeyStateManager>();
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), "currentLevel: " + SceneManager.GetActiveScene().name);
        GUI.Label(new Rect(10, 40, 200, 30), "currentLevel Index: " + SceneManager.GetActiveScene().buildIndex);
        GUI.Label(new Rect(10, 70, 200, 30), "playerHealth: " + _GlobalGameSaveData.playerHealth);
        GUI.Label(new Rect(10, 100, 200, 30), "playerShield: " + _GlobalGameSaveData.playerShield);
        GUI.Label(new Rect(10, 130, 200, 30), "currentXP: " + _GlobalGameSaveData.currentXP);
        GUI.Label(new Rect(10, 160, 200, 30), "currentScore: " + _GlobalGameSaveData.currentScore);
        GUI.Label(new Rect(10, 190, 200, 30), "damageModifier: " + _GlobalGameSaveData.damageModifier);
        GUI.Label(new Rect(10, 220, 200, 30), "scoreModifier: " + _GlobalGameSaveData.scoreModifier);
    
        if (GUI.Button(new Rect(10,300,100,30),"Health up"))
        {
            _GlobalGameSaveData.playerHealth += 10;
        }

        if (GUI.Button(new Rect(10, 340, 100, 30), "Health down"))
        {
            _GlobalGameSaveData.playerHealth -= 10;
        }

        if (GUI.Button(new Rect(10, 380, 100, 30), "Score up"))
        {
            _GlobalGameSaveData.currentScore += 10;
        }

        if (GUI.Button(new Rect(10, 420, 100, 30), "Score down"))
        {
            _GlobalGameSaveData.currentScore -= 10;
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
        bf.Serialize(file, _GlobalGameSaveData);
        file.Close();
    }

    public void LoadGlobalGameSaveData()
    {
        if (File.Exists(Application.persistentDataPath + "/GlobalGameState.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GlobalGameState.dat", FileMode.Open);
            _GlobalGameSaveData = (GlobalGameSaveData)bf.Deserialize(file);
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
