using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uniqueIDGenerator : MonoBehaviour
{
    private static int uniqueID = 0;

    public static int GetID()
    {
        return uniqueID;
    }

    public static void SetID()
    {
        uniqueID++;
    }
}



