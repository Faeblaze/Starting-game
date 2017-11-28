using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    // enemy movements and naming
    GameObject pathGO;
    Transform targetPathNode;
    int pathNodeIndex = 0;
    float speed = 5f;
    public float health = 1f;
    public int moneyValue = 1;

    // Use this for initialization
    void Start()
    {
        pathGO = GameObject.Find("Path");
    }
    //Specify method to follow path
    void GetNextPathNode()
    {
        targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
        pathNodeIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPathNode == null)
        {
            GetNextPathNode();
            if (targetPathNode == null)
            {
                //Run out of Path
                ReachedGoal();
            }
        }
        //moving the enemy to each child within the node-along path
        Vector3 dir = targetPathNode.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            // made it to the node
            targetPathNode = null;
        }
        else
        {
            //Moving toward Node-next
            transform.Translate(dir.normalized * distThisFrame, Space.World);
        }
    }
    void ReachedGoal()
    {
        GameObject.FindObjectOfType<ScoreManager>().LoseLife();
        Destroy(gameObject);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        GameObject.FindObjectOfType<ScoreManager>().money += moneyValue;
        Destroy(gameObject);
    }
}