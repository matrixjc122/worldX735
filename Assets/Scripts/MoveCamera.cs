﻿// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.

using UnityEngine;
using System.Collections;


public class MoveCamera : MonoBehaviour 
{
	//
	// VARIABLES
	//
	
	public float turnSpeed = 35.0f;			// Speed of camera turning when mouse moves in along an axis
	public float panSpeed = 360.0f;			// Speed of the camera when being panned
	public float zoomSpeed = 0.1f;		// Speed of the camera going back and forth
	
	public float turnDrag = 5.0f;			// RigidBody Drag when rotating camera
	public float panDrag = 3.5f;			// RigidBody Drag when panning camera
	public float zoomDrag = 3.3f;			// RigidBody Drag when zooming camera
	
	private Vector3 mouseOrigin;			// Position of cursor when mouse dragging startss
	private bool isPanning;				// Is the camera being panned?
	private bool isRotating;			// Is the camera being rotated?
	private bool isZooming;				// Is the camera zooming?
	
	//
	// AWAKE
	//
	
	void Awake()
	{
		// Setup camera physics properties
		gameObject.AddComponent<Rigidbody>();
		GetComponent<Rigidbody>().useGravity = false;
	}
	
	//
	// UPDATE: For input
	//
	
	void Update () 
	{
		// == Getting Input ==
		
		
		// Get the left mouse button
		if(Input.GetMouseButtonDown(0))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isRotating = true;
			Debug.Log("Found 0");	
		}
		
		
		// Get the right mouse button
		if(Input.GetMouseButtonDown(1))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isPanning = true;
			Debug.Log("Found 1");	
		}
		
		
		// Get the middle mouse button
		if(Input.GetMouseButtonDown(2))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isZooming = true;
			
			Debug.Log("Found 2");	
		}
		
		
		// == Disable movements on Input Release ==
		
		if (!Input.GetMouseButton(0))  isRotating = false;
		if (!Input.GetMouseButton(1))  isPanning = false;
		if (!Input.GetMouseButton(2))  isZooming = false;
		
	}
	
	//
	// Fixed Update: For Physics
	//
	
	void FixedUpdate()
	{
		// == Movement Code ==
		
				
		// Move (pan) the camera on it's XY plane
		if (isPanning)
		{
			// Get mouse displacement vector from original to current position
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
			
			// Apply the pan's move vector in the orientation of the camera's front
			Quaternion forwardRotation = Quaternion.LookRotation(transform.forward, transform.up);
			move = forwardRotation * move;
			
			// Set Drag
			GetComponent<Rigidbody>().drag = panDrag;
			
			// Pan
			GetComponent<Rigidbody>().AddForce(move, ForceMode.Acceleration);
		}
		
		// Move the camera linearly along Z axis
		if (isZooming)
		{
			// Get mouse displacement vector from original to current position
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			
			if(pos.y < 0)
				GetComponent<Camera>().orthographicSize +=  pos.sqrMagnitude*zoomSpeed;
			if(pos.y > 0)
				GetComponent<Camera>().orthographicSize -=  pos.sqrMagnitude*zoomSpeed;
			mouseOrigin = Input.mousePosition;
			
		}
	}
	
}
