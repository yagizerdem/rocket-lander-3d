using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrollBarController : MonoBehaviour
{
    public GameObject buttonPrefab;
    public RectTransform contentPanel;
    void Start()
    {
        CreateButtons();
    }

    void CreateButtons()
    {
        // Clear any existing buttons
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        float buttonHeight = 30f; // Adjust based on your button's RectTransform height
        float spacing = 10f; // Space between buttons
        int numberOfButtons = SceneManager.sceneCountInBuildSettings - 1;

        float totalHeight = (buttonHeight + spacing) * numberOfButtons;
        contentPanel.sizeDelta = new Vector2(contentPanel.sizeDelta.x, totalHeight);
        // Instantiate buttons
        for (int i = 0; i < numberOfButtons; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, contentPanel);
            RectTransform buttonRect = newButton.GetComponent<RectTransform>();

            // Set button position
            buttonRect.anchoredPosition = new Vector2(0, -i  * (buttonHeight + spacing) + (580 / 30) * numberOfButtons); // dont know what is goint on

            TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = "Level " + (i + 1);

            Button button = newButton.GetComponent<Button>();
            if (button != null)
            {
                int index = i+1; // Create a local copy of the loop variable
                button.onClick.AddListener(() => OnButtonClick(index));
            }
            else
            {
                Debug.LogWarning("No Button component found in button prefab.");
            }
        }
    }

    void OnButtonClick(int levelNo)
    {

        SceneManager.LoadScene(levelNo);
    }
}
