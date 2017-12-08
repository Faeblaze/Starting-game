using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour {

	public ScoreManager sm;

	// 
	void OnMouseUp()
    { 
        Debug.Log("TowerSpot clicked.");
		if (sm.money >= 30) 
		{
			sm.money -= 30;
			BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
			if (bm.selectedTower != null)
			{
				Instantiate(bm.selectedTower, transform.parent.position, transform.parent.rotation);
				Destroy(transform.parent.gameObject);

			}

		}
		          

    }

}
