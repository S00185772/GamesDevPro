using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{


    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();

        //coinsCollected = coinsCollected + 1;

        DestroyGameObject();
       
    }



     void DestroyGameObject()
    {
        Destroy(gameObject);
    }





    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
