using UnityEngine;

public class Collision : MonoBehaviour
{
    //перечисление объектов
    public enum Type
    {
        bullet,
        enemy,
    }

    [SerializeField]
    private GameObject destroyEffect; // еффект разрущения противника

    Transform currentPosEnemy; // позиция текущего врага

    public Type myType; // переменная перечесления объектов

    [SerializeField]
    private float destroyBullet; // время уничтожения пули, если она не попала во врага

    private void Update()
    {
        //уничтожение пули если она не попала во врага
        if(myType == Type.bullet)
        {
            Destroy(gameObject, destroyBullet);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //уничтожение пули при попадании во врага
        if (other.gameObject.GetComponent<Collision>().myType == Type.enemy)
        {
            Destroy(gameObject);
        }
        //реализация уничтожения врага и эффекта
        if (other.gameObject.GetComponent<Collision>().myType == Type.bullet)
        {
            currentPosEnemy = gameObject.transform; // просвоение позиции текущего врага, в которого попали
            GameObject thisEffect = Instantiate(destroyEffect, currentPosEnemy.position, Quaternion.identity); // создание еффекта разрушения
            Destroy(gameObject); // уничтожение текущего врага
            Destroy(thisEffect, 1); // удаление текущего еффекта со сцены
            currentPosEnemy = null; // обнеление позиции текущего врага
        }


    }
}
