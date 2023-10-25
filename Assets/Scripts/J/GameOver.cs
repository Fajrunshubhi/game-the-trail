using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void LoadGame(){
        GameManager.Instance.NewGame();
    }

    public void GoToMainMenu(){
        GameManager.Instance.MainMenu();
    }
}
