using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	Transform turretTransform;

	// Use this for initialization
	void Start () {
		turretTransform = transform.Find ("Turret");
	}
	
	// Update is called once per frame
	void Update () {
		Enemy[] enemies = GameObject.FindObjectOfType<Enemy> ();

		Enemy nearestEnemy = null
			float dist = Mathf.Infinity;

		foreach(Enemy e in enemies){
			float d = Vector3.Distance(this.transform.position, e.transform.position);
			if(nearestEnemy == null || d < dist) {
				nearestEnemy = e;
				dist = d;
	}
}
		if(nearestEnemy == nulll) {
			Debug.Log("No enemies?");
			return;
		}
	}

	Vector3 dir = nearestEnemy.transform.position - this.trnsform.position;

	Quaternion lookRot = Quaternion.LookRotation( CapsuleDirection2D );

	turretTransform.rotation = Quaternion.Euler(0, LookRot.eulerAngles.y, 0 );
}
}