using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    // Start is called before the first frame update

    bool stopChecking = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if( gameObject.transform.childCount <= 0 && stopChecking)
        {
            Debug.Log(gameObject.transform.childCount);
            FindObjectOfType<QuestsManager>().DisplayNoEnemyText();
            stopChecking = false;
        }
    }
}
