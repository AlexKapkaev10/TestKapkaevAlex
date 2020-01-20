using UnityEngine;


public class MovePlatform : MonoBehaviour
{
    
    private Camera cam; // камера вращения
    private Rigidbody rg; // компонент для реальзации передвижения платформы

    [SerializeField]
    private GameObject weapon; // ссылка на оружие для реальзации вращения по оси Y

    private Vector3 velocity = Vector3.zero; 
    private Vector3 rotationX = Vector3.zero; // нулевые вектора, передаются из скрипта Platform.cs
    private Vector3 rotationY = Vector3.zero;

    private void Start()
    {
        rg = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    //получение вектров и скорости движения платформы
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //получение вектора вращения по оси X
    public void RotateX(Vector3 _rotation)
    {
        rotationX = _rotation;
    }

    //получение вектора вращения по оси Y
    public void RotateY(Vector3 _rotationY)
    {
        rotationY = _rotationY;
    }

    private void FixedUpdate()
    {
        PerformMove(); // реализация движения
        PerformRotation(); // реализация вращения
    }

    void PerformMove()
    {
        if (velocity != Vector3.zero)
            rg.MovePosition(rg.position + velocity * Time.fixedDeltaTime);
    }

    void PerformRotation()
    {
        //вращение платформы по оси X
        rg.MoveRotation(rg.rotation * Quaternion.Euler(rotationX));

        //отдельно, от платформы, вращаю оружие и камеру по оси Y
        if(weapon != null)
            weapon.transform.Rotate(-rotationY);

        if (cam != null)
            cam.transform.Rotate(-rotationY);
    }
}
