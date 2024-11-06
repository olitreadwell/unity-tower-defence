using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public UIDocument uiDocument;

    public Button playAgainButton;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Get the root of the UI document

        if (uiDocument == null)
        {
            Debug.Log("UI Document not found");
            return;
        }

        var rootVisualElement = uiDocument.rootVisualElement;

        Button playAgainButton = rootVisualElement.Q<Button>("playAgainButton");

        if (playAgainButton != null)
        {
            Debug.Log("Found Play Again Button");
            playAgainButton.style.visibility = Visibility.Hidden;
        }
        else
        {
            Debug.Log("Play Again Button not found");
        }
    }
}
