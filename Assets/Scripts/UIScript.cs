using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

    float stayTime = 2.0f;
    float currentTime = 0;

    Text textChild;

    Color targetColour;

	// Use this for initialization
	void Start () {

        textChild = GetComponentInChildren<Text>();

	}
	
	// Update is called once per frame
	void Update () {

        if (currentTime > 0)
            currentTime -= Time.deltaTime;
        else if (currentTime < 0)
        {
            currentTime = 0;
            targetColour = Color.clear;
        }

        textChild.color = Color.Lerp(textChild.color, targetColour, 0.1f);

	}

    public void ShowMessage(string message)
    {
        textChild.text = message;

        currentTime = stayTime;

        targetColour = Color.gray;
    }
}
