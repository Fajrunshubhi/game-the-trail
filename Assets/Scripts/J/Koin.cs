using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koin : MonoBehaviour
{
    // [SerializeField] private AudioSource coinSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision){  
        if(collision.gameObject.CompareTag("Player")){
            // coinSoundEffect.Play();           
            GameManager.Instance.setKoin(1);
            Destroy(gameObject);           
        }
    }
}
