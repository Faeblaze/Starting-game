using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int lives = 20;
    public int money = 100;
    public Text moneyText;
    public Text livesText;
    //public enemy enemyScript;
    bool loseLife = false;
    //references enemy script
    //boolean to check when it happens each instance
    public void LoseLife(int l = 1)
    {
        lives -= 1;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("MENU SCENE", LoadSceneMode.Single);
    }

    void Update()
    {
        moneyText.text = money.ToString();
        livesText.text = lives.ToString();
        
        //if (enemyScript != null && enemyScript.reachedLastNode == true)
        //{
        //    loseLife = true;
        //    if (loseLife == true)
        //    {
        //        lives -= 1;
        //        loseLife = false;
        //        enemyScript.reachedLastNode = false;
        //    }
            
        //}
        //if reachedLastNode in enemy script = true
        //loseLife = true
        //if loseLife = true, lose 1 life, then return loseLife to false again.

        if (lives <= 0)
        {
            GameOver();
        }

       
    }
}
