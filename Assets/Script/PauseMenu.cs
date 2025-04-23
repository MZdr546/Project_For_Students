using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject PauseMenuObject;

    private PlayerInputAction action;
    bool isPaused = false;

    private void Awake()
    {

        action = new PlayerInputAction();
        action.Player.Esc.Enable();
        action.Player.Esc.performed += EscAction;

    }

    public void EscAction(InputAction.CallbackContext context)
    {
        if(isPaused)
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
        PauseMenuObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void BackToMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }

}
