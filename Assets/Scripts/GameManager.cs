using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverMenu;
    private int score;
    public bool isGameOver;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = $"SCORE: {score}";
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        isGameOver = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
