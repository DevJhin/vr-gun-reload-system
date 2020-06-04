using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltActionReload : MonoBehaviour
{
    private int state = 0;
    [SerializeField] Transform bolt;
    [SerializeField] Transform knob;
    [SerializeField] Transform shellStartPos;
    [SerializeField] VRInputManager input;
    [SerializeField] GameObject shell;

    [SerializeField] AudioSource[] reloadSound;

    Vector3 bolt_initialAngle = new Vector3(-85,90,-90);
    Vector3 bolt_turnedAngle = new Vector3(-20, 90, -90);

    Vector3 bolt_initialPos = new Vector3(0, 0.08f, 0.0122f);
    Vector3 bolt_movedPos = new Vector3(0, 0.08f, 0.06f);

    Vector3 knob_initialPos = new Vector3(0, 0.0837f, 0.259f);
    Vector3 knob_movedPos = new Vector3(0, 0.0837f, 0.3068f);

    void Start()
    {
        
    }

    //State 0: staying at 1
    //State 1; going to 2
    //State 2; staying at 2
    //State 3; going to 3
    //State 4; staying at 3 

    //State 5; going to 2 again
    //State 6; staying at 2 again
    //State 7; going to 1 again

    //Now Repeats this 

  
    public void SetState(int val)
    {
        state = val;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (input.Gripping())
        {
            if (string.Equals(other.tag, "Trigger_1"))
            {

                if (state == 7)
                {
                    //grabPoint.enabled = false;
                    BoltActionRifle.fireEnabled = true;

                    bolt.localEulerAngles=bolt_initialAngle;
                    SetState(0);
                    Debug.Log("Down Success");
                    reloadSound[3].Play();
                    
                    this.enabled = false;
                }
            }
            else if (string.Equals(other.tag, "Trigger_2"))
            {
                if (state == 1)
                {
                    SetState(2);
                    bolt.transform.localEulerAngles = bolt_turnedAngle;
                    reloadSound[0].Play();
                    Debug.Log("Up Success");
                }
                else if (state == 5)
                {
                    SetState(6);
                    bolt.localPosition = bolt_initialPos;
                    knob.localPosition = knob_initialPos;
                    reloadSound[2].Play();
                    Debug.Log("Push Success");
                }
            }
            else if (string.Equals(other.tag, "Trigger_3"))
            {
                if (state == 3)
                {
                    SetState(4);
                    bolt.localPosition = bolt_movedPos;
                    knob.localPosition = knob_movedPos;
                    reloadSound[1].Play();
                    if (BoltActionRifle.isShellExist)
                    {
                        BoltActionRifle.isShellExist = false;
                        GameObject shellTemp = Instantiate(shell) as GameObject;
                        shellTemp.transform.position = shellStartPos.position;
                    }
                    Debug.Log("Pull Success");
                }
            }
        }
    }
  
    private void OnTriggerExit(Collider other)
    {
        if (input.Gripping())
        {
 
            if (string.Equals(other.tag, "ReloadPath_1"))
            {
                if (state == 1)
                {
                    SetState(0);
                }
                else if (state == 7)
                {
                    SetState(6);
                }
            }
            else if (string.Equals(other.tag, "ReloadPath_2"))
            {
                if (state == 3)
                {
                    SetState(2);
                }
                else if (state == 5)
                {
                    SetState(4);
                }
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (!input.Gripping())
        {
            if (string.Equals(other.tag, "ReloadPath_1"))
            {

                if (state == 1)
                {
                    SetState(0);
                }
               
                else if (state == 7)
                {
                    SetState(6);
                }
            }
            else if (string.Equals(other.tag, "ReloadPath_2"))
            {
                if (state == 3)
                {
                    SetState(2);
                }
                else if (state == 5)
                {
                    SetState(4);
                }
            }
        }
        else
        {
            if (string.Equals(other.tag, "Trigger_1"))
            {
                if (state == 0)
                {
                    SetState(1);
                }


            }
            else if (string.Equals(other.tag, "Trigger_2"))
            {
                if (state == 2)
                {
                    SetState(3);
                }
                else if (state == 6)
                {
                    SetState(7);
                }
            }
            else if (string.Equals(other.tag, "Trigger_3"))
            {
                if (state == 4)
                {
                    SetState(5);
                }

            }
        }
    }
}

