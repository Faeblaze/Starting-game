using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int lives = 20;
    public int money = 100;
    public Text moneyText;
    public Text livesText;

    public void LoseLife(int l = 1)
    {
        lives -= 1;
        if (lives<= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(0);
    }
     void Update()
    {
        moneyText.text = money.ToString();
        livesText.text = lives.ToString();
    }
}
