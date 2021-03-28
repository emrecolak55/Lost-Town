using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyDoor : MonoBehaviour
{
    [SerializeField] GameObject doorText;
    bool checkForPress = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        doorText.SetActive(true);
        checkForPress = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        doorText.SetActive(false);
        checkForPress = false;
    }
    private void LoadSiegeTown()
    {
        SceneManager.LoadScene("TownSiege");
    }

    private void Update()
    {
        if (checkForPress && Input.GetKeyDown(KeyCode.Q))
        {
            LoadSiegeTown();
        }
    }
}
