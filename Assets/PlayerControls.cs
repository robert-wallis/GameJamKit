using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
	public float _speedTurn = 10f;
	public float _speedForward = 10f;
	public float _speedStrafe = 10f;
	public float _speedTilt = 10f;

	Camera _camera; // should be somewhere as a child, first and third person

	// Use this for initialization
	void Start()
	{
		_camera = GetComponentInChildren<Camera>();
	}

	void Update()
	{
		if (true == Input.GetKeyUp(KeyCode.Mouse0)) {
			Screen.lockCursor = true;
		}
		if (true == Input.GetKeyUp(KeyCode.Escape)) {
			Screen.lockCursor = false;
			Screen.showCursor = true;
		}
	}

	void FixedUpdate()
	{
		// basic movement
		float forward = Input.GetAxis("forward") * _speedForward * Time.fixedDeltaTime;
		float strafe = Input.GetAxis("strafe") * _speedStrafe * Time.fixedDeltaTime;
		transform.Translate(forward * Vector3.forward + strafe * Vector3.right, Space.Self);

		// turning
		float turn = Input.GetAxis("turn");
		if (turn != 0.0f) {
			turn = turn * _speedTurn * Time.fixedDeltaTime;
			transform.Rotate(0f, turn * 15f, 0f, Space.Self);
		} else {
			if (Screen.lockCursor) {
				turn = Input.GetAxis("mouse turn") * _speedTurn * Time.fixedDeltaTime;
				transform.Rotate(0f, turn * 7f, 0f, Space.Self);
			}
		}

		// lookup up and down
		float tilt = Input.GetAxis("fixed tilt");
		if (tilt != 0.0f) {
			Vector3 tiltForward = transform.forward;
			tiltForward.y += tilt;
			Quaternion q = Quaternion.LookRotation(tiltForward, transform.up);
			_camera.transform.rotation = q;
		} else {
			if (Screen.lockCursor) {
				Vector3 eulerAngles = _camera.transform.eulerAngles;
				tilt = Input.GetAxis("mouse tilt") * _speedTilt * Time.fixedDeltaTime;
				eulerAngles.x += tilt * 7f;
				_camera.transform.eulerAngles = eulerAngles;
			}
		}
	}
}
