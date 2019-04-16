using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	#region Variables

	public GameObject BlackSpacePrefab , WhiteSpacePrefab;

	public Transform StartingPositionBoard;

	public Transform StartingpositionPieces;

	public GameObject[] Pieces;
	
	#endregion
	
	#region Unity Functions
	
	private void Awake()
	{
		InstantiateBoard();

		InstantiatePieces();
	}
	
	#endregion

	#region My Functions

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

						space.transform.SetParent(StartingPositionBoard);

						space.transform.localPosition = new Vector3(-4 + w, 0, -4 + h);

						space.transform.localEulerAngles = Vector3.zero;

						space.transform.localScale = Vector3.one;
					}
					else
					{
						var space = Instantiate(BlackSpacePrefab, Vector3.zero, Quaternion.identity);

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

						space.transform.SetParent(StartingPositionBoard);

						space.transform.localPosition = new Vector3(-4 + w, 0, -4 + h);

						space.transform.localEulerAngles = Vector3.zero;

						space.transform.localScale = Vector3.one;
					}
					else
					{
						var space = Instantiate(WhiteSpacePrefab, Vector3.zero, Quaternion.identity);

						space.transform.SetParent(StartingPositionBoard);

						space.transform.localPosition = new Vector3(-4 + w, 0, -4 + h);

						space.transform.localEulerAngles = Vector3.zero;

						space.transform.localScale = Vector3.one;
					}
				}

			}
		}
	}

	private void InstantiatePieces()
	{

	}

	#endregion
}
