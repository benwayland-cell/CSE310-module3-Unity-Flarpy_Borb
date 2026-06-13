using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject controlPrompt;
    public GameObject gameOverScreen;
    public PipeSpawnerScript pipeSpawner;

    public int highScore;

    void Start()
    {
        SaveData gameData = SaveSystem.LoadGameData();
        if (gameData == null)
        {
            highScore = 0;
            return;
        }

        highScore = gameData.highScore;
        highScoreText.text = "High Score: " + highScore.ToString();
    }
    
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        if (playerScore > highScore)
        {
            highScore = playerScore;
        }

        SaveSystem.SaveGameState();
    }

    public void hideControlPrompt()
    {
        controlPrompt.SetActive(false);
    }

    public void startSpawningPipes()
    {
        pipeSpawner.startSpawning();
    }
}
