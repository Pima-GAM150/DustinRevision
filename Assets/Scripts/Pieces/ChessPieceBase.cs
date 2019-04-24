using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Dustin;

public class ChessPieceBase : MonoBehaviour
{
	#region Variables

	public MoveEvent IMoved;

	public Transform MoveTarget;

	public Animator AnimationController;

	public AudioSource PieceSnap;

	public PieceType MyType;

	public PieceColor MyColor;

	#endregion

	#region Unity Functions

	#endregion

	#region My Functions

	public virtual bool Move(Transform target)
	{
		Debug.LogFormat("Name:{0} Color:{1} Type:{2}\n",this.name,this.MyColor,this.MyType);

		PieceSnap.Play();

		return true;
	}

	public virtual bool Attack(Transform target)
	{
		Debug.LogFormat("Name:{0} Pos:{1}", target.name, target.position);

		PieceSnap.Play();

		return true;
	}

	public virtual void Death()
	{

		Debug.LogFormat("Name:{0} Color:{1} Type:{2}\n", this.name, this.MyColor, this.MyType);

		Board.Instance.RemovePiece(this.gameObject);

		Destroy(this.gameObject);
		
	}

	public virtual void HighlightMoves()
	{

	}

	#endregion
}

namespace UnityEngine.Dustin
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

	[System.Serializable]
	public class MoveEvent : Events.UnityEvent
	{

	}
}