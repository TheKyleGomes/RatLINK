using UnityEngine;

public class GameController : MonoBehaviour
{

    public float levelTimer;
    public float levelDifficulty;

    private float difficultyTimer;

    void Start()
    {
        levelTimer = 0.0f;
        levelDifficulty = 0.0f;
        resetDifficultyTimer();
    }

    void Update()
    {
        levelTimer += Time.deltaTime;
        difficultyTimer -= Time.deltaTime;

        if (difficultyTimer <= 0)
        {
            increaseDifficulty();
            resetDifficultyTimer();
        }
    }

    void increaseDifficulty()
    {
        levelDifficulty += 0.1f;
    }

    void resetDifficultyTimer()
    {
        difficultyTimer = 60.0f;
    }
}
