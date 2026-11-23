using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TMP_Text statsText;
    [SerializeField] private Timer timer;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PauseMeanu pauseMenu;

    private bool hasWon;

    private void Start()
    {
        winPanel.SetActive(false);
    }

    public void ShowWin()
    {
        if (hasWon)
            return;

        hasWon = true;
        timer.StopTimer();

        // Prevent gameplay input and Escape from resuming the game.
        playerController.enabled = false;
        pauseMenu.enabled = false;

        statsText.text = "Final Time: " + timer.FormattedTime;
        winPanel.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}