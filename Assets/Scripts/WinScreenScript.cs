using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenScript : MonoBehaviour
{

    public string winScreenSceneName;
    
    public string playerTag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
      if (other.CompareTag(playerTag)) 
        {

            //win screen is shown 
            SceneManager.LoadScene(winScreenSceneName);
            //timescale is set to 0, pausing game
            Time.timeScale = 0f;


        }
    }



    public static bool IsGamePaused
    {
        get
        {
            return Time.timeScale == 0;
        }
    }

}


