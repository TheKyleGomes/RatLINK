using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("↦ Difficulty Settings")]
    [Tooltip("Difficulty at which pod delays reach their fastest values.")]
    public float difficultyTarget = 0.5f;
    [SerializeField] private float difficultyIncreaseInterval = 60.0f;

    [Space(5)]
    [Header("↦ Start Pod Delays (secs)")]
    [SerializeField] private float startMinDelay = 8.0f;
    [SerializeField] private float startMaxDelay = 16.0f;

    [Space(5)]
    [Header("↦ Fastest Pod Delays (secs)")]
    [SerializeField] private float fastestMinDelay = 3.0f;
    [SerializeField] private float fastestMaxDelay = 6.0f;

    [Space(5)]
    [Header("↦ Current Run (debug)")]
    public float levelTimer;
    public float levelDifficulty;
    [SerializeField] private float difficultyTimer;
    [SerializeField] private float difficultyProgress;

    void Start()
    {
        RestartRun();
    }

    void Update()
    {
        UpdateTimers();
        CalculateDifficultyProgress();

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
        difficultyTimer = difficultyIncreaseInterval;
    }

    void CalculateDifficultyProgress()
    {
        difficultyProgress = Mathf.Clamp01(levelDifficulty / difficultyTarget);
    }
}
