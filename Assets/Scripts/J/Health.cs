using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){  
        if(collision.gameObject.CompareTag("Player")){           
            if(GameManager.Instance.lives < GameManager.Instance.maxLives){
                GameManager.Instance.Heal(1);
                Destroy(gameObject);
            }               
        }
    }
}
