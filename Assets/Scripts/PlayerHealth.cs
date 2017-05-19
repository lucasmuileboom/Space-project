using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int lives = 3;
    [SerializeField] private Vector2 respawnPosition;

    public void hit()
    {
        lives -= 1;
        transform.position = respawnPosition;
        print(lives); 
        if (lives <= 0)//gameover
        {
            Application.LoadLevel(2);
        }
    }
}
