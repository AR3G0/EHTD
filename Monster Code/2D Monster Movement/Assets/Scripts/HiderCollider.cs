using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderCollider : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameHandler gameHandlerObj;
    public GameObject hitVFX;
    public GameObject starsVFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("GameHandler") != null)
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            if(gameObject.tag == "Hider")
            {
                GameObject boomFX = Instantiate(hitVFX, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                gameHandlerObj.AddScore(1);
            }
    }
}
