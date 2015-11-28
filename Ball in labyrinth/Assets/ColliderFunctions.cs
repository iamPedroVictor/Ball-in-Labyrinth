using UnityEngine;
using System.Collections;

public class ColliderFunctions : MonoBehaviour {

	public string _ObjectTag;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Espere(){
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevel(Application.loadedLevel);
	}
	
	void OnCollisionEnter(Collision collision){
		if ( (collision.gameObject.tag == "Ball") && (_ObjectTag == "Exit") ) {
			Debug.Log("Parabens voce passou na fase");
		}
		if ( (collision.gameObject.tag == "Ball") && (_ObjectTag == "Fall") ) {
			Debug.Log("Voce Caiu tente novamente");
			StartCoroutine(Espere());
		}
		
	}


}
