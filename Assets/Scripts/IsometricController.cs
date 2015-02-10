using UnityEngine;
using System.Collections;
///
/// Isometric world and player's movement.
///
public class IsometricController: MonoBehaviour {
	///
	/// The camera object.
	///
	public Camera cam;
	///
	/// The object to use as reference.
	///
	public GameObject obj;
	///
	/// The camera speed.
	///
	public float camSpeed;
	///
	/// The vehicle speed.
	///
	public float vehicleSpeed;
	///
	/// The zoom speed.
	///
	public float zoomSpeed;
	///
	/// The zoom in limit.
	///
	public float zoomIn;
	///
	/// The zoom out limit.
	///
	public float zoomOut;
	///
	/// The zoomed-state variable.
	///
	private bool isZoomed = false;
	///
	/// The vehicle's old position.
	///
	Vector3 oldPos;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cam != null) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				isZoomed = !isZoomed;
				StartCoroutine(Zoom(isZoomed));
			}
		}
		if (obj != null) {
			float velX = Input.GetAxis("Horizontal");
			float velY = Input.GetAxis("Vertical");
			Vector3 vec = new Vector3(velX, 0.0f, velY);
			vec = Quaternion.AngleAxis(45, Vector3.up) * vec;
			oldPos = obj.transform.position;
			obj.transform.Translate(vec * vehicleSpeed * Time.deltaTime, Space.World);
			Vector3 vel = obj.transform.position - oldPos;
			if (vel.sqrMagnitude > 0.0f) {
				vel = vel + obj.transform.position;
				obj.transform.LookAt(vel);
			}
			FollowPoint(obj.transform.position);
		}
	}
	
	///
	/// Follows the point.
	///
	///Point.
	void FollowPoint (Vector3 point) {
		Vector3 cameraRefPos;
		Vector3 moveVector;
		cameraRefPos = GetScreenToWorldPos(new Vector3(Screen.width/2, Screen.height/2, 0.0f));
		moveVector = (point - cameraRefPos);
		cam.transform.position += moveVector;
	}
	
	///
	/// Zooms in or zooms out the camera.
	///
	///If set to true is zoomed.
	IEnumerator Zoom (bool isZoomed) {
		if (isZoomed) {
			do {
				cam.orthographicSize += Time.deltaTime * zoomSpeed;
				yield return null;
			} while (cam.orthographicSize < zoomOut);
			cam.orthographicSize = zoomOut;
		}
		else {
			do {
				cam.orthographicSize -= Time.deltaTime * zoomSpeed;
				yield return null;
			} while (cam.orthographicSize > zoomIn);
			cam.orthographicSize = zoomIn;
		}
	}
	///
	/// Gets the world position given the screen coordinates.
	///
	///The screen to world position.
	///Mouse position.
	Vector3 GetScreenToWorldPos (Vector3 mousePosition) {
		Ray ray = Camera.main.ScreenPointToRay(mousePosition);
		Plane plane = new Plane(Vector2.up, Vector2.zero);
		float distance = 0;
		if (plane.Raycast(ray, out distance)) {
			return ray.GetPoint(distance);
		}
		return Vector3.zero;
	}
}