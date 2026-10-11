using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum PodState
    {
        InProgress,
        InDistress,
        AssistanceInProgress
    }

public class Pod : MonoBehaviour
{
    [SerializeField] private PodState currentState = PodState.InProgress;
    [SerializeField] TMP_Text podStatus;
    [SerializeField] TMP_Text podNumber;
    [SerializeField] Image podBackground;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
