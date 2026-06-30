using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles pausing the game, freezing time, and navigating from the pause menu using the New Input System.
/// </summary>
public class UI_PausePanel : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject pausePanelContainer;

    [Header("Input Settings")]
    [SerializeField] private InputActionReference pauseAction;

    private bool isPaused = false;

    private void OnEnable()
    {
        if (pauseAction != null)
        {
            pauseAction.action.performed += OnPauseAction;
        }
    }

    private void OnDisable()
    {
        if (pauseAction != null)
        {
            pauseAction.action.performed -= OnPauseAction;
        }
    }

    private void Start()
    {
        pausePanelContainer.SetActive(false);
    }

    private void OnPauseAction(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pausePanelContainer.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanelContainer.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void OnResumeButtonClicked()
    {
        ResumeGame();
    }

    public void OnRestartButtonClicked()
    {
        ServiceLocator.GetService<CustomSceneManager>().RestartGameplay();
    }

    public void OnMainMenuButtonClicked()
    {
        ServiceLocator.GetService<CustomSceneManager>().GoToMainMenuFromGameplay();
    }
}