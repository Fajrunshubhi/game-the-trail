using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public void LoadGame(){
        GameManager.Instance.NewGame();
    }

    public void GoToMainMenu(){
        GameManager.Instance.MainMenu();
    }

    public void NextLevel(int level){
        GameManager.Instance.NextLevel("Level", level);
    }
}
