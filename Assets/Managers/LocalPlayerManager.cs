using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LocalPlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject gameManager;
    private KeyStateManager KeyStateManager;
    private gui guiManager;
    private LevelManager levelManager;
    private SharedVariables sharedVariables;
    private InventoryManager inventoryManager;

    private float currentFuel = 100.0f;
    private float currentNitro = 0.0f;


    private Rigidbody2D rb;
    private Vector2 vecVelocity;
    private Vector2 vecVelocityBeforeStop;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        KeyStateManager = gameManager.GetComponent<KeyStateManager>();
        guiManager = gameManager.GetComponent<gui>();
        levelManager = gameManager.GetComponent<LevelManager>();
        sharedVariables = gameManager.GetComponent<SharedVariables>();
        inventoryManager = gameManager.GetComponent<InventoryManager>();

        rb = GetComponent<Rigidbody2D>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

      //collision.gameObject.name PoliceCar / Grass

        levelManager.LoadScene("MainMenu");
        guiManager.SwitchScreen(gui.ScreenIndex.Upgrades, true);

        Debug.Log("Collided");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();

        if (tilemap != null)
        {
            // Get the player's position in world space
            Vector3 closestPoint = collision.ClosestPoint(transform.position);

            // Convert the closest point to the nearest cell in the tilemap
            Vector3Int cellPosition = tilemap.WorldToCell(closestPoint);

            // Check if the cell contains a tile before attempting removal
            if (tilemap.HasTile(cellPosition))
            {
                // Handle different cases based on the object/tag the player collides with
                switch (collision.name)  // Ensure the objects are tagged properly in the Inspector
                {
                    case "Fuels":
                        {
                            currentFuel = Mathf.Clamp(currentFuel + 40.0f, 0.0f, 100.0f);
                            sharedVariables.UpdateFuelAmount(currentFuel);
                            break;
                        }
                    case "Coins1":
                        {
                            inventoryManager.AddCoins(1);
                            break;
                        }
                    case "Coins5":
                        {
                            inventoryManager.AddCoins(5);
                            break;
                        }
                    case "Coins10":
                        {
                            inventoryManager.AddCoins(10);
                            break;
                        }
                    case "Nitros":
                        {
                            currentNitro = 100.0f;
                            break;
                        }
                    default:
                        break;
                }

                // Remove only the specific tile at this cell position
                tilemap.SetTile(cellPosition, null);
            }
        }
        else
        {
            // Handle non-tilemap objects if needed
            Destroy(collision.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (currentFuel > 0)
        {
            currentFuel = Mathf.Clamp(currentFuel - .2f, 0.0f, 100.0f);
            sharedVariables.UpdateFuelAmount(currentFuel);
        }

        vecVelocity.y = 5;  
        vecVelocity.x = 0;  

        if (KeyStateManager.CheckKeyState(KeyCode.A))
            vecVelocity.x = -5;  
        else if (KeyStateManager.CheckKeyState(KeyCode.D))
            vecVelocity.x = 5;



        if (currentFuel <= 0.0f)
        {
            vecVelocityBeforeStop.x = Mathf.Lerp(vecVelocityBeforeStop.x, 0, Time.fixedDeltaTime * 5);
            vecVelocityBeforeStop.y = Mathf.Lerp(vecVelocityBeforeStop.y, 0, Time.fixedDeltaTime * 5);
            vecVelocity = vecVelocityBeforeStop;

            if (vecVelocity.magnitude < 0.1f)
            {
                levelManager.LoadScene("MainMenu");
                guiManager.SwitchScreen(gui.ScreenIndex.Upgrades, true);
                /*
                vecVelocityBeforeStop = Vector2.zero;
                vecVelocity = Vector2.zero;
                rb.velocity = Vector2.zero;  
                rb.Sleep();  */
            }
        }
        else
        {
            if (currentNitro > 0.0f)
            {
                currentNitro = Mathf.Clamp(currentNitro - 1.0f, 0.0f, 100.0f);
                sharedVariables.UpdateNitroAmount(currentNitro);
                vecVelocity.y += 5;
            }

            vecVelocityBeforeStop = rb.velocity;
        }
       // if (vecVelocity.x != 0)
          //  vecVelocity.y += 5.0f;

        rb.velocity = vecVelocity;
    }

    void Update()
    {
  

    }
}
