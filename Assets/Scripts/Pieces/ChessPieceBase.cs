using UnityEngine;

public class ChessPieceBase : MonoBehaviour
{
	#region Variables

	public Transform MoveTarget;

	public PieceType MyType;

	#endregion

	#region Unity Functions

	#endregion

	#region My Functions

	public virtual void Move() { }

	public virtual void Attack() { }

	public virtual void Death() { }
	
	#endregion
}

namespace UnityEngine
{
	public enum PieceType
	{
		Ninja,
		Kunoichi,
		Katana,
		Caltrops,
		Scroll,
		Kunai,
		Shuriken
	}
	public enum PieceColor
	{
		Black,
		White
	}
}