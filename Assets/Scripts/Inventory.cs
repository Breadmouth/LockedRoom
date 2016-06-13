using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    List<string> items;  

	// Use this for initialization
	void Start () {

        items = new List<string>();

	}

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public bool CheckItem(string item)
    {
        foreach (string thing in items)
        {
            if (thing == item)
                return true;
        }
        return false;
    }
}
