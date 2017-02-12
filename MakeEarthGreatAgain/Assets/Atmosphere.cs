using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Atmosphere : MonoBehaviour {

	//int carbonCount;

	public float temperature;
	public Text temperatureText;
	public Text carbonText;
	public Text countdownText;

	public int countdown;
	public float maxTemperature;
	public float initialTemperature;

	public string[] gases;

	Dictionary<string, int> contributerCount;
	// Use this for initialization
	void Start () {
		contributerCount = new Dictionary<string, int>();
		foreach(string s in gases){
			contributerCount.Add(s, 0);
		}

		InvokeRepeating("deductTime", 0, 1);
		InvokeRepeating("updateTemperature", 0, .5f);
	}
	
	// Update is called once per frame
	void Update () {
		//carbonText.text = "carbon count: "+carbonCount;
	}

	void deductTime(){
		
		countdown-=1;
		countdownText.text = "Countdown: "+countdown;
		if(countdown <= -1){
			SceneManager.LoadScene("Win");
		}
	}

	void updateTemperature(){
		temperature += contributerCount["carbon"] - 1; //much more complicated operation belongs here.
		temperatureText.text = "temp: "+temperature;
		if(temperature>maxTemperature){
			SceneManager.LoadScene("GameOver");
		}
	}

	public void AddCloud(string type){
		contributerCount[type]++;
	}

	public void RemoveCloud(string type){
		contributerCount[type] = Mathf.Max(contributerCount[type]-1, 0);
	}


}
