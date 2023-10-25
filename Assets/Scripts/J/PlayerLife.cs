using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Animator anim;

    public GameObject gameOverScreen;
    public GameObject gamePauseScreen;
    public GameObject gameFinishScreen;
    [SerializeField] private AudioSource hitCatSoundEffect;
    [SerializeField] private AudioSource gameOverSoundEffect;
    [SerializeField] private AudioSource HitMouse;
    [SerializeField] private AudioSource finishSoundEffect;
    

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update(){
        
    }
    void FixedUpdate(){

    }
    public void TakeDamage(int amount){
        GameManager.Instance.Hit(amount);
    }
    

    private void OnTriggerEnter2D(Collider2D collision){  
        if(collision.gameObject.CompareTag("Enemy")){
            anim.SetBool("IsHit", true);
            if(GameManager.Instance.lives <= 0){
                anim.SetBool("IsHit", false);
                anim.SetBool("IsDead", true);
                playerMovement.enabled = false;
                GameManager.Instance.gameOver(gameOverScreen);
                gameOverSoundEffect.Play();
            }            
        } 
        if(collision.gameObject.CompareTag("Water")){
            // OPTION 1X HIT LANGSUNG MATI
            // GameManager.Instance.DeadByWater(5);
            // OPTION 5X HIT
            hitCatSoundEffect.Play();
            GameManager.Instance.Hit(1);
            anim.SetBool("IsHit", true);
            if(GameManager.Instance.lives <= 0){
                anim.SetBool("IsHit", false);
                anim.SetBool("IsDead", true);
                playerMovement.enabled = false;
                GameManager.Instance.gameOver(gameOverScreen);
                gameOverSoundEffect.Play();
            }
        }

        if(collision.gameObject.CompareTag("CatsLevel1")){
            GameManager.Instance.FinishGame(gameFinishScreen);
            finishSoundEffect.Play();
            // set coin
            GameManager.Instance.setAllKoinStage();
            GameManager.Instance.setAllKoin();
        }
            
        if(collision.gameObject.CompareTag("cityBottomWall")){
            // di city jatuh 
            hitCatSoundEffect.Play();
            GameManager.Instance.Hit(5);
            anim.SetBool("IsHit", true);
            if(GameManager.Instance.lives <= 0){
                anim.SetBool("IsHit", false);
                anim.SetBool("IsDead", true);
                playerMovement.enabled = false;
                GameManager.Instance.gameOver(gameOverScreen);
                gameOverSoundEffect.PlayDelayed(0.5f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            anim.SetBool("IsHit", false);     
        } 
        if(collision.gameObject.CompareTag("Water")){
            anim.SetBool("IsHit", false); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("TrapHit")){
            hitCatSoundEffect.Play();
            GameManager.Instance.Hit(1);
            anim.SetBool("IsHit", true);
            if(GameManager.Instance.lives <= 0){
                anim.SetBool("IsHit", false);
                anim.SetBool("IsDead", true);
                playerMovement.enabled = false;
                GameManager.Instance.gameOver(gameOverScreen);
                gameOverSoundEffect.Play();
            } 
        }
        if(collision.gameObject.CompareTag("Enemy")){
            HitMouse.PlayDelayed(-1f);
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("TrapHit")){
            anim.SetBool("IsHit", false);
        }
    } 
    public void pauseGame(){
        GameManager.Instance.PauseGame(gamePauseScreen);
    }
}
