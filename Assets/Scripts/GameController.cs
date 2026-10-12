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
    [Header("↦ Distress Cap Settings")]
    [SerializeField] private int startDistressCap = 2;
    [SerializeField] private int maxDistressCap = 5;

    [Space(5)]
    [Header("↦ Current Run (debug)")]
    public float levelTimer;
    public float levelDifficulty;
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;
    [SerializeField] private int distressCap;
    [SerializeField] private float difficultyTimer;
    [SerializeField] private float difficultyProgress;
    [SerializeField] private int difficultyIncreasesSinceCapIncrease = 0;

    void Start()
    {
        RestartRun();
    }

    void Update()
    {
        UpdateTimers();
        CalculateDifficultyProgress();
        CalculateCurrentDelay();

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
        ResetDistressCap();
    }

    void IncreaseDifficulty()
    {
        levelDifficulty += 0.1f;
        difficultyIncreasesSinceCapIncrease += 1;
        CalculateDistressCap();
    }

    void ResetDifficultyTimer()
    {
        difficultyTimer = difficultyIncreaseInterval;
    }

    void ResetDistressCap()
    {
        distressCap = startDistressCap;
        difficultyIncreasesSinceCapIncrease = 0;
    }

    void CalculateDifficultyProgress()
    {
        difficultyProgress = Mathf.Clamp01(levelDifficulty / difficultyTarget);
    }

    void CalculateCurrentDelay()
    {
        minDelay = Mathf.Lerp(startMinDelay, fastestMinDelay, difficultyProgress);
        maxDelay = Mathf.Lerp(startMaxDelay, fastestMaxDelay, difficultyProgress);
    }

    void CalculateDistressCap()
    {
        if (difficultyIncreasesSinceCapIncrease >= 2)
        {
            if (distressCap < maxDistressCap)
            {
                distressCap += 1;
            }
            difficultyIncreasesSinceCapIncrease = 0;
        }
    }
}
