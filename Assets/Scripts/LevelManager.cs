using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    public bool levelActive;
    private bool levelVictory;

    public UIDocument uiDocument;

    private Button playAgainButton;

    private Castle castle;

    public List<EnemyHealthController> enemies = new List<EnemyHealthController>();

    private SimpleEnemySpawner enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        var rootVisualElement = uiDocument.rootVisualElement;

        playAgainButton = rootVisualElement.Q<Button>("playAgainButton");

        if (playAgainButton != null)
        {
            playAgainButton.style.visibility = Visibility.Hidden;
        }
        else
        {
            Debug.Log("Play Again Button not found");
        }

        castle = FindObjectOfType<Castle>();
        enemySpawner = FindObjectOfType<SimpleEnemySpawner>();

        levelActive = true;
    }

    // Update is called once per frame
    void Update()
    {



        if (playAgainButton == null)
        {
            Debug.Log("Play Again Button not found");
            return;
        }
        {




            // Debug.Log("Enemies: " + enemies.Count);
            // Debug.Log("Total Enemies left to spawn: " + enemySpawner.totalEnemiesToSpawn);
            if (castle.currentHealth <= 0)
            {
                levelActive = false;
                levelVictory = false;
                // display play again screen
                Debug.Log("Castle Destroyed");
                playAgainButton.style.visibility = Visibility.Visible;
            }
            else if (enemies.Count - 1 == 0 && enemySpawner.totalEnemiesToSpawn == 0)
            {
                levelActive = false;
                levelVictory = true;
                Debug.Log("Level Complete");

                // var progressElement = healthProgressBar.Q(className: "unity-progress-bar__progress");

                playAgainButton.style.visibility = Visibility.Visible;
                // load Scene 2
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }

            // if (playAgainButton.style.visibility == Visibility.Visible)
            // {
            //     playAgainButton.clicked += () =>
            //     {
            //         Debug.Log("Play Again Button Clicked");
            //         // reload the scene
            //         if (levelVictory) { }
            //         // {
            //         //     // load Scene 2
            //         //     UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            //         // }
            //         // else
            //         // {
            //         //     // load Scene 1
            //         //     UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            //         // }
            //     };
            // }

        }
    }
}
