using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderMovement : MonoBehaviour
{
    // initilze vars
    #region
    // the location of this hider
    public int roomNumber;


    // These vars are uses to trigger hiderMovement every X seconds
    private float startTime;
    private bool canDoThis;

    // turn increases by one ever time the hider moves.
    // since Time.time cannot be reset we simply modulat the threshold for trigging over time
    private int turn;

    // get the object that the room controller is within
    public GameObject roomData;


    // this is a var of the type roomController (the script!)
    roomController roomControllerVar;

    //initalize the color var so we can pick a random hue.
    SpriteRenderer spriteColor;

    #endregion

    // Awake is called before anything else (even start)
    void Awake()
    {
        roomData = GameObject.Find("roomController");
        roomControllerVar = roomData.GetComponent<roomController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // start time is the time that has pased since the game started
        startTime = Time.time;
        canDoThis = false;
        turn = 1;

        // get the sprite renderer componet then generate a random color.
        spriteColor = GetComponentInChildren<SpriteRenderer>();
        chooseColor();
    }

    // Update is called once per frame
    void Update()
    {
        // Set canDoThis to true after 5 seconds have passed
        if (!canDoThis)
        {

            if (Time.time - startTime > (5 * turn))
            {
                canDoThis = true;
                Debug.Log("Time is up!");
                hiderMove();
            }
        }
    }

    public void hiderMove()
    {
        // initilze a new array to hold the current neighbors that this object is next to. 
        // It is five places because there can be up to five neighboring rooms.
        int[] neighborArray = new int[5];


        // extract every neighboring room from the neighbor array in the room controller. 
        // then store each piece in a new array.
        for (var i = 0; i < neighborArray.Length; i++)
        {
            // if the cell in the global neighbor array is not nothing (0) and is not the hider's room (roomNumber) add it to the new array.
            if (roomControllerVar.roomNeighborArray[roomNumber, i] != 0 && roomControllerVar.roomNeighborArray[roomNumber, i] != roomNumber)
            {
                neighborArray[i] = roomControllerVar.roomNeighborArray[roomNumber, i];
            }
        }


        //randomly select one of the rooms from the neighbor array that is not 0
        var newRoomFromArray = 0;
        while (newRoomFromArray == 0)
        {
            newRoomFromArray = neighborArray[Random.Range(1, 5)];
        }


        // update roomNumber with the new room
        roomNumber = newRoomFromArray;

        //Reterive the room coords from the roomDataArray in the roomController object
        var newPosX = roomControllerVar.roomDataArray[roomNumber, 1];
        var newPosY = roomControllerVar.roomDataArray[roomNumber, 2];

        // Used the new room coords to transform the hiders position to new room.
        transform.position = new Vector2(newPosX, newPosY);

        // restart timer
        turn += 1;
        canDoThis = false;
    }

    private void chooseColor()
    {
        var r = Random.Range(0f, 1f);
        var g = Random.Range(0f, 1f);
        var b = Random.Range(0f, 1f);
        spriteColor.color = new Color(r, g, b, 1);
    }
}