using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	#region Variables

	public Vector3 WhiteBoardView, BlackBoardView, TopDownView;
	
	#endregion
	
	#region Unity Functions
	
	private void Awake()
	{
		
	}
	
	private void Start()
	{
		SubToPieces();
		Board.Instance.ResettingBoard.AddListener(OnBoardReset);
	}

    
	private void Update()
	{
		CheckForMovement();
		CheckForRotation();
	}

	private void OnDestroy()
	{
		UnSubToPieces();
		Board.Instance.ResettingBoard.RemoveListener(OnBoardReset);
	}

	#endregion

	#region My Functions

	private void CheckForRotation()
	{

	}

	private void CheckForMovement()
	{

	}

	public void OnTurnChanged()
	{

	}

	public void OnBoardReset()
	{
		SubToPieces();
	}

	private void SubToPieces()
	{
		foreach (GameObject go in Board.Instance.WhitePieces)
		{
			go.GetComponent<ChessPieceBase>().IMoved.AddListener(OnTurnChanged);
		}
		foreach (GameObject go in Board.Instance.BlackPieces)
		{
			go.GetComponent<ChessPieceBase>().IMoved.AddListener(OnTurnChanged);
		}
	}

	private void UnSubToPieces()
	{
		foreach (GameObject go in Board.Instance.WhitePieces)
		{
			go.GetComponent<ChessPieceBase>().IMoved.RemoveListener(OnTurnChanged);
		}
		foreach (GameObject go in Board.Instance.BlackPieces)
		{
			go.GetComponent<ChessPieceBase>().IMoved.RemoveListener(OnTurnChanged);
		}
	}

	#endregion
}
