using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

    Transform turretTransform;

	// Use this for initialization
	void Start () {
        turretTransform = transform.Find("Barrel");
	}
	
	// Update is called once per frame
	void Update () {
        enemy[] enemies = GameObject.FindObjectsOfType<enemy>();
	}
}
