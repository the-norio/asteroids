using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D _ridigBody;

	public float thrustSpeed = 1;
	public float turnSpeed = 1;
	
	private bool _thrusting;
	private float _turnDirection;

	private void Awake()
	{
		_ridigBody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		_thrusting = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			_turnDirection = 1.0f;
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			_turnDirection = -1.0f;
		else
			_turnDirection = 0;
	}

	private void FixedUpdate()
	{
		if (_thrusting)
			_ridigBody.AddForce(this.transform.up * this.thrustSpeed);
		
		if (_turnDirection != 0)
			_ridigBody.AddTorque(_turnDirection * turnSpeed);
	}
}
