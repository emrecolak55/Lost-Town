using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject mapCanvas;
    bool lookForKeyPress = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueBox.SetActive(true);
        lookForKeyPress = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
        lookForKeyPress = false;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && lookForKeyPress)
        {
            mapCanvas.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mapCanvas.SetActive(false);
            dialogueBox.SetActive(false); // ienumerator later
        }
    }
}
