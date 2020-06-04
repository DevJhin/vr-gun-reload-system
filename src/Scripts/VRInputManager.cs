using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class VRInputManager : MonoBehaviour {


    public SteamVR_Input_Sources handType;

    public SteamVR_Action_Boolean reload;
    public SteamVR_Action_Boolean fire;
    public SteamVR_Action_Boolean weaponChangeForward;
    public SteamVR_Action_Boolean weaponChangeBackward;
    public SteamVR_Action_Boolean drag;
    public SteamVR_Action_Boolean teleport;
    public SteamVR_Action_Boolean grip;

    private void OnEnable()
    {
        SteamVR.Initialize();
    }
    public bool FireTriggered()
    {
        return fire.GetStateDown(handType);
    }
    public bool Firing()
    {
        return fire.GetState(handType);
    }
    public bool ReloadTriggered()
    {
        return reload.GetStateDown(handType);
    }
    public bool Gripping()
    {
        return grip.GetState(handType);
    }
    public bool WeaponChangeForwardTriggered()
    {
        return weaponChangeForward.GetStateDown(handType);
    }
    public bool WeaponChangeBackwardTriggered()
    {
        return weaponChangeBackward.GetStateDown(handType);
    }
    public bool DragTriggered()
    {
        return drag.GetStateDown(handType);
    }
}
