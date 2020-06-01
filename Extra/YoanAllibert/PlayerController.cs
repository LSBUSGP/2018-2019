using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float verticalForce;
    public float growScale;
    public GameObject cam;
    public Vector3 cameraOffset;
    public GameObject winPanel;
    
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private bool isGrounded = false;
    private float currentSize = 1f;
    private Vector3 lastCheckPoint;
    private bool isReversed = false;
    private bool controlReverse = false;
    private bool weWin = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lastCheckPoint = transform.position;
        winPanel.SetActive(false);
    }

    void Update()
    {
        if (!weWin)
        {
            cam.transform.position = transform.position + cameraOffset;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (isReversed)
            {
                rb.AddForce(-Vector2.up * 50f * verticalForce);
            }
            else
            {
                rb.AddForce(Vector2.up * 50f * verticalForce);
            }
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if (controlReverse)
        {
            move = -move;
        }
        if (move > 0f)
        {
            transform.localScale = new Vector3(1f * currentSize, transform.localScale.y, transform.localScale.z);
        }
        if (move < 0f)
        {
            transform.localScale = new Vector3(-1f * currentSize, transform.localScale.y, transform.localScale.z);
        }

        /* if(!isGrounded)
        {
            move /= 1.5f;
        }*/

        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        anim.SetInteger("Walk", (int)move);
    }
    
    void Shrink()
    {
        currentSize = growScale;
        transform.localScale = new Vector3(currentSize, currentSize, transform.localScale.z);
    }

    void ResizeToNormal()
    {
        currentSize = 1f;
        transform.localScale = new Vector3(currentSize, currentSize, transform.localScale.z);
    }

    void Win()
    { 
        winPanel.SetActive(true);
        winPanel.GetComponentInChildren<TypewriterEffect>().SendText();
        gameObject.SetActive(false);
        weWin = true;
        cam.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.parent != null && other.transform.parent.CompareTag("Floor"))
        {
            isGrounded = true;
            anim.SetBool("IsGrounded", isGrounded);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.parent != null && other.transform.parent.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.parent != null && other.transform.parent.CompareTag("Floor"))
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", isGrounded);
            anim.SetTrigger("Jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Potion"))
        {
            Shrink();
            Camera.main.orthographicSize = 7f;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            transform.position = lastCheckPoint;
            if (rb.gravityScale < 0)
            {
                rb.gravityScale = -rb.gravityScale;
                transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
                isReversed = !isReversed;
            }
        }

        if (other.CompareTag("Collect"))
        {
            lastCheckPoint = other.transform.position;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("ReverseGrav"))
        {
            rb.gravityScale = -rb.gravityScale;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            isReversed = !isReversed;
        }

        if (other.CompareTag("Mirror"))
        {
            controlReverse = !controlReverse;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Key"))
        {
            Destroy (other.gameObject);
        }

        if (other.CompareTag("Door"))
        {
            Win();
        }

        if (other.CompareTag("WhiteRabbit"))
        {
            transform.position = lastCheckPoint;
        }
    }
}