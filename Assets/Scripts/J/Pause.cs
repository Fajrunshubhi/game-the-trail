using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject gamePauseScreen;
    public void ResumeGame(){
        GameManager.Instance.ResumeGame(gamePauseScreen);
    }
    public void GoToMainMenu(){
        GameManager.Instance.MainMenu();
        GameManager.Instance.resetKoin();
        ResumeGame();
    }
}
