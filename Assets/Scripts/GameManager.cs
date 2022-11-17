using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public static bool isRunning;

    public static float totalDistance;

    public TMP_Text txtTotalDistance;

    private void OnEnable()
    {
        BirdController.onBirdDie += StopGame;
    }

    private void OnDisable()
    {
        BirdController.onBirdDie -= StopGame;
    }

    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
    }

    void StopGame()
    {
        SetHighScore();
        isRunning = false;
        gameOverPanel.SetActive(true);
        txtTotalDistance.text = "Best Distance: \n" + GetHighScore().ToString("N1");
    }

    public void _btnQuit()
    {
        Application.Quit();
    }

    public void _btnRetry()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetHighScore()
    {
        if (PlayerPrefs.HasKey("hiscore"))
        {
            float tempScore = PlayerPrefs.GetFloat("hiscore");

            if(totalDistance > tempScore)
            {
                PlayerPrefs.SetFloat("hiscore", totalDistance);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("hiscore", totalDistance);
        }
    }

    float GetHighScore()
    {
        return PlayerPrefs.HasKey("hiscore") ? PlayerPrefs.GetFloat("hiscore") : 0f;
    }
}
