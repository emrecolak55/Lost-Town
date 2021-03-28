using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Key : MonoBehaviour
{
    [SerializeField] AudioSource myAudioSource;
    [SerializeField] GameObject keyText;
    bool checkForKeyPress = false;
    [SerializeField] AudioClip victoryClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        keyText.SetActive(true);
        checkForKeyPress = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        keyText.SetActive(false);
        checkForKeyPress = false;
    }
    
    private void Update()
    {
        if(checkForKeyPress)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //SceneManager.LoadScene("Level 4"); // for now
                FindObjectOfType<QuestsManager>().DisplayVictoryText();
                myAudioSource.Stop();
                AudioSource.PlayClipAtPoint(victoryClip, Camera.main.transform.position);
            }
        }
    }
}
