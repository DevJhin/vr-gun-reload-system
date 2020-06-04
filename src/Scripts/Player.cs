using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {
  
   [SerializeField] private float HP=100;
    private void Start()
    {
        Vector3 startPos = transform.position;
        startPos.y = 0;
        transform.position = startPos;
    }
}
