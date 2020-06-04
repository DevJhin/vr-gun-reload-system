using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public enum BulletType { None, LightEffective, HeavyEffective };
public class SubMachineGun : MonoBehaviour {

   
    [SerializeField] SphereCollider grabPoint;
    //[SerializeField] SMGReload reloadAction;
    
     public VRInputManager input;
    [SerializeField] Transform bulletStartPos;
    [SerializeField] Transform shellOutPos;

    [SerializeField] BulletType bulletType;
    public float damage = 15;
    [SerializeField] public static bool fireEnabled = true;

    [SerializeField] List<GameObject> hitEffects;
    public enum MaterialType {Iron, ground,rock, wood,glass,  };


    [SerializeField] AudioSource fireSound;

    [SerializeField] ShellAnimationManager shellAnimationManager;

    [SerializeField] AudioSource[] fireSounds;

    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject muzzleFlashEffect;
    float delay = 0.05f;

    public float fireRate;
    public int currentBullet = 2500;
    public int maxBullet = 25;
    int cnt = 0;
    [SerializeField ]int burstCnt = 2;
    [SerializeField] bool semiFlag=true;
    float time = 0;
    float pierceLevel = 0.15f;

    // Use this for initialization
    void Start()
    {
        fireSounds = new AudioSource[25];
        for(int i = 0; i < 25; i++)
        {
            fireSounds[i] = Instantiate(fireSound) as AudioSource;
        }
    }
  

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= fireRate)
        {
            if (fireEnabled&&currentBullet>0)
            {

                    if (input.Firing())
                    {
                        FireProcess();
                    }        

            }else if (fireEnabled && currentBullet == 0)
            {
                fireEnabled = false;
            }

        }

    }

    private void FireProcess(){
        currentBullet--;
        time = 0;
        //fireEnabled = false;
        grabPoint.enabled = true;
        fireSounds[cnt++%25].Play();
        RaycastHit hit;

        if (Physics.Raycast(bulletStartPos.position, bulletStartPos.forward, out hit, 100,layerMask))
        {

            int effectIndex=0;
            if (string.Equals(hit.transform.tag, "Material_Dirt")) {
                effectIndex = 1;
            }
            else if (string.Equals(hit.transform.tag, "Material_Rock"))
            {
                effectIndex = 2;
            }
            GameObject hitEffectTemp = Instantiate(hitEffects[effectIndex]) as GameObject;
            hitEffectTemp.transform.position = hit.point;
            hitEffectTemp.transform.rotation = Quaternion.FromToRotation(hitEffectTemp.transform.forward, hit.normal) * hitEffectTemp.transform.rotation;
            Destroy(hitEffectTemp,2.5f);
           //shellAnimationManager.

            if (hit.transform.gameObject.layer==12)
            {
                Debug.Log("Attack!");
              hit.transform.GetComponent<EnemyCollisionSystem>().ApplyDamage(damage,bulletType);

            }

        }
        else
        {
           

        }
    }

 
}
