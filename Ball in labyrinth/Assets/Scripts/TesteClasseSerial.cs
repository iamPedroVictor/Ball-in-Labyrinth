using UnityEngine;
using System.Collections;

public class TesteClasseSerial : MonoBehaviour{
	public string nameD;
	public int speedD;
	private SerialClass okie;
	// Use this for initialization
	void Start (){
		okie = new SerialClass(nameD,speedD);
	}
	
	// Update is called once per frame
	void Update (){
		okie.serialPortRead();
	
	}
}

