using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeDoor : MonoBehaviour
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
    private void LoadTownCenter()
    {
        SceneManager.LoadScene("Level 4");
    }

    private void Update()
    {
        if (checkForPress && Input.GetKeyDown(KeyCode.Q)){
            LoadTownCenter();
        }
    }
}
