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
    public GameObject Panel;
    public GameOver gameOver;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gameOver = new GameOver();
        gameOver.Panel = Panel;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            Time.timeScale = 0;
            Panel.SetActive(true);
            healthText.text = "0";
            gameOver.EndGame();
        }
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
