using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceBase : MonoBehaviour
{
	#region Variables

	public Animator MyAnimationController;

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
		King,
		Queen,
		Bishop,
		Knight,
		Rook,
		Pawn
	}
}