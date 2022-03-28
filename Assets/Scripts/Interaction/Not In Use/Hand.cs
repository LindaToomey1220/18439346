using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    //The hand game object
    private GameObject spawnedObject = null;
    private Hand myHandScript = null;
    private GameObject menu = null;
    private Menu menuScript;
    private Transform lHand = null;
    private Transform rHand = null;
    private float distance;

    // Update is called once per frame
    private void Awake()
    {
        Debug.Log("Entered Awake in Hand");
        menu = GameObject.FindWithTag("Menu");
        myHandScript = this;
        menuScript = menu.GetComponent<Menu>();
        lHand = gameObject.transform;
        rHand = gameObject.transform;
    }

    public void createMenuItem(GameObject other)
    {
        Debug.Log("Entered createMenuItem in Hand");
        menuItem currentMenuItem = other.GetComponent<menuItem>();
        if (currentMenuItem.isTopLayer)
        {
            spawnedObject = currentMenuItem.objectToSpawn;
            menuScript.toggleMenu(spawnedObject, rHand);
        }

        else
        {
            GameObject object1 = Resources.Load("Objects/" + currentMenuItem.findObject) as GameObject;
            GameObject spawnedOb = Instantiate(object1, transform.position, Quaternion.identity);
            Debug.Log("Object Spawned");
            spawnedOb.name = spawnedOb.name + uniqueIDGenerator.GetID();
            uniqueIDGenerator.SetID();
            menuScript.toggleMenu(null, rHand);
        }
    }
}


