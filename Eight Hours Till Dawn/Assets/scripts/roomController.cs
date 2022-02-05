using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roomController : MonoBehaviour
{
    public GameObject roomText;
    public Text roomName;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
    // create the room array where we will store every room name, its position, and its neighbors
    // y0 : name | y1 : x position of room | y2 : y position of room | y3 : bombs
    int[,] roomDataArray = new int[16, 3];

        // loop through the x position of the array, filling each room name with it's corisponding #
        for (var i = 0; i < roomDataArray.GetLength(0); i++)
        {
            roomDataArray[i, 0] = i;
        }

        #region
        
        // Store the center of each room 
        // Room 16
        roomDataArray[0, 1] = -10; // X position
        roomDataArray[0, 2] = -5; // Y position

         
        // room 1
        roomDataArray[1, 1] = -10; // X position
        roomDataArray[1, 2] = -1; // Y position

        // room 2
        roomDataArray[2, 1] = -0; // X position
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
