using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;
    public int winningScore = 11;
    public float baseShakeDuration = 1f;
    public float baseShakeMagnitude = 8f;
    public float maxShakeMultiplier = 4f;

    public BallController ball;
    public TextMeshProUGUI scoreText;
    public PowerUpSpawner powerUpSpawner;
    public CameraShake scoreShake;

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

        if (scoreShake != null)
        {
            int highestScore = Mathf.Max(leftScore, rightScore);
            float progress = Mathf.Clamp01((float)highestScore / winningScore);

            float duration = baseShakeDuration * Mathf.Lerp(1f, maxShakeMultiplier, progress);
            float magnitude = baseShakeMagnitude * Mathf.Lerp(1f, maxShakeMultiplier, progress);

            scoreShake.Shake(duration, magnitude);
        }

        if (leftScore >= 11 || rightScore >= 11)
        {
            string winner = (leftScore >= 11) ? "Left" : "Right";
            Debug.Log($"Game Over, {winner} Paddle Wins");

            leftScore = 0;
            rightScore = 0;
            UpdateScoreUI();
        }

        ball.ResetRound(scoredOnRight: goalOnRightSide);

        if (powerUpSpawner != null)
            powerUpSpawner.ResetSpawns();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"{leftScore} : {rightScore}";
    }
}