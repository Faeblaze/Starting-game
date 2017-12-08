using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public Transform GearTransform;
    float range = 18f;
    public GameObject bulletPrefab;
    float fireCooldown = 0.6f;
    float fireCooldownLeft = 0;
    public enemy enemy;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        // Find the point between this transform and the enemies position.
        Vector3 dir = nearestEnemy.transform.position - GearTransform.position;

        // Determine the look rotation by the distance/ rotation value of the distance "dir" variable
        Quaternion lookRot = Quaternion.LookRotation(dir);


        //This transform is to aim at the enemy.
       GearTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

        fireCooldownLeft -= Time.deltaTime;
        if (fireCooldownLeft <= 0 && dir.magnitude <= range)
        {
            fireCooldownLeft = fireCooldown;
            ShootAt(nearestEnemy);
        }
    }
    void ShootAt(enemy e)
    {
        GameObject bulletGO = Instantiate(bulletPrefab, GearTransform.transform.position - new Vector3(0,1.5f,0), GearTransform.transform.rotation);
        Bullet b = bulletGO.GetComponent<Bullet>();
        b.target = e.transform;
    }
}
