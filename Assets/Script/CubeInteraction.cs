using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 1f;

    Vector3 startingPosition;
    Vector3 endingPosition;
    [SerializeField]
    float height = 1f;
    [SerializeField]
    float heightSpeed = 1f;
    [SerializeField]
    bool isUp = false;

    private void Awake()
    {
        startingPosition = transform.position;
        endingPosition = transform.position;
        endingPosition.y += height;
    }

    private void OnEnable()
    {
        StartCoroutine(CubeMovement());
    }

    private void OnDisable()
    {
        StopCoroutine(CubeMovement());
    }

    public IEnumerator CubeMovement()
    {
        while(true)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);

            if(!isUp)
            {
                if (transform.position.y < endingPosition.y - 0.05f)
                    transform.position = Vector3.Slerp(transform.position, endingPosition, Time.deltaTime * heightSpeed);
                else
                    isUp = true;
            }
            else
            {
                if (transform.position.y > startingPosition.y + 0.05f)
                    transform.position = Vector3.Slerp(transform.position, startingPosition, Time.deltaTime * heightSpeed);
                else
                    isUp = false;
            }

            yield return new WaitForSeconds(0.01f);
        }

        yield return null;
    }
}
