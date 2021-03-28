using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    [SerializeField] int swordDamage = 30;
    [SerializeField] AudioClip myClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Knight>())
        {
            FindObjectOfType<Knight>().DecreaseHealth(swordDamage);
            AudioSource.PlayClipAtPoint(myClip, Camera.main.transform.position);
        }
    }
}
