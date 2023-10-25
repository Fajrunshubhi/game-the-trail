using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerLife playerHealth;
    public int damage = 1;
    public EnemyMovement enemyMovement;
    [SerializeField] private AudioSource hitCatSoundEffect;
    
    private void OnTriggerEnter2D(Collider2D collision){
        StartCoroutine(Hurt());
        if(collision.gameObject.CompareTag("EnemyHit")){
            hitCatSoundEffect.Play();
            playerHealth.TakeDamage(damage);
            enemyMovement.moveSpeed = 0f; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("EnemyHit")){
            enemyMovement.moveSpeed = 2f;
        }
    }

    IEnumerator Hurt()
	{
		yield return new WaitForSeconds (5f);
        
	}
}
