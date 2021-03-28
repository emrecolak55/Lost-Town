using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaParent : MonoBehaviour
{
    Transform target;
    void Start()
    {
        GameObject foundKnight = GameObject.Find("Knight");
        target = foundKnight.transform;
    }

    // Update is called once per frame
    void Update()
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
}
