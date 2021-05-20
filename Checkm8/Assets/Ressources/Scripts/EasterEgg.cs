using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasterEgg : MonoBehaviour
{
    private string[] cheatCode;
    private string[] cheatCode_final;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        // Code is "up up down down left right left right b a", user needs to input this in the right order
        cheatCode = new string[] { "w", "x" };
        cheatCode_final = new string[] { "up", "up", "down", "down", "left", "right", "left", "right", "b", "a" };
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Check if the next key in the code is pressed
            if (Input.GetKeyDown(cheatCode[index]))
            {
                // Add 1 to index to check the next key in the code
                index++;
            }
            // Wrong key entered, we reset code typing
            else
            {
                index = 0;
            }
        }

        // If index reaches the length of the cheatCode string, 
        // the entire code was correctly entered
        if (index == cheatCode.Length)
        {
            // Cheat code successfully inputted!
            // Unlock crazy cheat code stuff
            SceneManager.LoadScene("1v1_game");
        }
    }
}
