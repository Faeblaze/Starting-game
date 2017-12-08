using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    // enemy movements and naming
    GameObject pathGO;
    Transform targetPathNode;
    int pathNodeIndex = 0;
    float speed = 12f;
    public float health = 2f;
    public int moneyValue = 1;  
    public ScoreManager scoreManager;
    public bool reachedLastNode = false;

    // Use this for initialization
    void Start()
    {
        pathGO = GameObject.Find("Path");
    }
    //Specify method to follow path
    void GetNextPathNode()
    {
        if (pathNodeIndex < pathGO.transform.childCount)
        {
            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        else
        {
            targetPathNode = null;
        }
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
                return;
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
        scoreManager.LoseLife();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LastNode"))
        {
            reachedLastNode = true;
        }

    }


}