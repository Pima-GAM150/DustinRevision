using UnityEngine;
using UnityEngine.Dustin;

public class Ninja : ChessPieceBase
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

		var enemies = (MyColor.ToString().CompareTo("Black") == 0) ? Board.Instance.BlackPieces : Board.Instance.WhitePieces;

		var friends = (MyColor.ToString().CompareTo("Black") == 0) ? Board.Instance.WhitePieces : Board.Instance.BlackPieces;

		if (((transform.localPosition.x + 1 == target.localPosition.x && transform.localPosition.z + 1 == target.localPosition.z)
		 || (transform.localPosition.x + 1 == target.localPosition.x && transform.localPosition.z - 1 == target.localPosition.z)
		 || (transform.localPosition.x - 1 == target.localPosition.x && transform.localPosition.z + 1 == target.localPosition.z)
		 || (transform.localPosition.x - 1 == target.localPosition.x && transform.localPosition.z - 1 == target.localPosition.z)
		 || (transform.localPosition.x == target.localPosition.x && transform.localPosition.z + 1 == target.localPosition.z)
		 || (transform.localPosition.x == target.localPosition.x && transform.localPosition.z - 1 == target.localPosition.z)
		 || (transform.localPosition.x + 1 == target.localPosition.x && transform.localPosition.z == target.localPosition.z)
		 || (transform.localPosition.x - 1 == target.localPosition.x && transform.localPosition.z == target.localPosition.z)))
		{
			foreach (GameObject friend in friends)
			{
				if (friend.transform.localPosition.x == target.localPosition.x
					&& friend.transform.localPosition.z == target.localPosition.z)
				{
					return false;
				}
			}
			foreach (GameObject enemy in enemies)
			{
				if (((transform.localPosition.x + 2 == enemy.transform.localPosition.x && target.localPosition.z + 2 == enemy.transform.localPosition.z)
				 ||  target.localPosition.x + 2 == enemy.transform.localPosition.x && target.localPosition.z - 2 == enemy.transform.localPosition.z)
				 ||  target.localPosition.x - 2 == enemy.transform.localPosition.x && target.localPosition.z + 2 == enemy.transform.localPosition.z)
				 ||  target.localPosition.x - 2 == enemy.transform.localPosition.x && target.localPosition.z - 2 == enemy.transform.localPosition.z)))
				{
					if (enemy.transform.localPosition.x == target.localPosition.x
					  && enemy.transform.localPosition.z == target.localPosition.z)
					{
						return false;
					}
				}
			}

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

		if ((transform.localPosition.x + 2 == target.localPosition.x && transform.localPosition.z + 2 == target.localPosition.z)
		 || (transform.localPosition.x + 2 == target.localPosition.x && transform.localPosition.z - 2 == target.localPosition.z)
		 || (transform.localPosition.x - 2 == target.localPosition.x && transform.localPosition.z + 2 == target.localPosition.z)
		 || (transform.localPosition.x - 2 == target.localPosition.x && transform.localPosition.z - 2 == target.localPosition.z))
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
		var enemies = (MyColor.ToString().CompareTo("Black") == 0) ? Board.Instance.BlackPieces : Board.Instance.WhitePieces;

		var friends = (MyColor.ToString().CompareTo("Black") == 0) ? Board.Instance.WhitePieces : Board.Instance.BlackPieces;

		if (MyColor.ToString().CompareTo("Black") == 0)
		{
			foreach (GameObject space in Board.Instance.Spaces)
			{
				if (((transform.localPosition.x + 1 == space.transform.localPosition.x && transform.localPosition.z + 1 == space.transform.localPosition.z)
					 || (transform.localPosition.x + 1 == space.transform.localPosition.x && transform.localPosition.z - 1 == space.transform.localPosition.z)
					 || (transform.localPosition.x - 1 == space.transform.localPosition.x && transform.localPosition.z + 1 == space.transform.localPosition.z)
					 || (transform.localPosition.x - 1 == space.transform.localPosition.x && transform.localPosition.z - 1 == space.transform.localPosition.z)
					 || (transform.localPosition.x == space.transform.localPosition.x && transform.localPosition.z + 1 == space.transform.localPosition.z)
					 || (transform.localPosition.x == space.transform.localPosition.x && transform.localPosition.z - 1 == space.transform.localPosition.z)
					 || (transform.localPosition.x + 1 == space.transform.localPosition.x && transform.localPosition.z == space.transform.localPosition.z)
					 || (transform.localPosition.x - 1 == space.transform.localPosition.x && transform.localPosition.z == space.transform.localPosition.z)))
				{
					space.GetComponentInChildren<ParticleSystem>().Play();

					foreach (GameObject friend in friends)
					{
						if (friend.transform.localPosition.x == space.transform.localPosition.x
							&& friend.transform.localPosition.z == space.transform.localPosition.z)
						{
							space.GetComponentInChildren<ParticleSystem>().Stop();
						}
					}
					foreach (GameObject enemy in enemies)
					{
						if (((transform.localPosition.x + 2 == enemy.transform.localPosition.x && transform.localPosition.z + 2 == enemy.transform.localPosition.z)
						 || (transform.localPosition.x + 2 == enemy.transform.localPosition.x && transform.localPosition.z - 2 == enemy.transform.localPosition.z)
						 || (transform.localPosition.x - 2 == enemy.transform.localPosition.x && transform.localPosition.z + 2 == enemy.transform.localPosition.z)
						 || (transform.localPosition.x - 2 == enemy.transform.localPosition.x && transform.localPosition.z - 2 == enemy.transform.localPosition.z)))
						{
							if (enemy.transform.localPosition.x == space.transform.localPosition.x
							  && enemy.transform.localPosition.z == space.transform.localPosition.z)
							{
								space.GetComponentInChildren<ParticleSystem>().Play();
							}
						}
					}
				}
			}
		}
	}

	#endregion
}
