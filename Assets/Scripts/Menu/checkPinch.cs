using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPinch : MonoBehaviour
{
    public bool topLevelItem;
    public GameObject itemToSpawn;
    public GameObject parent;
    public GameObject topLevelMenu;
    public GameObject sublevel;

    private OVRHand m_hand;
    private float pinchThreshold = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        System.Console.WriteLine("Found hand");
        m_hand = GetComponent<OVRHand>();
        System.Console.WriteLine("Found hand");
    }

    // Update is called once per frame
    void Update()
    {
        CheckIndexPinch(); 
    }

    void CheckIndexPinch()
    {
        GrabBegin();
        
    }

    void GrabBegin()
    {
        float pinchStrength = m_hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);

        if (pinchStrength > pinchThreshold && !topLevelItem)
        {
            System.Console.WriteLine(" not a top menu item");
            Instantiate(itemToSpawn, parent.transform);
            System.Console.WriteLine("object instantiated");
        }
        else if (pinchStrength > pinchThreshold && topLevelItem)
        {
            System.Console.WriteLine(" top menu item");
            topLevelMenu.SetActive(false);
            sublevel.SetActive(true);
        }
    }
}
