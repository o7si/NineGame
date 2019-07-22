using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Sprite[] numberSprites = new Sprite[10];	// 游戏分数精灵
	public GameObject gameOver;
	public Image scoreAImage;
	public Image scoreBImage;
	public Image infoImage;

	public int gameScore = 0;				// 游戏分数记录
	public float birdUpSpeed = 3.0f;		// 点击上升速率
	public float pipeMoveSpeed = 4.0f;  	// 管道移动速度
	public float pipeGenerateTime = 1.0f;	// 管道生成间隔

	public bool isGameStart = false;


	public void GameStart() {
		Destroy (infoImage);
		transform.GetComponent<PipeGenerate> ().enabled = true;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<BirdFly> ().enabled = true;
		GameObject.FindGameObjectWithTag ("Player").AddComponent<Rigidbody2D> ();
	}

	public IEnumerator GameOver() {
		PlayerPrefs.SetInt ("LastScore", gameScore);
		Time.timeScale = 0;
		//yield return new WaitForSeconds(1.0f);
		UnityEngine.SceneManagement.SceneManager.LoadScene (2);
		yield return null;
	}

	public void AddScore(int score) {
		gameScore += score;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int scoreA = gameScore / 10;
		int scoreB = gameScore % 10;
		scoreAImage.sprite = numberSprites [scoreA];
		scoreBImage.sprite = numberSprites [scoreB];
		if (!isGameStart && Input.GetMouseButtonDown (0)) {
			GameStart ();
		}
	}
}
