using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// in order to use the text data type you must import UnityEngine.UI
using UnityEngine.UI;

public class roomController : MonoBehaviour
{
    public GameObject roomText;
    public Text roomName;
    public Transform parent;

    // create the room array where we will store every room name, its position, and its neighbors
    // y0 : name | y1 : x position of room | y2 : y position of room | y3 : bombs
    public int[,] roomDataArray = new int[16, 4];

    // create a new 2d array to store the information of which rooms are neighbors
    public int[,] roomNeighborArray = new int[17, 5];

    // Start is called before the first frame update
    void Start()
    {

        // loop through the x position of the array, filling each room name with it's corisponding #
        for (var i = 0; i < roomDataArray.GetLength(0); i++)
        {
            roomDataArray[i, 0] = i;
            roomDataArray[i, 0] = i + 1;
        }

        // RoomData array init | includes room # and x/y position
        #region

        // Store the center of each room 
        // Room 16

        roomDataArray[0, 1] = -10; // X position
        roomDataArray[0, 2] = -5; // Y position
                                  //roomDataArray[0, 3] = new int[1, 15]; // neighbors

        // room 1
        roomDataArray[1, 1] = -10; // X position
        roomDataArray[1, 2] = -1; // Y position
        //roomDataArray[1, 3] = 

        // room 2
        roomDataArray[2, 1] = -0; // X position
        roomDataArray[2, 1] = 0; // X position
        roomDataArray[2, 2] = -1; // Y position

        roomDataArray[3, 1] = 0; // X position
        roomDataArray[3, 2] = -6; // Y position

        // Room 4
        roomDataArray[4, 1] = 0; // X position
        roomDataArray[4, 2] = -4; // Y position

        roomDataArray[5, 1] = 7; // X position
        roomDataArray[5, 2] = -3; // Y position

        roomDataArray[6, 1] = 11; // X position
        roomDataArray[6, 2] = -3; // Y position

        roomDataArray[7, 1] = -10; // X position
        roomDataArray[7, 2] = 1; // Y position

        roomDataArray[8, 1] = 3; // X position
        roomDataArray[8, 2] = 1; // Y position

        roomDataArray[9, 1] = 9; // X position
        roomDataArray[9, 2] = 2; // Y position

        roomDataArray[10, 1] = -10; // X position
        roomDataArray[10, 2] = 3; // Y position

        roomDataArray[11, 1] = -4; // X position
        roomDataArray[11, 2] = 3; // Y position

        roomDataArray[12, 1] = 3; // X position
        roomDataArray[12, 2] = 4; // Y position

        roomDataArray[13, 1] = -10; // X position
        roomDataArray[13, 2] = 6; // Y position

        // room 15
        roomDataArray[14, 1] = 8; // X position
        roomDataArray[14, 2] = 6; // Y position

        roomDataArray[15, 1] = -6; // X position
        roomDataArray[15, 2] = -5; // Y position

        #endregion // room positions


        // initalize the room neighbor array | store the room # for each room's neighbor
        #region        
        // we skip room 0 because in roomDataArray we have store the room #s as being 1 higher then their actual
        // location in the array. I.e cell 0,0 in the array says room #1.

        //Room 1
        roomNeighborArray[1, 0] = 1; // room number
        roomNeighborArray[1, 1] = 15; // neighbor 1
        roomNeighborArray[1, 2] = 16; // neighbor 2

        //Room 2
        roomNeighborArray[2, 0] = 2; // room number
        roomNeighborArray[2, 1] = 4; // neighbor 1
        roomNeighborArray[2, 2] = 5; // neighbor 2

        //Room 3
        roomNeighborArray[3, 0] = 3; // room number
        roomNeighborArray[3, 1] = 5; // neighbor 1
        roomNeighborArray[3, 2] = 15; // neighbor 2

        //Room 4
        roomNeighborArray[4, 0] = 4; // room number
        roomNeighborArray[4, 1] = 2; // neighbor 1
        roomNeighborArray[4, 2] = 5; // neighbor 2
        roomNeighborArray[4, 3] = 15; // neighbor 3

        //Room 5
        roomNeighborArray[5, 0] = 5; // room number
        roomNeighborArray[5, 1] = 2; // neighbor 1
        roomNeighborArray[5, 2] = 3; // neighbor 2
        roomNeighborArray[5, 3] = 4; // neighbor 3
        roomNeighborArray[5, 4] = 6; // neighbor 4

        //Room 6
        roomNeighborArray[6, 0] = 6; // room number
        roomNeighborArray[6, 1] = 5; // neighbor 1

        //Room 7
        roomNeighborArray[7, 0] = 7; // room number
        roomNeighborArray[7, 1] = 8; // neighbor 1
        roomNeighborArray[7, 2] = 10; // neighbor 2
        roomNeighborArray[7, 3] = 15; // neighbor 3

        //Room 8
        roomNeighborArray[8, 0] = 8; // room number
        roomNeighborArray[8, 1] = 7; // neighbor 1
        roomNeighborArray[8, 2] = 9; // neighbor 2
        roomNeighborArray[8, 3] = 12; // neighbor 3

        //Room 9
        roomNeighborArray[9, 0] = 9; // room number
        roomNeighborArray[9, 1] = 5; // neighbor 1
        roomNeighborArray[9, 2] = 8; // neighbor 2
        roomNeighborArray[9, 3] = 12; // neighbor 3

        //Room 10
        roomNeighborArray[10, 0] = 10; // room number
        roomNeighborArray[10, 1] = 7; // neighbor 1
        roomNeighborArray[10, 2] = 11; // neighbor 2
        roomNeighborArray[10, 3] = 13; // neighbor 3

        //Room 11
        roomNeighborArray[11, 0] = 11; // room number
        roomNeighborArray[11, 1] = 10; // neighbor 1
        roomNeighborArray[11, 2] = 12; // neighbor 2

        //Room 12
        roomNeighborArray[12, 0] = 12; // room number
        roomNeighborArray[12, 1] = 8; // neighbor 1
        roomNeighborArray[12, 2] = 9; // neighbor 2
        roomNeighborArray[12, 3] = 11; // neighbor 3
        roomNeighborArray[12, 4] = 13; // neighbor 4
        roomNeighborArray[12, 4] = 14; // neighbor 5

        //Room 13
        roomNeighborArray[13, 0] = 13; // room number
        roomNeighborArray[13, 1] = 10; // neighbor 1
        roomNeighborArray[13, 2] = 12; // neighbor 2

        //Room 14
        roomNeighborArray[14, 0] = 14; // room number
        roomNeighborArray[14, 1] = 12; // neighbor 1

        //Room 15
        roomNeighborArray[15, 0] = 15; // room number
        roomNeighborArray[15, 1] = 1; // neighbor 1
        roomNeighborArray[15, 2] = 3; // neighbor 2
        roomNeighborArray[15, 3] = 4; // neighbor 3
        roomNeighborArray[15, 4] = 7; // neighbor 4
        roomNeighborArray[15, 4] = 16; // neighbor 5

        //Room 16
        roomNeighborArray[16, 0] = 16; // room number
        roomNeighborArray[16, 1] = 1; // neighbor 1
        roomNeighborArray[16, 2] = 15; // neighbor 2
        #endregion

        // loop through every room and create a text prefab at its center
        for (var i = 0; i < roomDataArray.GetLength(0); i++)
        {
            // get the x and y positions of the rooms center 
            var xPos = roomDataArray[i, 1];
            var yPos = roomDataArray[i, 2];

            // create a new text prefab and store it in a var
            var newText = Instantiate(roomText);

            // retreive the transform of the canvas object
            newText.transform.SetParent(parent);


            // Convert the xPos and yPos into coordinates on the screen, then store it.
            Vector3 PosInScreen = Camera.main.WorldToScreenPoint(new Vector2(xPos, yPos));

            // move each text prefab to their new location in the world
            newText.transform.position = PosInScreen;

            // in the objects text componet set the value to the room number
            roomName.text = "Room " + (i + 1);
            roomName.text = "Room " + roomDataArray[i, 0];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
