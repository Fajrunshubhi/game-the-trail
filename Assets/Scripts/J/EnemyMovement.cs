using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D myRigidbody;
    public bool flipBody;
    public Animator anim;
    public bool isHurting;
    public bool isDead;
    private void Start(){
        myRigidbody = GetComponent<Rigidbody2D>();
        flipBody = true;
        anim = GetComponent<Animator>();
    }
    private void Update(){
        if(flipBody){
            myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
            transform.eulerAngles = Vector3.zero;
        }else{
            myRigidbody.velocity = new Vector2(-moveSpeed, myRigidbody.velocity.y);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }       
    }
    private void FixedUpdate(){
   
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Flip")){
            flipBody = !flipBody;
        }
        // if(collision.CompareTag("Player")){
        //     anim.SetBool("IsWalk", false);
        //     anim.SetTrigger("IsHit");
        //     isDead = true;  
        //     moveSpeed = 0;      
        // } 
        // if(isDead){        
        //     anim.SetTrigger("IsDead");
        //     Destroy(gameObject, 0.5f);      
        // }
    }


    
}
