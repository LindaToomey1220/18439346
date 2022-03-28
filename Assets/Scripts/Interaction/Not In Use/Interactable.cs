using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool isAvailable = true;

    public bool GetAvailability()
    {
        return isAvailable;
    }
}
