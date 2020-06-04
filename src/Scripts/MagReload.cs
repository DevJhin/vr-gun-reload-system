using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagReload : MonoBehaviour {

   [SerializeField] SMGReload smgReload;
    private void OnTriggerEnter(Collider other)
    {
        if(string.Equals(other.tag, "Mag")){
            if (SMGReload.state == 2)
            {
                SMGReload.state = 3;
                smgReload.MagAttachedAction();
               
            }

           
        }
    }
}
