using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PauseMeanu pauseMenu;

    private void Start()
    {
        playerController.enabled = false;
        pauseMenu.enabled = false;

        instructionsPanel.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        instructionsPanel.SetActive(false);

        Time.timeScale = 1f;
        playerController.enabled = true;
        pauseMenu.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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