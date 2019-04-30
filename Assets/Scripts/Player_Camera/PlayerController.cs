using System;
using UnityEngine;
using UnityEngine.Dustin;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	#region Variables

	[SerializeField]
	private GameObject Selected;
	private GameObject Target;
	private Vector3 MousePos;
	private string Turn;

	public TurnChangedEvent TurnChanged;
	public bool Moved, Captured;
	public Text TurnText;
	public Board TheBoard;
	public LayerMask Pieces;
	public LayerMask Spaces;

	#endregion

	#region Unity Functions
	
	private void Start()
	{
		Turn = "White";
		Moved = true;
		TurnText.text = Turn;
	}

	private void Update()
	{
		if (Selected != null)
		{
			CheckForMovementSelection();

			CheckForCaptureSelection();

			TurnText.text = Turn;
		}

		CheckForPieceSelection();
	}

	#endregion

	#region My Functions

	/// <summary>
	///
	/// Shoot a raycast to select ab piece
	/// 
	/// if it is the same color as whos turn it is make it the selected piece
	/// 
	/// </summary>
	private void CheckForPieceSelection()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (EventSystem.current.IsPointerOverGameObject())
			{
				Debug.Log("Blocked by ui");

				return;
			}

			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out var hit, Mathf.Infinity, Pieces))
			{
				var piece = hit.transform.GetComponentInParent<ChessPieceBase>();

				if (piece.MyColor.ToString().CompareTo(Turn) == 0)
				{
					Selected = piece.gameObject;

					piece.HighlightMoves();

					Moved = false;
				}
			}
		}

	}

	/// <summary>
	/// 
	/// if you have a piece selected move it if you click on a space
	/// 
	/// </summary>
	private void CheckForMovementSelection()
	{
		if (Input.GetMouseButtonDown(0) && !Moved)
		{
			if (EventSystem.current.IsPointerOverGameObject())
			{
				Debug.Log("Blocked by ui");
				return;
			}

			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			Debug.DrawRay(ray.origin, ray.direction, Color.green, 3);

			if (Physics.Raycast(ray, out var hit, Mathf.Infinity, Spaces) && !Moved && Selected != null)
			{
				Moved = Selected.GetComponent<ChessPieceBase>().Move(hit.transform);

				if (Turn == "White" && Moved)
				{
					Turn = "Black";

					TurnChanged?.Invoke(Turn);
				}
				else if (Turn == "Black" && Moved)
				{
					Turn = "White";

					TurnChanged?.Invoke(Turn);
				}
			}
		}
	}

	/// <summary>
	/// 
	/// attmpt to Capture a piece when you click on an oppontnes piece
	/// 
	/// </summary>
	private void CheckForCaptureSelection()
	{
		if (Input.GetMouseButtonDown(0) && !Moved)
		{
			if (EventSystem.current.IsPointerOverGameObject())
			{
				Debug.Log("Blocked by ui");
				return;
			}

			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out var hit, Mathf.Infinity, Pieces) && !Moved && Selected != null)
			{
				if (hit.transform.GetComponentInParent<ChessPieceBase>().MyColor != Selected.GetComponent<ChessPieceBase>().MyColor)
				{
					Captured = Selected.GetComponent<ChessPieceBase>().Attack(hit.transform);

					if (Turn == "White" && Captured)
					{
						Turn = "Black";

						TurnChanged?.Invoke(Turn);
					}
					else if (Turn == "Black" && Captured)
					{
						Turn = "White";

						TurnChanged?.Invoke(Turn);
					}
				}
			}
		}

	}
	
	#endregion
}
