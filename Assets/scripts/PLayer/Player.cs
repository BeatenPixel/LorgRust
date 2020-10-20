using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

   public GameObject deathCanvas;
   
    public Vector3 spawnPoint = Vector3.zero;
    public float health = 100;

    private void Update () 
        {
            CheckDeath();
        }

    private void Start() 
        {
        deathCanvas.SetActive(false);
    }

    private void CheckDeath() 
    {
        if (health <= 0)
        {
            Die();
        }

    }
    private void Die() {
        deathCanvas.SetActive(true);
    } 
    
    public void Respawn() {
        deathCanvas.SetActive(false);
        transform.position = spawnPoint;
        health = 100;
    }
    
   
}
