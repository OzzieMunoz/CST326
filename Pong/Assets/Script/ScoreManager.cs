using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;

    public BallController ball;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreUI();
    }

    public void GoalScored(bool goalOnRightSide)
    {
        if (goalOnRightSide)
            leftScore++;
        else
            rightScore++;

        Debug.Log($"Score! Left: {leftScore} | Right: {rightScore}");
        UpdateScoreUI();

        if (leftScore >= 11 || rightScore >= 11)
        {
            string winner = (leftScore >= 11) ? "Left" : "Right";
            Debug.Log($"Game Over, {winner} Paddle Wins");

            leftScore = 0;
            rightScore = 0;
            UpdateScoreUI();
        }
        
        ball.ResetRound(scoredOnRight: goalOnRightSide);
    }

    void UpdateScoreUI()
    {
        scoreText.text = $"{leftScore} : {rightScore}";
    }
}