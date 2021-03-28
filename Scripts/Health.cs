using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int health = 100;
    [SerializeField] float deathDelayForAnimation = 3f;
    Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    public void DecreaseHealth(int givenDamage)
    {
        health -= givenDamage;
        if( health <= 0)
        {
            StartCoroutine(Death());
        }
    }
    IEnumerator Death()
    {
        myAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(deathDelayForAnimation);
        Destroy(gameObject);
    }

    public int ReturnHealth()
    {
        return health;
    }
}
