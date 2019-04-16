using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	#region Variables

	private GameObject Selected;
	private GameObject Target;
	private Vector3 MousePos, NewPos;
	private string Turn;
	private bool Moved;
	private ChessPieceBase MovingPiece;
	public Text TurnText;
	public Board TheBoard;

	#endregion

	#region Unity Functions

	private void Awake()
	{

	}

	private void Start()
	{

	}


	private void Update()
	{
		CheckForMovement();
		CheckForRotation();
		CheckForPieceSelection();
		CheckForMovementSelection();
	}



	#endregion

	#region My Functions

	private void CheckForPieceSelection()
	{
		
	}

	private void CheckForMovementSelection()
	{
		
	}

	private void CheckForRotation()
	{
		
	}

	private void CheckForMovement()
	{
		
	}

	#endregion
}
