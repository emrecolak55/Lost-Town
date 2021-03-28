using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadForest()
    {
        SceneManager.LoadScene("Level 5"); // FOREST
    }
    public void LoadSea()
    {
        SceneManager.LoadScene("Sea Level"); // 
    }
    public void LoadInCastle()
    {
        SceneManager.LoadScene("Level 6"); // enemy castle
    }
}
