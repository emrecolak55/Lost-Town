using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmith : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<QuestsManager>().BlackSmithFirstText();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
