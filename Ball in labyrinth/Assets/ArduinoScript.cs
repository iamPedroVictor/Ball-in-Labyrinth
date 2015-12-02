using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ArduinoScript : MonoBehaviour {
	private	SerialPort stream = new SerialPort("COM3", 9600);
	private	bool ok;
	private	GameObject BolaScr;
	private	string texto;
	public	string PortaSerial; 
	public	int SpeddSerial;
	private	string oldTexto;

    // Use this for initialization
    void Start () {
		ok = true;
		stream.Open();
		BolaScr = GameObject.FindGameObjectWithTag("Ball");
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*texto = BolaScr.GetComponent<Bola>().Distance.ToString("F2");
		if(oldTexto != texto){
			Debug.Log ("D: " + texto);
			stream.Write("D: " + texto);
			oldTexto = texto;
		}*/
		texto = BolaScr.GetComponent<Bola>().casoRisco;
		if(texto != oldTexto){
			stream.Write(texto);
			Debug.Log ("D: " + texto);
			oldTexto = BolaScr.GetComponent<Bola>().casoRisco;
		}



	}
}
 