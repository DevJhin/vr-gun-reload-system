using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGReload : MonoBehaviour
{
    public static int state = 0;
    // State 0: nothing
    // State 1: Mag Detach
    // State 2: Mag Detached
    // State 3: Mag Attached
    // State 4: bolt Pulling
    // State 5: bolt Pulled
    [SerializeField] GameObject magPrefab;
    [SerializeField] GameObject magAttached;
    [SerializeField] GameObject magNew;



    MeshRenderer magAttached_Mesh;
    Vector3 magAttached_initialPos;
    Vector3 magAttached_initialAng;

    Vector3 bolt_initialPos;
    Vector3 bolt_movedPos;

    public bool gripped;
    [SerializeField] VRInputManager input;
    [SerializeField] AudioSource[] reloadSound;

    [SerializeField] SubMachineGun smg;

    void Start()
    {
        magAttached_Mesh = magAttached.GetComponent<MeshRenderer>();
        magAttached_initialPos = magAttached.transform.position;
        magAttached_initialAng = magAttached.transform.eulerAngles;

    }

    private void OnTriggerExit(Collider other)
    {
        if (string.Equals(other.tag, "Trigger_1"))
        {
            if (!input.Gripping())
            {
                if (state == 1)
                {
                    state = 0;
                }
            }
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (string.Equals(other.tag, "Trigger_1"))
        {
            if (input.Gripping())
            {
                if (state == 0)
                {
                    state = 1;
                }
           
            }
            else
            {
                if (state == 1)
                {
                    state = 0;
                }
            }

        }
        else if (string.Equals(other.tag, "Trigger_3"))
        {
            if (input.Gripping())
            {
                if (state == 3)
                {
                    state = 4;
                }
            }
            else
            {
                if (state == 4)
                {
                    state = 3;
                }
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.tag, "Trigger_1"))
        {
            if (input.Gripping())
            {
                if (state == 0)
                {
                    state = 1;
                }
              

            }
        }
        else if (string.Equals(other.tag, "Trigger_2"))
        {
            if (state == 1)
            {
                state = 2;
                magAttached_Mesh.enabled = false;
                magNew.SetActive(true);
                SubMachineGun.fireEnabled = false;
                reloadSound[0].Play();
                smg.currentBullet = 0;
                GameObject magTemp = Instantiate(magPrefab) as GameObject;
                magTemp.transform.position = magAttached_initialPos;
                magTemp.transform.eulerAngles = magAttached_initialAng;
                Destroy(magTemp, 2);
            }


        }
        else if (string.Equals(other.tag, "Trigger_3"))
        {
            if (input.Gripping())
            {
                if (state == 3)
                {
                    state = 4;
                }

            }
        }
        else if (string.Equals(other.tag, "Trigger_4"))
        {
            if (input.Gripping())
            {
                if (state == 4)
                {
                    state = 5;
                    reloadSound[2].Play();
                    SubMachineGun.fireEnabled = true;
                    state = 0;
                }

            }
        }
    }

   public void MagAttachedAction()
    {
        magAttached_Mesh.enabled = true;
        magNew.SetActive(false);
        SubMachineGun.fireEnabled = false;
        reloadSound[1].Play();
        smg.currentBullet = smg.maxBullet;
    }
}
