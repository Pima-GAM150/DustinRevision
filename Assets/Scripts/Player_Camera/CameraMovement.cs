using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	#region Variables

	[Range(0, 10), Tooltip("Camera Movement Speed")]
	public float MovementSpeed;

	[Range(0, 100), Tooltip("Camera Sensitivity to Mouse Movement")]
	public float CameraSensitivity;

	[Tooltip("View Position Options")]
	public Vector3 WhiteBoardView, BlackBoardView, TopDownView;

	[SerializeField, Tooltip("Mouse Movement Delta")]
	private float rotX, rotY;

	#endregion

	#region Unity Functions

	private void Awake()
	{

	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Confined;
	}

	private void Update()
	{
		CheckForMovement();
		CheckForRotation();
	}

	#endregion

	#region My Functions

	/// <summary>
	/// 
	/// gets mouse movemnt to rotate the camera up down left or right 
	/// 
	/// also clamps rotation to face forward -> up and down but not upside down
	/// 
	/// </summary>
	private void CheckForRotation()
	{ 		
		rotX = Input.GetAxis("Mouse X") * Time.deltaTime * CameraSensitivity;
		
		rotY = Input.GetAxis("Mouse Y") * Time.deltaTime * CameraSensitivity;

		rotY = Mathf.Clamp(rotY, -90, 50);

		transform.localRotation *= Quaternion.AngleAxis(rotX, Vector3.up);

		transform.localRotation *= Quaternion.AngleAxis(rotY, Vector3.left);
	}

	/// <summary>
	/// 
	/// gets input from 'wasd'or arrow keys to move the player accordingly
	/// 
	/// </summary>
	private void CheckForMovement()
	{
		transform.position += transform.forward * MovementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
		transform.position += transform.right * MovementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
	}

	/// <summary>
	/// 
	/// moves the camera to a starting point for each turn
	/// 
	/// </summary>
	/// <param name="turn"></param>
	public void OnTurnChanged(string turn)
	{
		switch (turn)
		{
			case "White":

				transform.position = WhiteBoardView;

				Board.Instance.TurnOffHighlightedMoves();

				break;

			case "Black":

				transform.position = BlackBoardView;

				Board.Instance.TurnOffHighlightedMoves();

				break;

			default:
				transform.position = TopDownView;
				
				break;
		}

		transform.LookAt(Vector3.zero);
	}

	#endregion
}
