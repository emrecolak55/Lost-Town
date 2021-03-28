using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPositionOfPlayer();
    }
    private void GetPositionOfPlayer()
    {
        var playerTransform = FindObjectOfType<Knight>().GetPosition();
        gameObject.transform.position = new Vector3(playerTransform.x+0.5f, playerTransform.y+1.6f, 0);
    }
}
