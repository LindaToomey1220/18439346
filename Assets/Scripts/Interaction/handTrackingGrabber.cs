using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
public class handTrackingGrabber : OVRGrabber
{
    private OVRHand hand;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand>();

    }

    public override void Update()
    {
        base.Update();
        CheckIndexPinch();
    }

    void CheckIndexPinch()
    {
        bool pinchStrength = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        if(!m_grabbedObj && pinchStrength && m_grabCandidates.Count>0)
        {
            GrabBegin();
        }
        else if(m_grabbedObj && !pinchStrength)
        {
            GrabEnd();
        }
    }
}
