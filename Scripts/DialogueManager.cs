using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject dialogueBox;
    [SerializeField] float waitBeforeDisableBox = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartDialogue() // King collider trigger activates
    {
        ActivateBox();

    }
    private void ActivateBox()
    {
        dialogueBox.SetActive(true);
        EndDialogue();
    }
    private void EndDialogue()
    {
        StartCoroutine(DisableBox());
    }

    IEnumerator DisableBox()
    {
        yield return new WaitForSeconds(waitBeforeDisableBox);
        dialogueBox.SetActive(false);
    }
}
