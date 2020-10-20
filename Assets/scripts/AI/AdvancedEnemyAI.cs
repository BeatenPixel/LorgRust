using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AdvancedEnemyAI : MonoBehaviour {
    public int health = 100;
    public float viewRange = 25f;
    public float attackRange = 5f;

    public bool isChasing = false;

    private NavMeshAgent agent;
    private Transform playerTransform;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hitInfo;

        CheckHealth();

        if (Physics.Raycast(ray, out hitInfo, viewRange)) {

            if (hitInfo.collider.tag == "Player") {
                if (isChasing == false) {
                    isChasing = true;
                    playerTransform = hitInfo.collider.GetComponent<Transform>();
                }
            }

        }

        if (Physics.Raycast(ray, out hitInfo, attackRange)) {

        }

        Debug.DrawRay(ray.origin, ray.direction * viewRange);

        if (isChasing == true) {
            agent.SetDestination(playerTransform.position);
        }

    }

    public void TakeDamage(int damage) {

        health -= damage;
        Debug.Log("Enemy took damage and now has" + health + " health!");
    }
    private void CheckHealth() {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}