using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameSession : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] int lives = 3;
    [SerializeField] int score = 0;
    [SerializeField] int health;
    //[SerializeField] Text livesText;
    ///[SerializeField] Text scoreText;
    [SerializeField] Text healthText;
    private void Awake()
    {
        int numGameSes = FindObjectsOfType<GameSession>().Length;
        if( numGameSes > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
      //  livesText.text = lives.ToString();
       // scoreText.text = score.ToString();
        
    }
    
    public void SetHealth(int givenHealth)
    {
        health = givenHealth;
        healthText.text = health.ToString();
    }
    public void AddToScore(int givenScore)
    {
        score += givenScore;
        //scoreText.text = score.ToString();
    }
    // Update is called once per frame
    public void DecreaseHealth(int givenDamage)
    {
        FindObjectOfType<Knight>().DecreaseHealth(givenDamage);
        
    }
    public void PlayerDeath()
    {
        if(lives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }
    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    private void TakeLife()
    {
        lives--;
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
        //livesText.text = lives.ToString();
    }
}
