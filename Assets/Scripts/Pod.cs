using UnityEngine;

public enum PodState
    {
        InProgress,
        InDistress,
        AssistanceInProgress
    }

public class Pod : MonoBehaviour
{
    [SerializeField] private PodState currentState = PodState.InProgress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
