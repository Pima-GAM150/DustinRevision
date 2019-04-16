using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	#region Variables

	public static UIController Instance;

	[SerializeField]
	private bool paused;

	public GameObject PauseMenu;
	
	#endregion
	
	#region Unity Functions
	
	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		paused = false;
	}

	private void Update()
	{
		PauseInputCheck();
	}

	#endregion

	#region My Functions

	public void MainMenu()
	{
		if (Time.timeScale != 1)
		{
			Time.timeScale = 1;
		}

		SceneManager.LoadScene("MainMenu");
	}

	public void LoadGame()
	{
		SceneManager.LoadScene("GameEnvironment");
	}

	private void PauseInputCheck()
	{
		if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && !paused)
		{
			Pause();
		}
		else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && paused)
		{
			Resume();
		}
	}

	public void ResetBoard()
	{
		Board.Instance.ResetBoard();
	}

	public void Pause()
	{
		PauseMenu.SetActive(true);
		paused = true;
		Debug.Log("Pause");
		Time.timeScale = .01f;
	}

	public void Resume()
	{
		PauseMenu.SetActive(false);
		paused = false;
		Debug.Log("Resume");
		Time.timeScale = 1;
	}

	public void Quit()
	{

		#if UNITY_EDITOR

			UnityEditor.EditorApplication.isPlaying = false;

		#else
                Application.Quit();
		#endif

	}

	#endregion
}




