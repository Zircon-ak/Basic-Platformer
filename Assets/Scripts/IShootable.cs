using UnityEngine;

public interface IShooter {

	Transform Spawner{ get; set; }
	GameObject Bullet{ get; set; }
	float ReloadTime{ get; set; }
	float WaitTime{ get; set; }
	void Shoot();
}
