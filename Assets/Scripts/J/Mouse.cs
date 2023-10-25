using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Sprite flatSprite;
    public Animator anim;
    public EnemyMovement enemyMovement;

    void Start(){
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            if(collision.transform.DotTest(transform, Vector2.down)){
                anim.SetTrigger("IsDead");
                anim.SetTrigger("IsHit");
                Dead();
            }    
        }
    }

    private void Dead(){
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
        Destroy(gameObject, 0.5f);
    }

}
