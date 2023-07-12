using UnityEngine;
using System;
using System.Collections.Generic;

public class Weapon : Outfit
{
    public Weapon(string name, string descritpion, int quantity, int projectileSpeed, string projectileSprite, int weaponDamage, string projectileType, Vector2 barrelTip) : base(name, descritpion, quantity)
    {
        ProjectileSpeed = projectileSpeed;
        ProjectileSprite = projectileSprite;
        WeaponDamage = weaponDamage;
        BarrelTip = barrelTip;
        ProjectileType = projectileType;
    }

    public int ProjectileSpeed { get; }
    public string ProjectileType { get; }
    public string ProjectileSprite { get; }
    public int WeaponDamage { get; }
    public Vector2 BarrelTip { get; set; }

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
        }
    }
}
