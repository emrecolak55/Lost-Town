using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTrigger : MonoBehaviour
{
    Animator parentAnimator;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Knight>())
        {
            parentAnimator.SetBool("Attack", true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //StartCoroutine(ExitAttackAnimation());

        parentAnimator.SetBool("Attack", false);
    }

    private void Start()
    {
        parentAnimator = GetComponentInParent<Animator>();
    }
}
