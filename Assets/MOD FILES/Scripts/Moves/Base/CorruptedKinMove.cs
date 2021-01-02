using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Interfaces;

public abstract class CorruptedKinMove : IBossMove
{
	public enum AttackRangeType
	{
		Unspecified,
		CloseRange,
		LongRange,
		Overhead
	}


	public CorruptedKin Kin;

	//public IEnumerable<IBossMove> AllMoves { get { return Kin.AllMoves; } }
	public WeaverAnimationPlayer Animator { get { return Kin.Animator; } }
	public SpriteRenderer Renderer { get { return Kin.Renderer; } }
	public Rigidbody2D Rigidbody { get { return Kin.Rigidbody; } }
	public WeaverAudioPlayer AudioPlayer { get { return Kin.AudioPlayer; } }
	public CorruptedKinHealth HealthManager { get { return Kin.HealthManager; } }
	public Collider2D Collider { get { return Kin.Collider; } }
	public WeaverCore.Components.DamageHero Damager { get { return Kin.Damager; } }

	public Transform transform { get { return Kin.transform; } }
	public GameObject gameObject { get { return Kin.gameObject; } }

	public T GetMove<T>() where T : CorruptedKinMove
	{
		return Kin.GetMove<T>();
	}


	public virtual void OnMoveAwake() { }

	public abstract bool MoveEnabled
	{
		get;
	}

	public abstract bool ShowsUpInRandomizer
	{
		get;
	}

	public abstract IEnumerator DoMove();

	public virtual void OnCancel()
	{
		OnStun();
	}

	public virtual void OnDeath()
	{
		OnStun();
	}

	public virtual void OnStun()
	{
		
	}
	public abstract bool CanDoAttack();
}
