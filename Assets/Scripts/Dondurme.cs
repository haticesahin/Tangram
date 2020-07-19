using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dondurme : MonoBehaviour
{
	#region ROTATE
	private float _sensitivity = 1f;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation = Vector3.zero;
	private Vector3 _pozition = Vector3.zero;
	private bool _isRotating;
	public GameObject obj;


	#endregion

	void Update()
	{
		if (_isRotating)
		{
			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);

			// apply rotation
			_rotation.x = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;

			// rotate
			gameObject.transform.Rotate( _rotation);
			transform.position = new Vector3(transform.position.x +_mouseOffset.x , transform.position.y + _mouseOffset.y, transform.position.z + _mouseOffset.z);

			// store new mouse position
			_mouseReference = Input.mousePosition;
		}
	}

	void OnMouseDown()
	{
		// rotating flag
		_isRotating = true;

		// store mouse position
		_mouseReference = Input.mousePosition;
		//transform.position = new Vector3(transform.position.x + _mouseOffset.x, transform.position.y + _mouseOffset.y, transform.position.z + _mouseOffset.z);
	}

	void OnMouseUp()
	{
		// rotating flag
		_isRotating = false;
	}

}
