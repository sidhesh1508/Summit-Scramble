
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMeanu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private bool isPaused = false;

    private void Start()
    {
       
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }
}