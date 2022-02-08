using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hinderMovement : MonoBehaviour
{
    public int roomNumber;
    public float startTimer;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = startTimer;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0)
        {

        }

        timer -= 1;
    }
}
