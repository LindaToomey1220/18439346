using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    private int currentState = 0;
    private GameObject currentlyActive = null;

    GameObject topSubmenu;

    //List of Submenus
    public List<GameObject> subMenus = new List<GameObject>(); //List of submenus
    Transform menuTransform = null;

    // Update is called once per frame
    private void Awake()
    {
        Debug.Log("Entered Awake in Menu");
        menuTransform = gameObject.transform; //lets the menu transform be the current gameobject
        foreach (Transform child in menuTransform) //adds all the submenu gameobjects to a list
        {
            subMenus.Add(child.gameObject);
        }
        topSubmenu = this.transform.Find("topLevelMenu").gameObject;
    }

    public void toggleMenu(GameObject submenu, Transform rHand)
    {
        Debug.Log("Entered toggleMenu in Menu");
        if (currentState == 0)
        {
            topSubmenu.SetActive(true); //sets the first submenu ("top menu") to active
            currentlyActive = topSubmenu;
            currentlyActive.transform.position = new Vector3(rHand.transform.position.x, rHand.transform.position.y, rHand.transform.position.z);
            currentlyActive.transform.rotation = Quaternion.Euler(new Vector3(currentlyActive.transform.rotation.eulerAngles.x, rHand.transform.rotation.eulerAngles.y, currentlyActive.transform.rotation.eulerAngles.z));
            currentState = 1;
        }
        
        else if(currentState == 0 && submenu != null)
        {
            currentlyActive.SetActive(false); //sets the top layer menu to inactive
            submenu.SetActive(true); //sets the selected submenu to active
            currentlyActive = submenu;
            currentlyActive.transform.position = new Vector3(rHand.transform.position.x, rHand.transform.position.y, rHand.transform.position.z);
            currentlyActive.transform.rotation = Quaternion.Euler(new Vector3(currentlyActive.transform.rotation.eulerAngles.x, rHand.transform.rotation.eulerAngles.y, currentlyActive.transform.rotation.eulerAngles.z));
            currentState = 2;
        }

        else if (currentState == 2 || (currentState == 1 && submenu == null)) //2= second layer, and the fed in submenu exists
        {
            //hides the menu again and removes the potential menu selections from the list of selectable objects
            currentlyActive.SetActive(false);
            currentlyActive = null;
            currentState = 0;
            //Debug.Log("set state 0");
        }
    }

    public int getState()
    {
        Debug.Log("Entered getState in Menu");
        return currentState;
    }
}
