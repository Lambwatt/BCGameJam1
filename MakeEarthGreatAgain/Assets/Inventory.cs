using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	[System.Serializable]
	public class gasRobotAndData{
		public string name;
		public int quantity;
		public int price;
		public Text priceDisplay;
		public Text quantityDisplay;
	}

	class roboData{
		public int price;
		public int quantity;
		//public Text priceDisplay;
		public Text quantityDisplay;
	}

	Dictionary<string, roboData> allRobotData;

	public gasRobotAndData[] robots;
	public int carbonSupply;

	public Text supplyText;

	string activeRobot = "carbon";

	void Start(){
		InvokeRepeating("recieveCarbon", 3, 3);

		allRobotData = new Dictionary<string, roboData>();
		foreach(gasRobotAndData r in robots){
			roboData rd = new roboData();
			rd.quantity = r.quantity;
			rd.price = r.price;
			rd.quantityDisplay = r.quantityDisplay;
			//rd.priceDisplay = r.priceDisplay;
			r.priceDisplay.text = ""+r.price;//Static
			allRobotData.Add(r.name, rd);
		}
	}

	void Update(){
		supplyText.text = "CarbonSupply:"+carbonSupply;
		foreach(roboData rd in allRobotData.Values){			
			rd.quantityDisplay.text = "x"+rd.quantity;
		}
	}

	public void selectRobot(string gas){
		activeRobot = gas;
	}

	public void addCarbon(int carbon){
		carbonSupply+= carbon;
	}

	public bool launchRobot(string gas){
		
		//if(allRobotData[c.gasType].quantity>0){//Quantity check performed on cloud. It's stupid, but it works.
//			Robot r = Instantiate(robot, transform.position, Quaternion.identity).GetComponent<Robot>();
//			r.init(c);
			allRobotData[gas].quantity--;
			return true;
		//}
	}

	public void buildRobot(string r){
		if(allRobotData[r].price <= carbonSupply){
			allRobotData[r].quantity++;
			carbonSupply -= allRobotData[r].price;
		}
	}

	void recieveCarbon(){
		carbonSupply += 1;
	}

//	public int getCarbonSupply(){
//		return carbonSupply;
//	}
//
//	public int getPrice(string gas){
//		return allRobotData[gas].price;
//	}
//
	public bool canShoot(string gas){
		return allRobotData[gas].quantity>0 && activeRobot == gas;
		//return 1;
	}
}
