using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public List<GameObject> weaponsList;

    private void Start()
    {
        foreach (GameObject weapon in weaponsList)
        {
            if (weapon != null)
            {
                weapon.SetActive(false);
            }
        }
    }

    public void ChangeWeapon(string nameToActivate)
    {
        foreach (GameObject weapon in weaponsList)
        {
            if (nameToActivate.Contains(weapon.gameObject.name))
            {
                weapon.GetComponent<Rigidbody>().isKinematic = true;
                weapon.SetActive(true);
            }
            else
            {
                weapon.SetActive(false);
            }
        }
    }
}
