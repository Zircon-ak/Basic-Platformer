using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

	public int damage;
	public IShooter owner;

	public abstract void OnHitWith(Character obj);
	public abstract void Move();

	public void Init(int _damage, IShooter _owner){
		damage = _damage;
		owner = _owner;
	}
	void OnTriggerEnter2D(Collider2D other) {
		OnHitWith( other.GetComponent<Character>() );
		Destroy(this.gameObject);
	}
	public int GetShootDirection(){
		float value = owner.Spawner.position.x - owner.Spawner.parent.position.x;
		if( value > 0 )
			return 1; // right direction
		else return -1; // left direction
	}
}
