using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;


public class JetController : MonoBehaviour
{

    public SteamVR_Input_Sources leftHand; // 1
    public SteamVR_Input_Sources rightHand; // 1

    public SteamVR_Action_Single thrustAction; // 2

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(thrustAction.GetAxis(leftHand));
        
        
    }
}
