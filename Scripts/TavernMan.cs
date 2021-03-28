using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TavernMan : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float randomFactor = 2f;

    [SerializeField] GameObject tavernEnteringBox;
    Animator myAnimator;
    private void OnTriggerStay2D(Collider2D collision)
    {
        tavernEnteringBox.SetActive(true);
       
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("SDA");
                SceneManager.LoadScene("Tavern");
            }
        
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tavernEnteringBox.SetActive(false); // Add IEnumerator
    }
    void Start()
    {
        myAnimator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(WalkAnimation());
    }

    


    IEnumerator WalkAnimation()
    {
        yield return new WaitForSeconds(randomFactor);
        TriggerAnimation();
    }
    private void TriggerAnimation()
    {
        myAnimator.SetBool("Walk", true);
        StartCoroutine(ExitAnimation());
    }
    IEnumerator ExitAnimation()
    {
        yield return new WaitForSeconds(randomFactor);
        ExitWalk();
    }
    private void ExitWalk()
    {
        myAnimator.SetBool("Walk", false);
    }
}
