using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour {
	private float _sensitivity;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation;
	private bool _isRotating;

	private Transform CaixaRef;

	void Start ()
	{
		CaixaRef = GameObject.Find ("Caixa").GetComponent<Transform> ();
		_sensitivity = 0.05f;
		_rotation = Vector3.zero;
	}
	
	void Update()
	{
		if(_isRotating){

			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);
			// apply rotation
			_rotation.z = (-(_mouseOffset.x) * _sensitivity);
			_rotation.x = ((_mouseOffset.y) * _sensitivity);
			// rotate
			//transform.Rotate(_rotation);
			transform.eulerAngles += _rotation;
			//transform.Rotate(_rotation);
			// store mouse
			_mouseReference = Input.mousePosition;
		}

		if (Input.GetMouseButtonDown (0)) {
			// rotating flag
			_isRotating = true;
			
			Debug.Log ("Pegando a posicao do mouse");
			
			// store mouse
			_mouseReference = Input.mousePosition;
			Debug.Log (_mouseReference);
		} else if (Input.GetMouseButtonUp (0)) {
			// rotating flag
			_isRotating = false;
		}
	}
	
}
