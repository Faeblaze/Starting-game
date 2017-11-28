using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    Transform turretTransform;
    float range = 10f;
    public GameObject bulletPrefab;
    float fireCooldown = 0.5f;
    float fireCooldownLeft = 0;
    public enemy enemy;

    // Use this for initialization
    void Start() {
        turretTransform = transform.Find("Turret");
    }

    // Update is called once per frame
    void Update() {
        enemy[] enemies = GameObject.FindObjectsOfType<enemy>();

        enemy nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach (enemy e in enemies) {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if (nearestEnemy == null || d < dist) {
                nearestEnemy = e;
                dist = d;
            }
        }
        if (nearestEnemy == null) {
            Debug.Log("No enemies?");
            return;
        }

        Vector3 dir = nearestEnemy.transform.position - this.transform.position;

        Quaternion lookRot = Quaternion.LookRotation(dir);

        turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

        fireCooldownLeft -= Time.deltaTime;
        if (fireCooldownLeft <= 0 && dir.magnitude <= range) {
            fireCooldownLeft = fireCooldown;
            ShootAt(nearestEnemy);
        }
    }
    void ShootAt(enemy e)
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position, this.transform.rotation);

        Bullet b = bulletGO.GetComponent<Bullet>();
        b.target = e.transform;
    }
}
