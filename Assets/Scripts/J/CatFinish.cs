using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFinish : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private AudioSource finishSoundEffect;
    void start(){
        anim = GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            anim.SetBool("IsHappy", true);
            finishSoundEffect.Play();
        }
    }
}
