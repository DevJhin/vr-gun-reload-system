using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAmimController : MonoBehaviour {
    [SerializeField] VRInputManager input;
    [SerializeField] Animator anim;
    // Update is called once per frame
    void Update () {
        if (input.Gripping())
        {
            anim.SetBool("isGripped",true);
        }
        else
        {
            anim.SetBool("isGripped", false);
        }

        if (input.Firing())
        {
            anim.SetBool("isTriggered", true);
        }
        else
        {
            anim.SetBool("isTriggered", false);
        }
    }
}
