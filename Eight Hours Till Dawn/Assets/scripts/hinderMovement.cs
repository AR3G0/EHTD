using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hinderMovement : MonoBehaviour
{
    // the location of this hider
    public int roomNumber;
    public float startTimer;
    private float timer;

    // These vars are uses to trigger hiderMovement every X seconds
    private float startTime;
    private bool canDoThis;

    public GameObject roomData;

    // Start is called before the first frame update
    void Start()
    {
        // start time is the time that has pased since the game started
        startTime = Time.time;
        canDoThis = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0)
            // Set canDoThis to true after 20 seconds have passed
            if (!canDoThis)
            {

                if (Time.time - startTime > 5)
                {
                    canDoThis = true;
                    Debug.Log("Time is up!");
                }
            }
    }

    
    public void hiderMovement()
    {
        /*
        var neighbor = roomData.GetComponent<roomNeighborArray>().worldArray[17, 5];
        Debug.Log(neighbor);
        
        for (var i = 0; i < 5; i++)
        {
            if()
        }
        */
    }
}