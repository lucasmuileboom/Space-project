using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Text Health;
    private Vector2 respawnPosition;
    private int lives = 3;

    private void Start()
    {
        Health.text = "Lives: " + lives;
        respawnPosition = transform.position;
    }
    public void hit()
    {
        lives -= 1;
        transform.position = respawnPosition;
        Health.text = "Lives: " + lives; 
        if (lives <= 0)
        {
            Application.LoadLevel(2);
        }
    }
}
