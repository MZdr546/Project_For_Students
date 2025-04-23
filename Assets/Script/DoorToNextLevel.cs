using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DoorToNextLevel : MonoBehaviour
{
    private PlayerInputAction action;

    private void Awake()
    {
        action = new PlayerInputAction();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player");
            if (GlobalInformation.haveKey == true)
            {
                Debug.Log("next level");
                action.Player.Action.Enable();
                action.Player.Action.performed += NextLevel;
                
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        action.Player.Action.Disable();
        action.Player.Action.performed -= NextLevel;
    }

    public void NextLevel(InputAction.CallbackContext context)
    {
        Debug.Log("next level load");
        SceneManager.LoadSceneAsync(2);
    }
}
