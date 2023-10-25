using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // GameObject Rigidbody2D component
    private new Rigidbody2D rigidbody;
    // Mengatur Kamera
    private new Camera camera;
    private float inputAxis; // Nilai Input Horizontal (nilai x)
    // Untuk Mengatur Kecepatan gerak horizonal dan vertikal
    private Vector2 velocity; // Kecepatan gerak horizonal dan vertikal
    public float moveSpeed = 5f; // Kecepatan Bergerak yang ditentukan

    public PlayerLife playerHealt;

    // Player Jump
    public float maxJumpHeight = 6f; // max jump
    public float maxJumpTime = 1.5f; // Waktu maksimal jump
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);

    // Mengecek apakah karakter di ground
    public bool grounded {
        get;
        private set;
    }
    // Mengecek apakah karakter Jump
    public bool jumping {
        get;
        private set;
    }
    private int totJump = 1;
    private int doubJump;

    private Animator animator;

    // LADDER
    private float ladderVertical;
    private float ladderSpeed = 5f;
    private bool isLadder;
    private bool isClimbing;
    private bool isHurting, isDead;

    // AUDIO
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource coinSoundEffect;
 
    private void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        doubJump = totJump;   
        animator = GetComponent<Animator>();
        //playerHealt = GetComponent<PlayerLife>();
    }

    private void Update(){
        if (Input.GetKey (KeyCode.LeftShift)){
            moveSpeed = 10f;
            animator.SetBool("IsRunning", true);
        }else{
            animator.SetBool("IsRunning", false);
            moveSpeed = 5f;
        }
        HorizontalMovement();
        grounded = rigidbody.Raycast(Vector2.down);
        if(grounded){
            GroundedMovement();
            doubJump = totJump;
        }
        if(jumping && doubJump > 0){
            JumpAgain();
        }
        ApplyGravity();
        SetAnimationState();

        // LADDER
        if(!isDead){
            ladderVertical = Input.GetAxis("Vertical");
            if(isLadder && Mathf.Abs(ladderVertical) > 0f){
                isClimbing = true;
            }
        }    
        
    }

    private void FixedUpdate(){
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        

        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rigidbody.MovePosition(position);

        // LADDER
        if(isClimbing){
            velocity.y = Mathf.MoveTowards(velocity.y, ladderVertical * ladderSpeed, moveSpeed);
        }

    }

    private void HorizontalMovement(){
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed);
        if(rigidbody.Raycast(Vector2.right * velocity.x)){
            animator.SetBool("IsWalking", false);
        }
        if(velocity.x > 0f){
            transform.eulerAngles = Vector3.zero;
        } else if(velocity.x < 0f){
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }        
    }

    private void GroundedMovement(){
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0f;

        if(Input.GetButtonDown("Jump")){
            jumpSoundEffect.Play();
            velocity.y = jumpForce;
            jumping = true;
        }
    }

    private void JumpAgain(){
        if((Input.GetButtonDown("Jump"))){
            jumpSoundEffect.Play();
            velocity.y = jumpForce-1f;
            doubJump-=1;
        }
    }

    private void ApplyGravity(){
        bool falling = velocity.y < 0f || !Input.GetButtonDown("Jump");
        float multiplier = falling ? 2f : 1f;
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    public void SetAnimationState(){
        if (velocity.x != 0){
            animator.SetBool("IsWalking", true);
        } else if(inputAxis == 0){
            velocity.x = 0f;
            animator.SetBool("IsWalking", false);
        }
        if(velocity.y > 0f){
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsWalking", false);
        } else if(velocity.y < 0f ){
            animator.SetBool("IsJumping", false);
        }
    }

    // LADDER
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Ladder")){
            isLadder = true;
            animator.SetBool("IsClimb", true);
        } 
        if(collision.gameObject.CompareTag("Koin")){
            coinSoundEffect.Play();                   
        }
        if(collision.gameObject.CompareTag("Water")){
            velocity.y = 10f;
            jumping = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Ladder")){
            isLadder = false;
            isClimbing = false;
            animator.SetBool("IsClimb", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy")){
            if(transform.DotTest(collision.transform, Vector2.down)){
                velocity.y = 10f;
                jumping = true;
            }
        }
        else if(collision.gameObject.layer != LayerMask.NameToLayer("PowerUp")){
            if(transform.DotTest(collision.transform, Vector2.up)){
                velocity.y = 0f;
            }
        }   

        if(collision.gameObject.CompareTag("TrapHit")){
            if(transform.DotTest(collision.transform, Vector2.down)){
                velocity.y = 10f;
                jumping = true;
            }
        }        
    }
}
