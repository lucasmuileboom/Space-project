using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_level : MonoBehaviour
{
   
        
    [SerializeField]
    private Vector2 position ;

    [SerializeField]
    private GameObject Object;


        // als we een collectable oppakken is dat de laatste zo ja, spelletje gewonnen
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
            
           Object.transform.position = position;
        }

        }
        
    }


