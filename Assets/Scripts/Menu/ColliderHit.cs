using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ColliderHit : MonoBehaviour
{
    public GameObject topLevelMenu;
    public GameObject sublevel;
    public GameObject topMenuItem;
    public GameObject menuItemTouched;
    public GameObject itemToSpawn;
    public bool topLevelItem;
    bool isInstantiated = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "menuItem")
        {
            if (col.gameObject.name != "" || col.gameObject.name == "RightHandVisual" || col.gameObject.name == "OculusHand_R" || col.gameObject.name == "HandGrabInteractor" || col.gameObject.name == "OVRHandPrefab")
            {

                if (topLevelItem)
                {
                    topLevelMenu.SetActive(false);
                    sublevel.SetActive(true);
                    sublevel.transform.position = topMenuItem.transform.position;
                    sublevel.transform.rotation = topMenuItem.transform.rotation;
                }
                else
                {
                    // Return if it is instantiated
                    if (isInstantiated) return;

                    // Otherwise spawn and wait
                    StartCoroutine(waiter());

                }
            }
        }
    }


    IEnumerator waiter()
    {
        // Go onto cooldown
        isInstantiated = true;

        // Spawn the object
        var itemsPos = menuItemTouched.transform.position;
        var itemsRot = menuItemTouched.transform.rotation;
        var itemsSca = menuItemTouched.transform.localScale;
        GameObject spawned = Instantiate(itemToSpawn);
        spawned.transform.rotation = itemsRot;
        spawned.transform.localScale = itemsSca;
        var zpos = itemsPos.z - (0.1f);
        spawned.transform.position = new Vector3(itemsPos.x, itemsPos.y, zpos);

        //Wait for 4 seconds
        yield return new WaitForSeconds(4);

        // Set instantiated
        isInstantiated = false;
    }
}





