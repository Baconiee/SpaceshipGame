using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController1 : MonoBehaviour
{
    public Text gameNameText;
    public Text welcomeText;
    public Text informationText;
    public Text startText;
    public Text healthInfoText;

   
    void Start()
    {
        gameNameText.text = "Spaceship";
        welcomeText.text = "Hello, Welcome To My Game!";
        informationText.text = "You Can Use W/A/S/D or Arrow Keys To Move The Spaceship and You Can Press or Hold(Optional) The \"Space\" To Shoot";
        startText.text = "If You're Ready  Go Forward To Start The Game :)";
        healthInfoText.text = "If You Have Health You Live";
    }
}
