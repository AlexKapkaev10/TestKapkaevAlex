using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float speed; // скорость пердвижения платформы

    [SerializeField]
    private float rotationSpeed; // чувствительность вращения

    private MovePlatform movePlatform; // скрипт с реализацией движения и вращения 


    void Start()
    {
        movePlatform = GetComponent<MovePlatform>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); 
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 directionHorizontal = transform.right * xMove;
        Vector3 directionVertical = transform.forward * zMove;
        Vector3 velocity = (directionHorizontal + directionVertical).normalized * speed;
        movePlatform.Move(velocity);

        float yRotation = Input.GetAxis("Mouse X");
        float xRotation = Input.GetAxis("Mouse Y");

        Vector3 rotationX = new Vector3(0f, yRotation, 0f) * rotationSpeed;
        movePlatform.RotateX(rotationX);

        Vector3 rotationY = new Vector3(xRotation, 0f, 0f) * rotationSpeed;
        movePlatform.RotateY(rotationY);
    }
}
