using UnityEngine;
using System.Collections;

// An example on how to make a gun.
public class GrenadeLauncher : Gun {
  //  public Gun(string name, float damage, float critical, int clipSize, bool projectile, float fireRate, float reloadTime)	
    public GrenadeLauncher() : base("Grenade Launcher", 10f, 20f, 5, true, 1f, 5f) { }



    // Note: You can usethe Update method.
    public override void Shoot() {
        // Launch Projectile
    }
}