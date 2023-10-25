using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testCityItemCollector : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] private Text coinsText;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Koin")){
            Destroy(collision.gameObject);
            coins++;
            coinsText.text = "Coins : " + coins;
        }
    }
}
