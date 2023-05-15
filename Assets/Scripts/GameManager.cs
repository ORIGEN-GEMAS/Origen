using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; //Activate text to finish the game
    public Button restartButton; //Activate the buttom to start the game
    public bool isGameActive;
    private ButtonController buttonController;

    public void Die()
    {
        isGameActive = false;
        buttonController.RestartGame();
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        
    }
}
