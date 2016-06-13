using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class MoveScript : MonoBehaviour {

    Vector3 center;
    GameObject gvrMain;

    GvrReticle reticle;

    GameObject crouchObject;

    float moveCooldown = 0;

	// Use this for initialization
	void Start () {

        center = new Vector3(Screen.width/2, Screen.height/2, 0);
        gvrMain = GameObject.Find("GvrMain");
        reticle = gvrMain.GetComponentInChildren<GvrReticle>();
        crouchObject = GameObject.Find("Croucher");
	}
	
	// Update is called once per frame
	void Update () {

        if (moveCooldown > 0)
            moveCooldown -= Time.deltaTime;
        if (moveCooldown < 0)
            moveCooldown = 0;
	}

    public void MoveTo(BaseEventData data)
    {
        if (moveCooldown == 0)
        {
            PointerEventData ped = (PointerEventData)data;
            Vector3 target_pos = ped.pointerCurrentRaycast.worldPosition;
            target_pos.y = gvrMain.transform.position.y;
            gvrMain.transform.position = target_pos;

            moveCooldown = 1.0f;
        }
    }

    public void Crouch(BaseEventData data)
    {
        if (moveCooldown == 0)
        {
            Vector3 target_pos = gvrMain.transform.position;
            Vector3 crouch_pos = Vector3.zero;
            if (gvrMain.transform.position.y > 1)
            {              
                target_pos.y = 0.8f;
                crouch_pos.y = -0.75f;
            }
            else
            {
                target_pos.y = 1.8f;
                crouch_pos.y = -1.75f;
            }
            gvrMain.transform.position = target_pos;
            crouchObject.transform.localPosition = crouch_pos;

            moveCooldown = 1.0f;
        }
    }
}
