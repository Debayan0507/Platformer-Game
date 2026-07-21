using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject playerSpawn;

    public float jumpSpeed = 15f;
    public float speed = 5f;
    public float dashSpeed = 12f;

    public float score = 0f;

    public float dashCoolDown = 0.6f;

    private float horizontalAxis;

    public bool isGrounded = false;
    public bool canDash = true;
    public bool canShoot = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = playerSpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Dash();
        Shoot();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("YOU WIN!");
            SceneManager.LoadScene("Boss Battle");
            Debug.Log(score);
            canShoot = true;

        }

        if (collision.gameObject.tag == "Collectible")
        {
            score += 1;
            Destroy(collision.gameObject);
            Debug.Log(score);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void Jump()
    {
        //jump if grounded
        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }
        }
    }
    void Move()
    {
        //move
        horizontalAxis = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * speed * horizontalAxis, ForceMode2D.Force);
    }
    void Shoot()
    {
        if(canShoot == true && Input.GetKeyDown(KeyCode.X))
        {
            score -= 1;
            Debug.Log(score);
        }
    }
    void Dash()
    {
        //dash
        if (Input.GetKeyDown(KeyCode.C) && canDash == true)
        {
            if (horizontalAxis < 0f)
            {
                rb.AddForce(Vector2.left * dashSpeed, ForceMode2D.Impulse);
            }
            else if (horizontalAxis > 0f)
            {
                rb.AddForce(Vector2.right * dashSpeed, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.right * dashSpeed, ForceMode2D.Impulse);
            }

            canDash = false;
            Invoke("DashCoolDown", dashCoolDown);
        } 
    }
    void DashCoolDown()
    {
        canDash = true;
    }
 
}
