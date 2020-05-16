using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public float Health = 1.0f;
    public int coinsCollected;
    public GameObject playername;
    string Name;
    int random;
    public GameObject changingText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(coinsCollected > 32)
        {
            FindObjectOfType<GameManager>().Winner();
        }

        FindObjectOfType<GameManager>().OutofTime();

        TextChange();

    }

    public void CoinAdd()
    {
        random = Random.Range(1, 10);


        if (random <= 3)
        {
            coinsCollected = coinsCollected + 1;
        }
        else if (random > 3 && random < 7)
                {
            coinsCollected = coinsCollected + 2;
        }
         else if (random >= 7)
        {
            coinsCollected = coinsCollected + 3;
        }

        Debug.Log(random);
    }



    public void TextChange()
    {

       ;
        int index =    FindObjectOfType<PlayerMover>().GetPlayerIndex();

     playername =   GameObject.FindGameObjectWithTag("Player");
        if (index == 0)
        {
            //changingText.text = playername.GetComponent<Data>.coinsCollected.ToString();
            //changingText.text = playername.ToString();

            changingText.GetComponent<Text>().text = coinsCollected.ToString();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            CoinAdd();
        }
    }


    //void Winner()
    //{
    //Name =    playername.name.ToString();

    //}

}
