using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lives { get; private set;}
    public int maxLives {get; private set;}
    public string world { get; private set;}
    public int stage { get; private set;}
    public int koin{get; private set;}
    public int koinStage{get; private set;}
    public int allKoin{get; private set;}

    public static GameManager Instance {
        get;
        private set;
    }

    private void Awake(){
        if(Instance != null){
            DestroyImmediate(gameObject);
        } else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }       
    }

    private void Start(){
        maxLives = 5;
        NewGame();
    }

    private void OnDestroy(){
        if(Instance == this){
            Instance = null;
        }
    }
    public void MainMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void NewGame(){
        lives = maxLives;
        // loadLevel("Level", 3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void loadLevel(string world, int stage){
        lives = maxLives;
        this.world = world;
        this.stage = stage;
        SceneManager.LoadScene($"{world}_{stage}");
    }

    public void resetLevel(){
        lives--;
        if(lives > 0){
            loadLevel(world, stage);
        } else{
            gameOver();
        }
    }
    public void Hit(int amount){
        lives -= amount;
    }
    public void Heal(int heal){
        lives += heal ;
    }
    public void DeadByWater(int amount){
        lives -= amount;
    }
    
    public void resetLevel(float delay){
        Invoke(nameof(resetLevel), delay);
    }

    public void gameOver(GameObject gameOverScreen){
        gameOverScreen.SetActive(true);
        resetKoin();
    }
    public void gameOver(){
        // SceneManager.LoadScene("LoseScreen");
        resetKoin();
    }
  
    public void gameOver(float delay){
        Invoke(nameof(gameOver), delay);
    }

    // private void nextLevel(){
    //     loadLevel(world, stage+1);
    //     setAllKoinStage();
    //     setAllKoin();
    // }
    public void NextLevel(string world, int stage){
        lives = maxLives;
        SceneManager.LoadScene($"{world}_{stage}");
        setAllKoinStage();
        setAllKoin();
    }

    public int getKoin(){
        return koin;
    }
    public void setKoin(int amount){
        koin += amount;
    }
    public void resetKoin(){
        koin = 0;
    }


    public int getAllKoinStage(){
        return koinStage;
    }
    public void setAllKoinStage(){
        koinStage += koin;
        koin = 0;
    }


    public void setAllKoin(){
        allKoin += koinStage;
        koinStage = 0;
    }
    public int getAllKoin(){
        return allKoin;
    }

    public void PauseGame(GameObject gamePauseScreen){
        Time.timeScale = 0;
        gamePauseScreen.SetActive(true);
    }

    public void ResumeGame(GameObject gameResumeScreen){
        Time.timeScale = 1;
        gameResumeScreen.SetActive(false);
    }
 
    public void FinishGame(GameObject gameFinishScreen){
        gameFinishScreen.SetActive(true);
    }

}
