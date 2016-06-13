using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    bool open = false;

    public bool swingDir = true;
    public bool hasParent = true;

    GameObject parent;

    Vector3 originalRot;

	// Use this for initialization
	void Start () {

        if (hasParent)
        {
            parent = transform.parent.gameObject;
            originalRot = parent.transform.localRotation.eulerAngles;
        }
        else
            originalRot = transform.localRotation.eulerAngles;

        if (!swingDir)
        {
            if (hasParent)
            {
                parent.transform.localRotation = Quaternion.Euler(new Vector3(parent.transform.localRotation.x, parent.transform.localRotation.y, 359.9f));
                originalRot = parent.transform.localRotation.eulerAngles;
            }
            else
            {
                transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, transform.localRotation.y, 359.9f));
                originalRot = transform.localRotation.eulerAngles;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (swingDir)
        {
            if (open)
            {
                if (hasParent)
                    parent.transform.localRotation = Quaternion.Euler(Vector3.Lerp(parent.transform.localRotation.eulerAngles, originalRot + new Vector3(0, 0, 90), 0.1f));
                else
                    transform.localRotation = Quaternion.Euler(Vector3.Lerp(transform.localRotation.eulerAngles, originalRot + new Vector3(0, 0, 90), 0.1f));
            }
            else
            {
                if (hasParent)
                    parent.transform.localRotation = Quaternion.Euler(Vector3.Lerp(parent.transform.localRotation.eulerAngles, originalRot, 0.1f));
                else
                    transform.localRotation = Quaternion.Euler(Vector3.Lerp(transform.localRotation.eulerAngles, originalRot, 0.1f));
            }
        }
        else
        {
            if (open)
            {
                if (hasParent)
                    parent.transform.localRotation = Quaternion.Euler(Vector3.Lerp(parent.transform.localRotation.eulerAngles, originalRot - new Vector3(0, 0, 90), 0.1f));
                else
                    transform.localRotation = Quaternion.Euler(Vector3.Lerp(transform.localRotation.eulerAngles, originalRot - new Vector3(0, 0, 90), 0.1f));
            }
            else
            {
                if (hasParent)
                    parent.transform.localRotation = Quaternion.Euler(Vector3.Lerp(parent.transform.localRotation.eulerAngles, originalRot, 0.1f));
                else
                    transform.localRotation = Quaternion.Euler(Vector3.Lerp(transform.localRotation.eulerAngles, originalRot, 0.1f));
            }
        }

	}

    public void ToggleOpen()
    {
        if (open)
            open = false;
        else open = true;
    }
}
