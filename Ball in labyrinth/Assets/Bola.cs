using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {

	public float		Distance;
	public Transform	Buraco;
	public Transform 	BolaTr;
	public string[]		typeRisco = new string[2];
	public string		casoRisco;
	// Use this for initialization
	void Start () {
		typeRisco[0] = "p";
		typeRisco[1] = "l";
	
	}
	
	// Update is called once per frame
	void Update () {
		Distance = CheckDistance(Buraco);
		if(Distance <= 4){
			casoRisco = typeRisco[0];
		}else{
			casoRisco = typeRisco[1];
		}

	}

	public float CheckDistance(Transform Other){
		float D = Vector3.Distance(Other.position, BolaTr.position);
		//Debug.Log (Distance);
		return D;
	}
}
