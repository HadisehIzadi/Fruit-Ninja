using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	//**************************
	public Text scoretext;
	private int score;
	
	//**************************
    // Start is called before the first frame update
    void Start()
    {
    	NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void IncreaseScore()
    {
    	score++;
    	scoretext.text = score.ToString();
    }
    
    private void NewGame()
    {
    	score = 0 ;
    	scoretext.text = score.ToString();
    }
    
    public void Restart()
    {
    	SceneManager.LoadScene("FruitNinja");
    }
    
    public void Exit()
    {
    	Application.Quit();
    }
}
