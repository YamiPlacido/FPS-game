using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    private int currentWeaponNo;
    private Animator _anim;

    void Start()
    {
        currentWeaponNo = 0;
        weapons[currentWeaponNo].gameObject.SetActive(true);
        _anim = weapons[currentWeaponNo].gameObject.GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(0);          
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeapon(2);
        }
    }

    private void ChangeWeapon(int weaponNo)
    {
        weapons[currentWeaponNo].gameObject.SetActive(false);
        weapons[weaponNo].gameObject.SetActive(true);
        currentWeaponNo = weaponNo;
        _anim.SetTrigger("Draw");
    }
}
