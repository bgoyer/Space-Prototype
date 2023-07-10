using UnityEngine;
using System;
using System.Collections.Generic;

public class Weapon : Outfit
{
    public Weapon(string name, string descritpion, int quantity, int projectileSpeed, string projectileSprite, int weaponDamage, Vector2 barrelTip) : base(name, descritpion, quantity)
    {
        ProjectileSpeed = projectileSpeed;
        ProjectileSprite = projectileSprite;
        WeaponDamage = weaponDamage;
        BarrelTip = barrelTip;
    }

    public int ProjectileSpeed { get;set; }
    public string ProjectileSprite { get; set; }
    public int WeaponDamage { get; set; }
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
