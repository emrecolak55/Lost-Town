using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuestsManager : MonoBehaviour
{
    [SerializeField] float waitForFirstQuest = 2f;
    
    [SerializeField] GameObject firstQuest;
    bool closingFirstQuest = false;

    [SerializeField] GameObject blackSmithFirstText;
    bool closingBlackSmithText = false;
    bool isItFirstTimeBlackSmith = true;

    [SerializeField] GameObject kingFirstQuest;
    bool closingKingText = false;
    bool isItFirstTimeKing = true;

    [SerializeField] GameObject siegeInfoText;
    bool closingSiegeText = false;
    bool isItFirstTimeSiege = true;

    [SerializeField] GameObject noEnemyLeftText;
    bool closingNoEnemyLeft = false;

    [SerializeField] GameObject victoryText;
    bool closingVictoryText = false;
    
    private void Awake()
    {
        int numGameSes = FindObjectsOfType<QuestsManager>().Length;
        if (numGameSes > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    IEnumerator Start()
    {
        closingFirstQuest = true;
        yield return new WaitForSeconds(waitForFirstQuest);
        ShowFirstQuest();
    }
    private void ShowFirstQuest()
    {
        firstQuest.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if( closingFirstQuest && Input.GetKeyDown(KeyCode.Escape))
        {
            firstQuest.SetActive(false);
            closingFirstQuest = false;
        }
        if( closingBlackSmithText && Input.GetKeyDown(KeyCode.Escape))
        {
            blackSmithFirstText.SetActive(false);
            closingBlackSmithText = false;
        }
        if (closingKingText && Input.GetKeyDown(KeyCode.Escape))
        {
            kingFirstQuest.SetActive(false);
            closingKingText = false;
        }
        

        var activeSceneIndex = SceneManager.GetActiveScene().name;
        if( activeSceneIndex == "TownSiege" && isItFirstTimeSiege)
        {
            SiegeInfoText();
            
        }
        if (closingSiegeText && Input.GetKeyDown(KeyCode.Escape))
        {
            siegeInfoText.SetActive(false);
            closingSiegeText = false;
        }
        if(closingNoEnemyLeft && Input.GetKeyDown(KeyCode.Escape))
        {
            noEnemyLeftText.SetActive(false);
        }
        

    }

    public void BlackSmithFirstText()
    {
        if(!isItFirstTimeBlackSmith) //
        {
            return;
        }
        blackSmithFirstText.SetActive(true);
        isItFirstTimeBlackSmith = false;
        closingBlackSmithText = true;
    }
    public void KingFirstText()
    {
        if (!isItFirstTimeKing) //
        {
            return;
        }
        kingFirstQuest.SetActive(true);
        isItFirstTimeKing = false;
        closingKingText = true;
    }
    public void SiegeInfoText() // maybe change to private
    {
        if (!isItFirstTimeSiege) //
        {
            return;
        }
        siegeInfoText.SetActive(true);
        closingSiegeText = true;
        isItFirstTimeSiege = false;
    }
 
    public void DisplayNoEnemyText()
    {
        noEnemyLeftText.SetActive(true);
        closingNoEnemyLeft = true;
    }
    public void DisplayVictoryText()
    {
        victoryText.SetActive(true);
        closingVictoryText = true;
    }
}
