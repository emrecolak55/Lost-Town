using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    [SerializeField] GameObject heart;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        heart.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(CloseHeart());
    }
    IEnumerator CloseHeart()
    {
        yield return new WaitForSeconds(2f);
        heart.SetActive(false);

    }
}
