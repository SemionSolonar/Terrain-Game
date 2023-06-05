using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RemyScript : MonoBehaviour
{
    private Animator anim;
    public float health = 100f;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            ReloadGame();
         
        }
    }

      // Method to reload the game
    private void ReloadGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", false);
        }
    }
}
