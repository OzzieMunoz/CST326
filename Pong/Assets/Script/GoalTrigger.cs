using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public bool isRightGoal;
    public ScoreManager scoreManager;

    void OnTriggerEnter(Collider other)
    {
        BallController ball = other.GetComponent<BallController>();
        scoreManager.GoalScored(isRightGoal);
    }
}