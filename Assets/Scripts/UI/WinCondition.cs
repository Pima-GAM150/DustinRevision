using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
	#region Variables

	public Board board;

	[SerializeField]
	private GameObject WhiteNinja, BlackNinja;
	[SerializeField]
	private GameObject WhiteKunoichi, BlackKunoichi;

	public Text WinText;
	public GameObject pauseMenu;

	#endregion

	#region Unity Functions
		
	private void Start()
	{
		SetWinPieces();
	}
	
	void Update()
	{
		if (!board.WhitePieces.Contains(WhiteNinja) && !board.WhitePieces.Contains(WhiteKunoichi))
		{
			WinText.text = "Black Wins!!";
			WinText.GetComponent<Text>().color = Color.black;
			pauseMenu.SetActive(true);
		}
		if (!board.BlackPieces.Contains(BlackNinja) && !board.BlackPieces.Contains(BlackKunoichi))
		{
			WinText.text = "White Wins!!";
			WinText.GetComponent<Text>().color = Color.white;
			pauseMenu.SetActive(true);
		}
	}

	#endregion

	#region My Functions

	/// <summary>
	/// Sets the pieces for each team that need to be taken in order\
	/// to win the game
	/// </summary>
	public void SetWinPieces()
	{
		BlackNinja = board.BlackPieces[11];
		BlackKunoichi = board.BlackPieces[12];

		WhiteNinja = board.WhitePieces[3];
		WhiteKunoichi = board.WhitePieces[4];
	}

	#endregion
}
