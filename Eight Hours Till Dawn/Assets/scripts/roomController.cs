using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomController : MonoBehaviour
{
    public GameObject roomText;

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
        roomDataArray[0, 0] = -10; // X position
        roomDataArray[0, 1] = -5; // Y position

        roomDataArray[1, 0] = -10; // X position
        roomDataArray[1, 1] = -1; // Y position

        roomDataArray[2, 0] = -6; // X position
        roomDataArray[2, 1] = -3; // Y position

        roomDataArray[3, 0] = 0; // X position
        roomDataArray[3, 1] = -5; // Y position

        roomDataArray[4, 0] = 0; // X position
        roomDataArray[4, 1] = -3; // Y position

        roomDataArray[5, 0] = 7; // X position
        roomDataArray[5, 1] = -3; // Y position

        roomDataArray[6, 0] = 11; // X position
        roomDataArray[6, 1] = -3; // Y position

        roomDataArray[7, 0] = -10; // X position
        roomDataArray[7, 1] = 1; // Y position

        roomDataArray[8, 0] = 3; // X position
        roomDataArray[8, 1] = 1; // Y position

        roomDataArray[9, 0] = 9; // X position
        roomDataArray[9, 1] = 2; // Y position

        roomDataArray[10, 0] = -10; // X position
        roomDataArray[10, 1] = 3; // Y position

        roomDataArray[11, 0] = -4; // X position
        roomDataArray[11, 1] = 3; // Y position

        roomDataArray[12, 0] = 3; // X position
        roomDataArray[12, 1] = 4; // Y position

        roomDataArray[13, 0] = -10; // X position
        roomDataArray[13, 1] = 6; // Y position

        roomDataArray[14, 0] = 8; // X position
        roomDataArray[14, 1] = 6; // Y position

        //roomDataArray[15, 0] = ; // X position
        //roomDataArray[15, 1] = ; // Y position
        #endregion // room positions

        // loop through every room and create a text prefab at its center
        for (var i = 0; i < roomDataArray.GetLength(0); i++)
        {
            var xPos = roomDataArray[i, 1];
            var yPos = roomDataArray[i, 2];

            var newText = Instantiate(roomText);
            newText.transform.position = new Vector2 (xPos, yPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
