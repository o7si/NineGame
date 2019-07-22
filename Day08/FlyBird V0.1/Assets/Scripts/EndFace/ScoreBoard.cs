using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

	private const int medalNum = 3;
	public Sprite[] medalSprites = new Sprite[medalNum];
	private const int numberNum = 10;
	public Sprite[] numSprites = new Sprite[numberNum];
	public GameObject newRecord;
	public Image medalImage;
	public Image lastScoreA;
	public Image lastScoreB;
	public Image bestScoreA;
	public Image bestScoreB;
	public int bestScore;
	public int lastScore;

	// Use this for initialization
	void Start () {
		lastScore = PlayerPrefs.GetInt ("LastScore");
		bestScore = PlayerPrefs.GetInt ("BestScore", 0);
		UpdateScore ();
	}

	void UpdateScore() {
		if (lastScore > bestScore) {
			Instantiate (newRecord, Vector3.zero, newRecord.transform.rotation);
			bestScore = lastScore;
			PlayerPrefs.SetInt ("BestScore", bestScore);
		}

		if (lastScore <= 20) {
			medalImage.sprite = medalSprites [0];
		} else if (lastScore <= 50) {
			medalImage.sprite = medalSprites [1];
		} else {
			medalImage.sprite = medalSprites [2];
		}
		Debug.Log (lastScore + ", " + bestScore);
		lastScoreA.sprite = numSprites [lastScore / 10];
		lastScoreB.sprite = numSprites [lastScore % 10];
		bestScoreA.sprite = numSprites [bestScore / 10];
		bestScoreB.sprite = numSprites [bestScore % 10];
	}

	public void Menu() {
		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}

}
