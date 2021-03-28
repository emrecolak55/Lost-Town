using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] int damage = 100;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.GetComponent<Health>())
        {
            other.gameObject.GetComponent<Health>().DecreaseHealth(damage);
        }
    }
}
