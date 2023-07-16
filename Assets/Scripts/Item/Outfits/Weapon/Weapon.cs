using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static UnityEditor.Rendering.CameraUI;

public class Weapon : Outfit
{
    public Weapon(string name, string descritpion, float reload, int quantity, string projectileSprite, string projectileType, Vector2 barrelTip) : base(name, descritpion, quantity)
    {
        ProjectileSprite = projectileSprite;
        BarrelTip = barrelTip;
        ProjectileType = projectileType;
        Reload = reload;
    }

    
    public string ProjectileType { get; }
    public string ProjectileSprite { get; }
    public Vector2 BarrelTip { get; set; }
    public float Reload { get; }

    private float nextShot = 0;

    public void Fire()
    {
        if (Time.timeSinceLevelLoad >= nextShot) 
        {
            nextShot = Time.timeSinceLevelLoad + Reload;
            Type projectileType = Type.GetType(ProjectileType);
            print(BarrelTip);
            if (projectileType != null && projectileType.IsSubclassOf(typeof(Projectile)))
            {
                GameObject _projectile = new();
                _projectile.transform.parent = transform;
                _projectile.AddComponent<Rigidbody2D>().gravityScale = 0;
                _projectile.transform.SetLocalPositionAndRotation(BarrelTip, transform.rotation);
                _projectile.AddComponent(projectileType);
                Sprite sprite = Resources.Load<Sprite>("Images/Textures/Projectiles/" + ProjectileSprite);
                if (!sprite)
                {
                    Debug.LogError("Sprite not found at path: " + "Images/Textures/Projectiles/" + ProjectileSprite);
                }
                else
                {
                    _projectile.AddComponent<SpriteRenderer>().sprite = sprite;
                    _projectile.AddComponent<PolygonCollider2D>().isTrigger = true;
                }
                
            }
        }
        
    }
    public static void Create(string weaponTypeString, GameObject ship)
    {
        Type weaponType = Type.GetType(weaponTypeString);
        if (weaponType != null && weaponType.IsSubclassOf(typeof(Weapon)))
        {
            Weapon weapon = (Weapon)ship.AddComponent(weaponType);
            foreach (var weaponSlot in ship.GetComponent<Ship>().WeaponSlots)
            {
                if (weaponSlot.Value == true)
                {
                    weapon.BarrelTip = weaponSlot.Key;
                    ship.GetComponent<Ship>().WeaponSlots[weaponSlot.Key] = false;
                    break;
                } 
            }
            Debug.LogWarning(ship.name + " doesnt have any free gun slots!");
        }
    }
}
