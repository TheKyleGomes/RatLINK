using UnityEngine;

public class GameController : MonoBehaviour
{

    public float levelTimer;
    public float levelDifficulty;

    private float difficultyTimer;

    void Start()
    {
        RestartRun();
    }

    void Update()
    {
        UpdateTimers();

        if (difficultyTimer <= 0)
        {
            IncreaseDifficulty();
            ResetDifficultyTimer();
        }
    }

    void UpdateTimers()
    {
        levelTimer += Time.deltaTime;
        difficultyTimer -= Time.deltaTime;
    }

    void RestartRun()
    {
        levelTimer = 0.0f;
        levelDifficulty = 0.0f;
        ResetDifficultyTimer();
    }

    void IncreaseDifficulty()
    {
        levelDifficulty += 0.1f;
    }

    void ResetDifficultyTimer()
    {
        difficultyTimer = 60.0f;
    }

}
