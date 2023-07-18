using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Player player;
    public WeaponHolder holder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            holder.ChangeWeapon(other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
