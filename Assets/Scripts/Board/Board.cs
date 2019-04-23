using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Dustin;

public class Board : MonoBehaviour
{
	#region Variables

	public static Board Instance;

	public BoardResetEvent ResettingBoard;

	public GameObject BlackSpacePrefab , WhiteSpacePrefab;

	public Transform StartingPositionBoard;

	public Transform StartingPositionPieces;

	public GameObject[] Pieces;

	[HideInInspector]
	public List<GameObject> Spaces;

	[HideInInspector]
	public List<GameObject> WhitePieces;

	[HideInInspector]
	public List<GameObject> BlackPieces;
	
	#endregion
	
	#region Unity Functions
	
	private void Awake()
	{
		WhitePieces = new List<GameObject>();

		BlackPieces = new List<GameObject>();

		Spaces = new List<GameObject>();

		InstantiateBoard();

		InstantiatePieces();

		Instance = this;
	}
		
	#endregion

	#region My Functions

	/// <summary>
	/// Creates boardspaces
	/// </summary>
	private void InstantiateBoard()
	{
		for (int w = 0; w < 8; w++) 
		{
			for (int h = 0; h < 8; h++)
			{
				if (w % 2 == 0)
				{
					if(h % 2 == 0)
					{
						var space =	Instantiate(WhiteSpacePrefab, Vector3.zero, Quaternion.identity);

						Spaces.Add(space);

						space.transform.SetParent(StartingPositionBoard);

						space.transform.localPosition = new Vector3(-4 + w, 0, -4 + h);

						space.transform.localEulerAngles = Vector3.zero;

						space.transform.localScale = Vector3.one;
					}
					else
					{
						var space = Instantiate(BlackSpacePrefab, Vector3.zero, Quaternion.identity);

						Spaces.Add(space);

						space.transform.SetParent(StartingPositionBoard);

						space.transform.localPosition = new Vector3(-4 + w, 0, -4 + h);

						space.transform.localEulerAngles = Vector3.zero;

						space.transform.localScale = Vector3.one;
					}
				}
				else
				{
					if (h % 2 == 0)
					{
						var space = Instantiate(BlackSpacePrefab, Vector3.zero, Quaternion.identity);

						Spaces.Add(space);

						space.transform.SetParent(StartingPositionBoard);

						space.transform.localPosition = new Vector3(-4 + w, 0, -4 + h);

						space.transform.localEulerAngles = Vector3.zero;

						space.transform.localScale = Vector3.one;
					}
					else
					{
						var space = Instantiate(WhiteSpacePrefab, Vector3.zero, Quaternion.identity);

						Spaces.Add(space);

						space.transform.SetParent(StartingPositionBoard);

						space.transform.localPosition = new Vector3(-4 + w, 0, -4 + h);

						space.transform.localEulerAngles = Vector3.zero;

						space.transform.localScale = Vector3.one;
					}
				}

			}
		}
	}

	/// <summary>
	/// makes pieces and puts them in starting positions
	/// </summary>
	private void InstantiatePieces()
	{
		var index = 2;
		var offset = 1;

		for (int rows = 0; rows < 8; rows++)
		{
			if(rows == 7)
			{
				offset = 1;
			}

			for (int columns = 0; columns < 8; columns++)
			{
				if(columns < 5)
				{
					index = columns % 5 + 2;
				}
				else
				{
					index = (columns - offset) % 5;

					offset+=2;
				}
				
				if(rows == 0)
				{
					var piece = Instantiate(Pieces[index], Vector3.zero, Quaternion.identity);

					piece.GetComponent<ChessPieceBase>().MyColor = PieceColor.White;

					piece.transform.SetParent(StartingPositionPieces);

					piece.transform.localPosition = new Vector3(-4 + rows, 1f, -4 + columns);

					piece.transform.localEulerAngles = Vector3.zero;

					piece.transform.localScale = Vector3.one * .2f;

					WhitePieces.Add(piece);
				}
				else if(rows == 1)
				{
					var piece = Instantiate(Pieces[columns % 2 == 0 ? 0 : 1], Vector3.zero, Quaternion.identity);

					piece.GetComponent<ChessPieceBase>().MyColor = PieceColor.White;

					piece.transform.SetParent(StartingPositionPieces);

					piece.transform.localPosition = new Vector3(-4 + rows, 1f, -4 + columns);

					piece.transform.localEulerAngles = Vector3.zero;

					piece.transform.localScale = Vector3.one * .2f;

					WhitePieces.Add(piece);
				}
				else if(rows == 6)
				{
					var piece = Instantiate(Pieces[columns % 2 == 0 ? 0 : 1], Vector3.zero, Quaternion.identity);

					piece.GetComponent<ChessPieceBase>().MyColor = PieceColor.Black;

					piece.transform.SetParent(StartingPositionPieces);

					piece.transform.localPosition = new Vector3(-4 + rows, 01f, -4 + columns);

					piece.transform.localEulerAngles = Vector3.zero;

					piece.transform.localScale = Vector3.one * .2f;

					BlackPieces.Add(piece);
				}
				else if (rows == 7)
				{
					var piece = Instantiate(Pieces[index], Vector3.zero, Quaternion.identity);

					piece.GetComponent<ChessPieceBase>().MyColor = PieceColor.Black;

					piece.transform.SetParent(StartingPositionPieces);

					piece.transform.localPosition = new Vector3(-4 + rows, 1f, -4 + columns);

					piece.transform.localEulerAngles = Vector3.zero;

					piece.transform.localScale = Vector3.one * .2f;

					BlackPieces.Add(piece);
				}
			}
		}
	}
	
	/// <summary>
	/// Reinstantiates pieces at starting positions
	/// </summary>
	public void ResetBoard()
	{
		Debug.Log("resetting board");

		ResettingBoard?.Invoke();

		foreach (GameObject obj in WhitePieces)
		{
			Destroy(obj);
		}
		foreach (GameObject obj in BlackPieces)
		{
			Destroy(obj);
		}

		BlackPieces = new List<GameObject>();
		WhitePieces = new List<GameObject>();

		InstantiatePieces();
	}

	/// <summary>
	/// if the Gameobject that has been captured is in one of the lists remove it and return;
	/// </summary>
	/// <param name="go"></param>
	public void RemovePiece(GameObject go)
	{
		foreach (GameObject obj in WhitePieces)
		{
			if(obj==go)
			{
				WhitePieces.Remove(go);

				return;
			}
		}
		foreach (GameObject obj in BlackPieces)
		{
			if(obj == go)
			{
				BlackPieces.Remove(go);

				return;
			}
		}
	}
	
	#endregion
}

namespace UnityEngine.Dustin
{
	[System.Serializable]
	public class BoardResetEvent: Events.UnityEvent
	{

	}
}