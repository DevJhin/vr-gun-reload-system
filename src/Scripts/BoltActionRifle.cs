using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltActionRifle : MonoBehaviour
{

    private bool isReloaded;
    [SerializeField]LayerMask layer;
    //[SerializeField] BoltActionReload reloadAction;
    int currentBullet = 0;
    [SerializeField] private float damage;
    float pierceLevel = 0.6f;

    public static bool isGripOn = false;
    public static bool isTriggerOn = false;
    public static bool isShellExist = false;
    [SerializeField] Transform bulletStartPos;
    [SerializeField]public static bool fireEnabled = true;
    [SerializeField] List<GameObject> hitEffects;
    [SerializeField] GameObject muzzleFireEffect;

    [SerializeField] AudioSource fireSound;
    [SerializeField] BulletType bulletType;
    public VRInputManager VRInput;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (fireEnabled)
        {
            if (VRInput.FireTriggered())
            {
                fireEnabled = false;
                
                fireSound.Play();

                RaycastHit hit;

                if (Physics.Raycast(bulletStartPos.position, bulletStartPos.forward, out hit, 10000,layer))
                {
                    isShellExist = true;
                    Debug.Log(hit.transform.name);

                    GameObject hitEffectTemp = Instantiate(hitEffects[0]) as GameObject;

                    hitEffectTemp.transform.position = hit.point;
                    hitEffectTemp.transform.rotation = Quaternion.FromToRotation(hitEffectTemp.transform.forward, hit.normal) * hitEffectTemp.transform.rotation;
                    Destroy(hitEffectTemp, 2.5f);

                    if (hit.transform.gameObject.layer == 12)
                    {
                        Debug.Log("Attack!");
                        hit.transform.GetComponent<EnemyCollisionSystem>().ApplyDamage(damage, bulletType);

                    }


                }
                else
                {
                  
                }


            }
        }

      
    }


}


    
