using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 15.0f;
    public Rigidbody2D rb;

    public bool isDead = false;
    public GameManager gameManager;

    public float heightOffset = 15.0f;
    public float minWidthOffset = -20.0f;
    public float maxWidthOffset = 20.0f;

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        // if the player clicks the left mouse button
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, jumpForce);
        }

        // move player to the right on the x-axis
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            rb.velocity = new Vector2(0, -3.5f);
            gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(0.5f, 0);
        }
        // move player to the left on the x-axis
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            rb.velocity = new Vector2(0, -3.5f);
            gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(-0.5f, 0);
        }

        // if the player is over the screen height or below the screen height
        if (transform.position.y > heightOffset || transform.position.y < -heightOffset)
        {
            gameManager.GameOver();
            isDead = true;
        }
        // if the player is over the screen width or below the screen width
        if (transform.position.x > maxWidthOffset || transform.position.x < minWidthOffset)
        {
            gameManager.GameOver();
            isDead = true;
        }

        if (rb.velocity.y < 0)
        {
            float angle = Mathf.Lerp(0, -90, -rb.velocity.y / 50);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            float angle = Mathf.Lerp(0, 45, rb.velocity.y / 50);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        gameManager.GameOver();
        isDead = true;
    }
}
