using UnityEngine;
using UnityEngine.Dustin;

public class Caltrops : ChessPieceBase
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

		return true;
	}

	public override bool Attack(Transform target)
	{
		base.Move(target);

		return true;
	}

	public override void Death()
	{
		
	}

	#endregion
}
