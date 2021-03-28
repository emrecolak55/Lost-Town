using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //FindObjectOfType<DialogueManager>().StartDialogue();
        FindObjectOfType<QuestsManager>().KingFirstText();
    }
    
}
