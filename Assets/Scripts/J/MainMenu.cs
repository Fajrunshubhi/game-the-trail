using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text txTotalKoin;
    void Start(){
        txTotalKoin = GameObject.Find("TxKoin").GetComponent<Text>();
        TampilKoin();
    }

    public void loadLevel(int level){
        GameManager.Instance.loadLevel("Level", level);
    }

    private void TampilKoin() {
        txTotalKoin.text = GameManager.Instance.getAllKoin().ToString()+"x";
    }



    // public void level2IsActive(){
    //     btnLevel2.SetActive(true);
    // }
    // public  void level2IsNonActive(){
    //     btnLevel2.SetActive(false);
    // }

    // public  void level3IsActive(){
    //     btnLevel3.SetActive(true);
    // }
    // public  void level3IsNonActive(){
    //     btnLevel3.SetActive(false);
    // }

}
