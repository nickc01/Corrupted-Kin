using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Interfaces;

public abstract class CorruptedKinMove : MonoBehaviour, IBossMove
{
	[SerializeField]
	[Tooltip("If set to true, this move can be executed via Corrupted Kin's move randomizer")]
	protected bool doMoveInRandomizer;

	public bool DoMoveInRandomizer { get { return doMoveInRandomizer; } }

	CorruptedKin _kin;
	public CorruptedKin Kin
	{
		get
		{
			if (_kin == null)
			{
				_kin = GetComponent<CorruptedKin>();
			}
			return _kin;
		}
	}

	//This is to make the enable/disable button visible in the inspector
	protected virtual void Start()
	{

	}

	public WeaverAnimationPlayer Animator { get { return Kin.Animator; } }
	public SpriteRenderer Renderer { get { return Kin.Renderer; } }
	public Rigidbody2D Rigidbody { get { return Kin.Rigidbody; } }
	public AudioPlayer AudioPlayer { get { return Kin.AudioPlayer; } }
	public CorruptedKinHealth HealthManager { get { return Kin.HealthManager; } }
	public Collider2D Collider { get { return Kin.Collider; } }
	public WeaverCore.Components.DamageHero Damager { get { return Kin.Damager; } }

	public virtual bool MoveEnabled
	{
		get
		{
			return enabled;
		}
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
}

