using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.MasterAudio;
public class Enemy : MonoBehaviour {

    [SerializeField] private float HP;
    [SerializeField] private float waitTime;
    [SerializeField] private float spawnTime;
    [SerializeField] private float score;

    [SerializeField] private Animator anim;

    [SerializeField] private SkinnedMeshRenderer mesh;

    [SerializeField] private GameObject VFX_Spawn;
    [SerializeField] private GameObject VFX_Attack;
    [SerializeField] private GameObject VFX_Death;

    [SerializeField] private Player player;

    [SerializeField] private Material spawnMat;
    [SerializeField] private Material standardMat;
    [SerializeField] private Material dieMat;

    [SerializeField] private SpawnEffect effectManager;
    [SerializeField] private MovementManager movementManager;
    [SerializeField] private DropItem dropItem;

    [SerializeField] private UIManager UIManager;

    [SerializeField] private LazerPointer lazer;

    [SerializeField] private Collider colliderList;
    public enum BulletType {Light, Heavy};
    public enum ArmorType {Light, Heavy};

    public bool isDied;

    private void Awake()
    {MasterAudio.FireCustomEvent("EnemySpawned", transform);
        Invoke("SpawnAction",spawnTime);
        Debug.Log("Awake");
    }
    private void Start()
    {
        
    }
    public void Update()
    {
        UIManager.UpdateEnemyUI(HP);
    }
    public void SpawnAction() {
        
        effectManager.enabled = false;
        movementManager.StartMovement(player.transform);
        mesh.material = standardMat;
        lazer.Initiate(waitTime,player.transform);
        anim.SetTrigger("SummonEndTrigger");
    }

    public void DeathAction() {
        movementManager.StopMovement();
        dropItem.enabled = true;
        MasterAudio.FireCustomEvent("EnemyDespawned", transform);
        anim.SetTrigger("DieTrigger");

        mesh.material = dieMat;
        effectManager.isDeath = true;
        effectManager.enabled = true;
        Destroy(gameObject,4);
    }
    public void DamageAction()
    {
    }
    public void ApplyDamage(float damage) {
        Debug.Log("Attacked!");
        if (!isDied)
        {
            float result = HP - damage;
            if (result > 0)
            {
                HP = result;
                DamageAction();
            }
            else if (result <= 0)
            {
                isDied = true;
                HP = 0;
                DeathAction();
                Debug.Log("Die!");
            }
        }
    }
}
