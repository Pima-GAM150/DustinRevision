using UnityEngine;
using UnityEngine.Dustin;

public class GirlNinja : ChessPieceBase
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

	/// <summary>
	/// 
	/// </summary>
	/// <param name="target"></param>
	/// <returns></returns>
	public override bool Move(Transform target)
	{
		base.Move(target);

		if ((transform.localPosition.x + 1 == target.localPosition.x && transform.localPosition.z + 2 == target.localPosition.z)
		 || (transform.localPosition.x + 1 == target.localPosition.x && transform.localPosition.z - 2 == target.localPosition.z)
		 || (transform.localPosition.x - 1 == target.localPosition.x && transform.localPosition.z + 2 == target.localPosition.z)
		 || (transform.localPosition.x - 1 == target.localPosition.x && transform.localPosition.z - 2 == target.localPosition.z)
		 || (transform.localPosition.x + 2 == target.localPosition.x && transform.localPosition.z + 2 == target.localPosition.z)
		 || (transform.localPosition.x + 2 == target.localPosition.x && transform.localPosition.z - 2 == target.localPosition.z)
		 || (transform.localPosition.x - 2 == target.localPosition.x && transform.localPosition.z + 2 == target.localPosition.z)
		 || (transform.localPosition.x - 2 == target.localPosition.x && transform.localPosition.z - 2 == target.localPosition.z))
		{
			transform.localPosition = new Vector3(target.localPosition.x, transform.localPosition.y, target.localPosition.z);

			return true;
		}

		return false;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="target"></param>
	/// <returns></returns>
	public override bool Attack(Transform target)
	{
		base.Move(target);

		if ((transform.localPosition.x == target.localPosition.x && transform.localPosition.z + 1 == target.localPosition.z)
		 || (transform.localPosition.x == target.localPosition.x && transform.localPosition.z - 1 == target.localPosition.z))
		{
			transform.localPosition = new Vector3(target.localPosition.x, transform.localPosition.y, target.localPosition.z);

			target.GetComponentInParent<ChessPieceBase>().Death();

			return true;
		}

		return false;
	}

	/// <summary>
	/// 
	/// </summary>
	public override void Death()
	{
		base.Death();
	}

	/// <summary>
	/// 
	/// </summary>
	public override void HighlightMoves()
	{

	}

	#endregion
}
