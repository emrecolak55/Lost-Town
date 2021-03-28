using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    Animator myAnimator;

    Transform target;
    bool isEnemyClose = false;
    [SerializeField] float speed = 1f;
    [SerializeField] float howCloseToEnemy = 2f;

    bool isAttacking = false;
    
    private void Start()
    {
        myAnimator = GetComponent<Animator>();

        
        

    }
    private void Update()
    {
        GameObject foundKnight = GameObject.Find("Knight");
        target = foundKnight.transform;
        if (isEnemyClose)
        {
            RunToEnemy();
        }
        FlipToEnemy();


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Knight>())
        {
            isEnemyClose = true;
        }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isEnemyClose = false;
        myAnimator.SetBool("Run", false);
    }
    
    private void FlipToEnemy()
    {
        var distanceToEnemy = target.transform.position.x - transform.position.x;
        if( distanceToEnemy > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }
    private void RunToEnemy()
    {
        //isAttacking = false;
        myAnimator.SetBool("Run", true);
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if( Mathf.Abs(target.transform.position.x - transform.position.x) <= howCloseToEnemy)
        {
            myAnimator.SetBool("Run", false);
            isEnemyClose = false;
            
        }
        
    }
    public void Attack() // Called by child ?? // public or private
    {
        myAnimator.SetTrigger("Attack");
    }
}
