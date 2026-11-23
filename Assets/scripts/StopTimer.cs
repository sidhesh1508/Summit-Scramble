using UnityEngine;
using UnityEngine.Events;

public class StopTimer : MonoBehaviour
{
    [SerializeField] private UnityEvent onFinish;

    private bool hasFinished;

    private void OnTriggerEnter(Collider other)
    {
        if (hasFinished)
            return;

        PlayerController player =
            other.GetComponentInParent<PlayerController>();

        if (player == null)
            return;

        hasFinished = true;
        onFinish.Invoke();
    }
}