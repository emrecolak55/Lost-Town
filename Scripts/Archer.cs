using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float animationExitTime = 2f;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject objectReleasePoint;
    [SerializeField] float projectileSpeed = 2f;
    [SerializeField] AudioClip myClip;
    Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject foundKnight = GameObject.Find("Knight");
        target = foundKnight.transform;
        FlipToEnemy();
    }
    private void FlipToEnemy()
    {
        var distanceToEnemy = target.transform.position.x - transform.position.x;
        if (distanceToEnemy > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }
    private void CheckHealth()
    {
        //
    }
    public void ReleaseArrow() // Called in animation
    {
       GameObject projectile = Instantiate(arrow, objectReleasePoint.transform) as GameObject;
        AudioSource.PlayClipAtPoint(myClip, Camera.main.transform.position);
       
       /// projectile.Rigid = new Vector2(projectileSpeed, 0f);
    }
}
