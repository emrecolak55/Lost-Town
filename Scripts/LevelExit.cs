using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    [SerializeField] float slowMotionValue = 0.1f;

    Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        myAnimator.SetTrigger("OpenDoor");
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = slowMotionValue;
        yield return new WaitForSecondsRealtime(loadDelay);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
}
