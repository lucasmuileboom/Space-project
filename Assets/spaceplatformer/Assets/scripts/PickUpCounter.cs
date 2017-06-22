using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCounter : MonoBehaviour
{
    

    // bijhouden hoeveel pickups zijn  opgepakt
    private int _pickUpsCollected = 0;

    //berekenen hoeveel pickups er in de scene zijn
    private int _PickUpsInScene;

    private void Start()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("pickUp");
        _PickUpsInScene = pickups.Length;

        print(_PickUpsInScene);
    }



    // als we een collectable oppakken is dat de laatste zo ja, spelletje gewonnen
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pickUp")
        {
            _pickUpsCollected++;
            Destroy(other.gameObject);

            //if (_pickUpsCollected == 5)
            //{
            //    print("you win");
            //}
        }
    }
   
}

