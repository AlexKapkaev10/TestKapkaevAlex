using UnityEngine;

public class Ray : MonoBehaviour
{

    public static Ray instance; // статическая переменная скрипта Ray.cs

    [SerializeField]
    private float distance = 100f; // дальность луча

    private RaycastHit hitTarget; // цель

    [SerializeField]
    private Transform target; // позиция цели найденная лучем

    public bool findTarget; // цель найдена

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        CheckTarget();
    }
    //реализация поиска цели лучем
    void CheckTarget()
    {
        target = null;

        if(Physics.Raycast(transform.position, transform.forward, out hitTarget, distance))
        {
            target = hitTarget.transform.GetComponent<Transform>();
        }
        if(target != null)
        {
            findTarget = true;
        }
        else
        {
            findTarget = false;
        }
    }

}
