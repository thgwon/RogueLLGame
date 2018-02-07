﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    const int verticalMovement = 10;
    const int horizontalMovement = 18;

    public enum Direction { Right=0, UpSide=1, Left=2, DownSide=3};

    public GameObject doorPrefab;
    public Camera gameCamera;
    public Player playerobejct;
    private BoardManager boardManager;

    // Use this for initialization
    void Start() {
        GameObject doorObject = Instantiate( doorPrefab, new Vector2( 7, 0 ), Quaternion.identity ) as GameObject;
        Door door = doorObject.GetComponent<Door>();
        door.direction = Direction.Right;

        doorObject = Instantiate( doorPrefab, new Vector2( -7, 0 ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.Left;

        doorObject = Instantiate( doorPrefab, new Vector2( 0, 5 ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.UpSide;

        doorObject = Instantiate( doorPrefab, new Vector2( 0, -5 ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.DownSide;
        playerobejct = GameObject.Find( "Player" ).GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveNextRoom(Direction direction) {
        //if(map is valid)
        {
            switch(direction) {
            case Direction.Right:
                gameCamera.transform.position += new Vector3Int( horizontalMovement, 0, 0 );
                playerobejct.transform.position += new Vector3Int( horizontalMovement, 0, 0 );
                break;
            case Direction.Left:
                gameCamera.transform.position -= new Vector3Int( horizontalMovement, 0, 0 );
                playerobejct.transform.position -= new Vector3Int( horizontalMovement, 0, 0 );
                break;
            case Direction.UpSide:
                gameCamera.transform.position += new Vector3Int( 0, verticalMovement, 0 );
                playerobejct.transform.position += new Vector3Int( 0, verticalMovement, 0 );
                break;
             case Direction.DownSide:
                gameCamera.transform.position -= new Vector3Int(0, verticalMovement, 0 );
                playerobejct.transform.position -= new Vector3Int( 0, verticalMovement, 0 );
                break;
            }

        }
    }
}
