using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    void Start()
    {

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), "currentLevel: " + SceneManager.GetActiveScene().name);
        GUI.Label(new Rect(10, 40, 200, 30), "currentLevel Index: " + SceneManager.GetActiveScene().buildIndex);
        GUI.Label(new Rect(10, 70, 200, 30), "playerHealth: " + playerHealth);
        GUI.Label(new Rect(10, 100, 200, 30), "playerShield: " + playerShield);
        GUI.Label(new Rect(10, 130, 200, 30), "currentXP: " + currentXP);
        GUI.Label(new Rect(10, 160, 200, 30), "currentScore: " + currentScore);
        GUI.Label(new Rect(10, 190, 200, 30), "damageModifier: " + damageModifier);
        GUI.Label(new Rect(10, 220, 200, 30), "scoreModifier: " + scoreModifier);
    
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
