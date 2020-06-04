using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public VRInputManager leftController;
    public VRInputManager rightController;
    

    [Header ("SubMachineGun")]
    public GameObject VectorObject;
    public GameObject VectorGripObject;
    public GameObject VectorMagObject;

    [Header("AssaultRifle")]
    public GameObject AKMObject;
    public GameObject AKMGripObject;
    public GameObject AKMMagObject;

    [Header("SniperRifle")]
    public GameObject Kar98kObject;
    public GameObject Kar98kGripObject;
    public GameObject Kar98kMagObject;

    public enum WeaponState {Minimum=-1,Empty=0, HandGun=1, SMG=2, AR=3, Sniper=4,Maximum=5};
    public WeaponState weaponState;
    public void Update()
    {
      
        if (leftController.WeaponChangeForwardTriggered() || rightController.WeaponChangeForwardTriggered()) {
            weaponState += 1;
            if (weaponState == WeaponState.Maximum) {
                weaponState = WeaponState.Empty;
            }
            WeaponChange();
        }
        else if (leftController.WeaponChangeBackwardTriggered() || rightController.WeaponChangeBackwardTriggered())
        {
            weaponState -= 1;
            if (weaponState == WeaponState.Minimum)
            {
                weaponState = WeaponState.Sniper;
            }
            WeaponChange();
        }
    }
    public void SetKar98k(bool value ) {
        Kar98kObject.SetActive(value);
        Kar98kGripObject.SetActive(value);
        Kar98kMagObject.SetActive(value);
    }

    public void SetVector(bool value)
    {
        VectorObject.SetActive(value);
        VectorGripObject.SetActive(value);
        VectorMagObject.SetActive(value);
    }

    public void SetAKM(bool value)
    {
        AKMObject.SetActive(value);
        AKMGripObject.SetActive(value);
        AKMMagObject.SetActive(value);
    }

    public void WeaponChange() {
        switch (weaponState) {
            case WeaponState.Empty:
                {
                    SetAKM(false);
                    SetKar98k(false);
                    SetVector(false);
                    break;
                }
            case WeaponState.HandGun:
                {
                    SetAKM(false);
                    SetKar98k(false);
                    SetVector(false);
                    break;
                }
            case WeaponState.SMG:
                {
                    SetAKM(false);
                    SetKar98k(false);
                    SetVector(true);
                    break;
                }
            case WeaponState.AR:
                {
                    SetAKM(true);
                    SetKar98k(false);
                    SetVector(false);
                    break;
                }
            case WeaponState.Sniper:
                {
                    SetAKM(false);
                    SetKar98k(true);
                    SetVector(false);
                    break;
                }
        }
    }

    
}
