using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip ( "Game Units Per Second")]
    [SerializeField] float scrollRate = 0.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yMove = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMove));
    }
}
