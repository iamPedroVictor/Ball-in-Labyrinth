using UnityEngine;
using System.Collections;
using System.IO.Ports;
public class ArduinoAccel : MonoBehaviour {

	public static string jump;

	SerialPort stream = new SerialPort("COM3",9600);

	private float _sensitivity;

	private Quaternion target;

	// Use this for initialization
	void Start () {
		stream.Open ();
		_sensitivity = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		string value = stream.ReadLine();
		if(value == "OK"){
			value = stream.ReadLine();
		}
		string[] vec3 = value.Split(',');
		if(vec3.Length == 3){
			value = stream.ReadLine();
			vec3 = value.Split(',');
			float X = float.Parse(vec3[0]);
			float Z = float.Parse(vec3[1]);
			target = Quaternion.Euler((X * -1) * _sensitivity , 0,(Z * -1) * _sensitivity);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
		}
	}


}

