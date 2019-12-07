using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInput : MonoBehaviour ,interactable
{

     public bool clicked ;

    public void ClickAction()
    {
        clicked = !clicked;
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

       
	}
}
