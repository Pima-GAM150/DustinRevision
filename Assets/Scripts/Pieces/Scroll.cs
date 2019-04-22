using UnityEngine;
using UnityEngine.Dustin;

public class Scroll : ChessPieceBase
{
	#region Variables
	
	
	
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
        
	}

	#endregion

	#region My Functions

	public override bool Move(Transform target)
	{
		base.Move(target);

		if (target.position.x + transform.position.x == target.position.y + transform.position.y)
		{
			transform.position = target.position;

			//pieceSnap.Play();

			return true;
		}
		else
		{
			return false;
		}
	}

	public override bool Attack(Transform target)
	{
		base.Attack(target);

		return true;
	}

	public override void Death()
	{

	}

	#endregion
}
