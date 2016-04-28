using UnityEngine;
using System.Collections;

public abstract class Enemy : Character {

	public int damageHit;
	public abstract void Behaviour();
}
