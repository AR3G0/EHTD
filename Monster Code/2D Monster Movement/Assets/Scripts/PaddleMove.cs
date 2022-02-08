using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 movement;
    public GameHandler gameHandlerObj;
    public GameObject hitVFX;
    public GameObject starsVFX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("GameHandler") != null)
        {
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    void FixedUpdate()
    {
        if(gameObject.tag == "paddle")
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "tree")
        {
            if (gameObject.tag == "paddle")
            {
                gameObject.GetComponent<AudioSource>().Play();
                GameObject boomFX = Instantiate(hitVFX, other.gameObject.transform.position, Quaternion.identity);
                GameObject starFX = Instantiate(starsVFX, other.gameObject.transform.position, Quaternion.identity);
                StartCoroutine(DestroyVFX(starFX));
                StartCoroutine(DestroyVFX(boomFX));
                Destroy(other.gameObject);
                gameHandlerObj.AddScore(1);
            }
            else if (gameObject.tag == "wall")
            {
                Destroy(other.gameObject);
            }
        }
    }

    IEnumerator DestroyVFX(GameObject theEffect)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(theEffect);
        gameObject.GetComponent<AudioSource>().Stop();
    }

}