using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueStarter : MonoBehaviour
{
    // Start is called before the first frame update
    bool checkForKey = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<DialogueManager>().StartDialogue();
        checkForKey = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        checkForKey = false;
    }
    private void Update()
    {
        if( checkForKey && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<SceneLoader>().LoadInCastle();
        }
    }


}
