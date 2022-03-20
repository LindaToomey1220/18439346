using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

//A structure to store the position of the finger bones when
//doing a gesture.
public struct Gesture
{
    public string name; //Name of the pose
    public List<Vector3> fingerDatas; //Hold the position date of the pose
    public UnityEvent onRecognized;
   
}

public class GestureDetector : MonoBehaviour
{
    //Two variables to reference the hands finger data
    public OVRSkeleton skeleton;
    private List<OVRBone> fingerBones;

    public List<Gesture> gestures;
    public bool debugMode = true;
    private bool isButtonPressed = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //Populating the list with all the bones that can be accessed 
        //inside the OVR Skeleton Script
        fingerBones = new List<OVRBone>(skeleton.Bones);
    }

    // Update is called once per frame
    void Update() //Used to trigger the save function 
    {
        //If the CapsLock button gets pressed and debugMode is true, 
        //then save the gesture.
        isButtonPressed = Input.GetKeyDown(SpacebarKey());
        if(debugMode && isButtonPressed)
        {
            Debug.Log("a pressed");
            Save();
        }
    }

    public static KeyCode SpacebarKey()
    {
        if (Application.isEditor) return KeyCode.O;
        else return KeyCode.Space;
    }

    //Function to save new gestures
    void Save()
    {
        Gesture g = new Gesture(); //new gesture
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>(); //For data of fingers
        //Set the bones
        foreach (var bone in fingerBones)
        {
            //Compare position of the fingers according to the root of the hands
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerDatas = data;
        gestures.Add(g);
    }
}

