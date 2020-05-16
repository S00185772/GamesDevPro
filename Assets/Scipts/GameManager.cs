using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    string Name;
    public int CoinsP1;
    public int CoinsP2;

    float currentTime = 0f;
    float startingTime = 80f;

    
    public Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1*Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
    }





    public void Winner()
    {
        Name = player1.name.ToString();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OutofTime()
    {
        if (currentTime <= 0)
        {
            Name = player1.name.ToString();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
