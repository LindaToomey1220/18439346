using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionMenu : MonoBehaviour
{
    public GameObject parentPosition;
    public GameObject childPosition;
    private float spacingZ = 0.05f;
    void Update()
    {
        var parPos = parentPosition.transform.position;
        childPosition.transform.position = parentPosition.transform.position + parentPosition.transform.forward * spacingZ;
        childPosition.transform.rotation = parentPosition.transform.rotation;
        var childPos = childPosition.transform.position;
        childPosition.transform.position = new Vector3(parPos.x, parPos.y, childPos.z);
    }
}
