using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoinDisplay : MonoBehaviour
{
    public int koin;
    public Text txKoin;

    void Start(){     
    }
    
    void Update()
    {
        koin = GameManager.Instance.getKoin();
        txKoin = GameObject.Find("TxKoin").GetComponent<Text>();
        TampilKoin();
    }
    private void TampilKoin() {
        txKoin.text = koin.ToString()+"x";
    }
}
