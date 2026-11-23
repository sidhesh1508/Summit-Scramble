using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private float elapsedTime = 0f;
    private bool isRunning = true;

    public string FormattedTime
    {
        get
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void Update()
    {
        if (!isRunning)
            return;

        elapsedTime += Time.deltaTime;
        timerText.text = FormattedTime;
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}