using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayer : MonoBehaviour
{
    private Rigidbody2D mRigidbody;
    public float mDirX, mMagnitudeVeclocity = 4f;
    public bool isDead, isHurting;
    public int mHealth = 10;
    public Animator mAnim;
    GameObject mMonster;

    public AudioSource soundPlayer;
    public AudioClip attackSound;
    public AudioClip hurtSound;
    public AudioClip deadSound;
    public GameObject mHammer;
    [Header("Unity Stuff")]
    public Image mHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        mRigidbody = this.GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();
        soundPlayer = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
     void Update()
    {
        
        if (!isDead)
        {
            mDirX = Input.GetAxisRaw("Horizontal") * mMagnitudeVeclocity;//move
        }
        
        if(Input.GetKeyUp(KeyCode.UpArrow) && !isDead && mRigidbody.velocity.y == 0)
        {
            
            PlayerJump();
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            mMagnitudeVeclocity = 10f;//run
        }
        else
        {
            mMagnitudeVeclocity = 4f;//walk
        }
        SetAnimationState();
        
       

    }
   
    void PlayerJump()
    {
       
        mRigidbody.AddForce(Vector2.up *10f, ForceMode2D.Impulse);
        mAnim.SetBool("isJumping", true);

    }

    void OnAttackingFinished()
    {
        mAnim.SetBool("isAttacking", false);
        mHammer.GetComponent<HammerCollision>().hammerAttack = false;
    }

    void OnAttack()
    {
        mHammer.GetComponent<HammerCollision>().hammerAttack = true;
    }
   
    private void FixedUpdate()
    {
        if (!isHurting)
            mRigidbody.velocity = new Vector2(mDirX, mRigidbody.velocity.y);
      
    }

    void SetAnimationState()
    {
       
        if(mDirX == 0)
        {
            mAnim.SetBool("isRuning", false);
        }
        //if(mRigidbody.velocity.y > 0)
        //{
        //    mAnim.SetBool("isJumping", true);
        //}
        if(mRigidbody.velocity.y <= 0)
        {
            mAnim.SetBool("isRuning", false);
        }
  
        if (Mathf.Abs(mDirX) == 10 && mRigidbody.velocity.y == 0)
        {
            mAnim.SetBool("isRuning", true);
        }
        else
        {
            mAnim.SetBool("isRuning", false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            mAnim.SetBool("isAttacking", true);
            mAnim.SetBool("isJumping", false);
            soundPlayer.PlayOneShot(attackSound);
        }
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            mHealth = mHealth -1;
            mHealthBar.fillAmount = mHealth/10f;
            mAnim.SetBool("isHurting", true);
        }


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ship")
        {
            gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {

                PlayerJump();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "collision" && mHealth > 0)
        {
            mHealth = mHealth - 1;
            mHealthBar.fillAmount = mHealth / 10f;
            mAnim.SetBool("isHurting", true);
            soundPlayer.PlayOneShot(hurtSound);
        }

        if (collision.gameObject.tag == "collisinWall" || mHealth <= 0)
        {
            Debug.Log("dead");
            soundPlayer.PlayOneShot(deadSound);
             Destroy(gameObject);
             OnGameOver();
        }
    }
    private void OnGameOver()
    {
        Debug.Log("Gameover");
        Application.LoadLevel("GameOver");
    }
    public void OnQuit()
    {
        Application.Quit();
        Debug.Log("QuitGame");
    }

}
