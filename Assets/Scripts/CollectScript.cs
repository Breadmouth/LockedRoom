using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CollectScript : MonoBehaviour {

    Inventory inventory;

    UIScript ui;

	// Use this for initialization
	void Start () {

        inventory = GameObject.Find("GvrMain").GetComponent<Inventory>();
        ui = GameObject.Find("Canvas").GetComponent<UIScript>();
	}

    public void Pickup(BaseEventData data)
    {
        PointerEventData ped = (PointerEventData)data;

        inventory.AddItem(ped.pointerPressRaycast.gameObject.name.ToString());

        ui.ShowMessage("Picked up " + ped.pointerPressRaycast.gameObject.name.ToString());

        Destroy(ped.pointerPressRaycast.gameObject);
    }

    public void LeaveLevel(BaseEventData data)
    {
        if (inventory.CheckItem("Key"))
        {
            //there is a key in the inventory
            ui.ShowMessage("Level Ended");
        }
    }

    public void DoorOpen(BaseEventData data)
    {
        PointerEventData ped = (PointerEventData)data;

        ped.pointerCurrentRaycast.gameObject.GetComponent<DoorScript>().ToggleOpen();
    }
}
