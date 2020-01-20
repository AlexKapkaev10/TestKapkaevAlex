using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab; // пуля

    [SerializeField]
    private Transform firePoint; // точка создания пули

    [SerializeField]
    private Image[] crossLines; // массив с линиями крестика прицела

    public float shotPower; // сила выстрела

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Ray.instance.findTarget != false)
        {
            PerformShot();
        }

        AimColor();
    }
    // реализация выстрела
    void PerformShot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shotPower, ForceMode.Impulse);
    }
    //изменение цвета прицела
    void AimColor()
    {
        if (Ray.instance.findTarget != false)
        {
            foreach (Image line in crossLines)
            {
                line.color = Color.green;
            }
        }
        else
        {
            foreach (Image line in crossLines)
            {
                line.color = Color.red;
            }
        }
    }
}
