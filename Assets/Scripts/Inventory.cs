﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    // Use this for initialization
    public int size = 12;
    private GameObject inventoryItemPrefab;
    private ItemManager.Label [] labelList;
    private GameObject [] inventoryObject;
    public ItemManager itemManager;

    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Initialize()
    {
        inventoryItemPrefab = GameObject.Find ("PlayerUI").GetComponent<PlayerUI> ().inventoryItemPrefab;
        labelList = new ItemManager.Label [size];
        inventoryObject = new GameObject [size];
        itemManager = GameObject.Find ("ItemManager").GetComponent<ItemManager> ();
        for ( int i = 0; i < 6; i++ )
        {
            inventoryObject [i] = Instantiate (inventoryItemPrefab, new Vector2 (-8, i * 1.5f - 4), Quaternion.identity);
            inventoryObject [i].transform.parent = GameObject.Find ("PlayerUI").transform;
            inventoryObject [i + size / 2] = Instantiate (inventoryItemPrefab, new Vector2 (8, i * 1.5f - 4), Quaternion.identity);
            inventoryObject [i + size / 2].transform.parent = GameObject.Find ("PlayerUI").transform;
            labelList [i] = labelList [i + 6] = ItemManager.Label.Empty;
        }
    }

    public void AddItem(ItemManager.Label label)
    {
        int location;
        for ( location = 0; location < size; location++ )
        {
            Debug.Log (inventoryObject);
            if ( labelList [location] == ItemManager.Label.Empty ) break;
        }

        if ( location < size )
        {
            labelList [location] = label;
            inventoryObject [location].GetComponent<SpriteRenderer> ().sprite = itemManager.LabelToSprite (label);
        }
        else
        {
            Debug.Log ("아이템이 꽉찼다.");
        }
    }
}
