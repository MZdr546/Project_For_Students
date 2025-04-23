using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    [SerializeField]
    Transform Startingpoint;
    [SerializeField]
    Transform Coinpoint;
    [SerializeField]
    GameObject Coin;

    private void Start()
    {
        Instantiate(Coin, Coinpoint);
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent.position = Startingpoint.position;
        }
    }

}
