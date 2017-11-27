﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Monster : NetworkBehaviour
{
	#region Fields
	public bool isAttacking;
	float attackTimer;
	public float attackMaxTime;

	public bool canAttack;
	public float attackRechargeTimer;
	public float attackRechargeMaxTime;
	#endregion

	void Start()
	{
		gameObject.SetActive (false);
	}

	void Update()
	{
		if (isLocalPlayer)
		{
			return;
		}

		if (isAttacking && attackTimer > 0f)
		{
			attackTimer -= Time.deltaTime;
			if (attackTimer <= 0f)
			{
				FinishAttack ();
				attackTimer = 0f;
			}
		}
	}

	public void Attack(Vector3 position)
	{
		if (canAttack) 
		{
			gameObject.SetActive (true);
			isAttacking = true;
			transform.position = position;
			attackTimer = attackMaxTime;

			canAttack = false;
		}
	}

	void FinishAttack()
	{
		gameObject.SetActive (false);
		isAttacking = false;
		canAttack = true;
		attackTimer = attackMaxTime;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			//FinishAttack ();

			//Down player
		}
	}
}
