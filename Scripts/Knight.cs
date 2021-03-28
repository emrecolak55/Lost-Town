using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{

    //config
    [SerializeField] int playerHealth = 100;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);
    //State
    bool isAlive = true;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;
    [SerializeField] AudioClip swordClip;
    [SerializeField] AudioClip grassWalkClip;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;

        FindObjectOfType<GameSession>().SetHealth(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Attack();
        Run();
        FlipSprite();
        Jump();
        ClimbLadder();
        TravelOnWater();
        //Die();
    }
    private void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            myAnimator.SetTrigger("Attack");
        }
    }
    private void ClimbLadder()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("Climbing", false);
            myRigidBody.gravityScale = gravityScaleAtStart;
            return;
        }
        myRigidBody.gravityScale = 0f;
        float controlThrow = Input.GetAxis("Vertical");
        Vector2 jumpVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
        myRigidBody.velocity = jumpVelocity;
        bool playerVertical = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;

        myAnimator.SetBool("Climbing", playerVertical);
    }
    private void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }


        if (Input.GetButtonDown("Jump")) // GetButton -> continuosly, getbuttondown -> one time press
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }
    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); // -1 to 1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHorizontal = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        myAnimator.SetBool("Running", playerHorizontal);


    }
   
    private void FlipSprite()
    {

        bool playerHorizontal = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHorizontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }


    }
    public void DecreaseHealth(int givenDamage)
    {
        playerHealth -= givenDamage;
        FindObjectOfType<GameSession>().SetHealth(playerHealth);
        if ( playerHealth <= 0)
        {
            FindObjectOfType<GameSession>().PlayerDeath();
            GetComponent<Rigidbody2D>().velocity = deathKick;
            isAlive = false;
            myAnimator.SetTrigger("Die");
        }
    }
    public void PlaySwordSound()
    {
        AudioSource.PlayClipAtPoint(swordClip, Camera.main.transform.position);
    }
    public void PlayGrassWalkSound()
    {
        AudioSource.PlayClipAtPoint(grassWalkClip, Camera.main.transform.position);
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    private void TravelOnWater()
    {
        if(myFeet.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            Physics.gravity = new Vector3(0, 0, 0);
            Debug.Log("asdsa");

        }
        else
        {
            Physics.gravity = new Vector3(0, -9.81F, 0);
        }


    }
    
}
