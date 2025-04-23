using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cube : MonoBehaviour
{
    [SerializeField]
    MeshRenderer MeshRenderer;
    [SerializeField]
    GameObject cube;

    private PlayerInputAction action;

    private void Awake()
    {
        action = new PlayerInputAction();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cube.SetActive(true);

            action.Player.Action.Enable();
            action.Player.Action.performed += ChangeColor;
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cube.SetActive(false);
            action.Player.Action.Disable();
            action.Player.Action.performed -= ChangeColor;
            Debug.Log("exit");
        }
    }

    public void ChangeColor(InputAction.CallbackContext context)
    {
        if(MeshRenderer.material.color != Color.green)
            MeshRenderer.material.color = Color.green;
        else
            MeshRenderer.material.color = Color.white;
    }
}
