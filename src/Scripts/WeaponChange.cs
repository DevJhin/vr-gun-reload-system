using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] SMGReload smgReload;
    [SerializeField] GameObject smg_vector;

    [SerializeField] BoltActionReload baReload;
    [SerializeField] GameObject rifle_kar98k;

    [SerializeField] Animator[] handAnimator;

    [SerializeField] RuntimeAnimatorController[] rifleAnimator;
    [SerializeField] RuntimeAnimatorController[] smgAnimator;
    [SerializeField] RuntimeAnimatorController[] knifeAnimator;

 
    // Use this for initialization
    bool modeFlag;
    public bool menuPressed;
    int cnt = 0;
    // Update is called once per frame
    void Update()
    {
        if (menuPressed && modeFlag)
        {
            modeFlag = false;
            int index = ++cnt % 3;


            if (index == 1)
            {//Rifle 장착
                handAnimator[0].runtimeAnimatorController = rifleAnimator[0];
                handAnimator[1].runtimeAnimatorController = rifleAnimator[1];

                smgReload.enabled = false;
                smg_vector.SetActive(false);

                baReload.enabled = true;
                rifle_kar98k.SetActive(true);
            }
            else if(index == 0)
            {//SMG 장착
                handAnimator[0].runtimeAnimatorController = smgAnimator[0];
                handAnimator[1].runtimeAnimatorController = smgAnimator[1];

                smgReload.enabled = true;
                smg_vector.SetActive(true);

                baReload.enabled = false;
                rifle_kar98k.SetActive(false);

            }
        }
        else if (!menuPressed && !modeFlag)
        {
            modeFlag = true;
        }
    }
}


