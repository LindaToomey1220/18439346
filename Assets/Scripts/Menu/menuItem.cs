using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuItem : MonoBehaviour
{
    private GameObject parent = null;
    public bool isTopLayer = true;
    public GameObject objectToSpawn;
    public string findObject;

    void Awake()
    {
        parent = gameObject.transform.parent.gameObject;
        Debug.Log("Pinching Something");
    }
}

