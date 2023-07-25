using UnityEngine;


public class MovePoint : MonoBehaviour
{
    public float levitationHeight = 2f; // Высота, на которую объект будет подниматься
    public float levitationSpeed = 2f; // Скорость подъема и опускания объекта
    public Vector3 startPosition;
    public Transform pointer;

    private void Start()
    {
        startPosition = pointer.position; // Запоминаем начальную позицию объекта
    }

    private void Update()
    {
        // Поднимаем и опускаем объект по оси Y МОЖЕТ СДЕЛАТЬ ЧЕРЕЗ АНИМАЦИИ?
        //pointer.position = new Vector3(startPosition.x, startPosition.y + Mathf.Sin(Time.time * levitationSpeed) * levitationHeight, transform.position.z);
        transform.position = startPosition;
    }
}