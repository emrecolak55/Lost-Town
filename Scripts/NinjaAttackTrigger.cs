using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAttackTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attack();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<Animator>().SetBool("Attack", false);
    }


    private void Attack()
    {
        GetComponentInParent<Animator>().SetBool("Attack",true);
    }
    IEnumerator AttackAnim()
    {
        yield return new WaitForSeconds(1f);
        GetComponentInParent<Animator>().SetTrigger("Attack");
    }
}
