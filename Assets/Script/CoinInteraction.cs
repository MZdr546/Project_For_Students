using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteraction : MonoBehaviour
{
    [SerializeField]
    CoinCollecting coinCollecting;
    [SerializeField]
    float rotateSpeed = 1f;

    bool isCollected = false;

    private void Awake()
    {
        GlobalInformation.AllCoinsOnMap += 1;
        StartCoroutine(CoinRotation());
    }

    private void Update()
    {
        if(gameObject.active)
        {
            if (isCollected == true)
            {
                Debug.Log("start");
                StartCoroutine(CoinRotation());
                isCollected = false;
            }

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GlobalInformation.CollectedCoins += 1;
            coinCollecting.ChangeText();
            isCollected = true;
        }
    }

    public IEnumerator CoinRotation()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);

            yield return new WaitForSeconds(0.01f);
        }

        yield return null;
    }
}
