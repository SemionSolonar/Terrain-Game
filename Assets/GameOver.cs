using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Game Over");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
