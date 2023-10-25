using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = GameManager.Instance.lives;
        maxHealth = GameManager.Instance.maxLives;

        for(int i = 0; i < hearts.Length; i++){
            if (i < maxHealth){
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }
            if(i < health){
                hearts[i].sprite = fullHeart;
            }else{
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
