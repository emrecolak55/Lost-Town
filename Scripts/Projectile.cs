using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float xSpeed = 2f;
    Rigidbody2D myRigidBody;
    [SerializeField] int damage = 20;
    Transform target;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            FindObjectOfType<GameSession>().DecreaseHealth(damage);
        }
        
        Destroy(gameObject);
    }
    void Start()
    {
        GameObject foundKnight = GameObject.Find("Knight");
        target = foundKnight.transform;
        if( target.transform.position.x > transform.position.x)
        {
            xSpeed = xSpeed * (-1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(-(Time.deltaTime * xSpeed), 0 , 0);
        transform.position += new Vector3(-(Time.deltaTime * xSpeed), 0, 0);
    }
}
