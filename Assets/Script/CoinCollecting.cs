using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollecting : MonoBehaviour
{
    [SerializeField]
    TMP_Text Text;

    private void Start()
    {
        Text.text = GlobalInformation.CollectedCoins.ToString() + "/" + GlobalInformation.AllCoinsOnMap.ToString();
    }

    public void ChangeText()
    {
        Text.text = GlobalInformation.CollectedCoins.ToString() + "/" + GlobalInformation.AllCoinsOnMap.ToString();
    }
}
