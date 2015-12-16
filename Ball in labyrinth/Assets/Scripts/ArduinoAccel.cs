using UnityEngine;
using System.Collections;
using System.IO.Ports;
public class ArduinoAccel : MonoBehaviour {

	public static string jump;

	private bool inicio = false;

	SerialPort stream = new SerialPort("COM3",9600);

	private float _sensitivity;

	public Transform caixaRef;
	

	private Quaternion target;

	// Use this for initialization
	void Start () {
		stream.Open ();
		_sensitivity = 0.2f;
	}

	private bool inicioOk(){
		string value = stream.ReadLine();
		if (value == "OK") {
			return true;
		} else {
			return false;
		}
	}

	private Quaternion anguloTarget(string valueString){
		string[] vec3 = valueString.Split (',');
		float x = float.Parse (vec3 [0]);
		float z = float.Parse (vec3 [1]);

		Quaternion targetTemp = Quaternion.Euler ((x) * _sensitivity, 0, (z) * _sensitivity);
		return targetTemp;

	}

	private Quaternion targetUpdate(){
		return Quaternion.Slerp (transform.rotation, target, Time.deltaTime * 2f);
	}

	// Update is called once per frame
	void Update () {
		if (inicio) {
			string value = stream.ReadLine();
			target = anguloTarget(value);
			caixaRef.rotation = targetUpdate();
		} else {
			inicio = inicioOk();
		}

	}


}

