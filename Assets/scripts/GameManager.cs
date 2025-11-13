using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    public int score = 0;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI totalScoreText;
    public ScoreSave scoreSave;

    private void Awake()
    {
        if (instance != null) { 
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void updateScore(int amount)
    {
        score += amount;
       scoreSave.score += amount;
        scoreText.text = "Score: " + score;
        totalScoreText.text = "Total Score: " + scoreSave.score;
       
    }

    public void restartScore()
    {
        score = 0;
    }
}
