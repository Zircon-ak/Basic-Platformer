using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	public int health;
	public Animator anim;
	public Rigidbody2D r2d;

	public virtual void Init(int _health){
		health = _health;
		anim = GetComponent<Animator>();
		r2d = GetComponent<Rigidbody2D>();
	}

	public bool IsDead(){
		if( health <= 0 ) {
			Destroy(this.gameObject);
			return true;
		} else return false;
	}

	public void SubtractHealth(int value){
		health -= value;
		IsDead();
	}
}
