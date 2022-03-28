using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPopup : MonoBehaviour
{
    private Transform rHand = null; 
    public GameObject menu; //the menu game object
    private Menu menuScript;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Entered Start in menuPopup");
        rHand = gameObject.transform;
        menu = GameObject.FindWithTag("Menu");
        menuScript = menu.GetComponent<Menu>();

    }

    // Update is called once per frame
    public void toggleMenu()
    {
        Debug.Log("Entered toggleMenu in menuPopup");
        menuScript.toggleMenu(null, rHand);
    }
}





