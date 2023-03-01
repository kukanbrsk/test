using System.Collections;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Vector3 _target;
    [SerializeField] private float speed;
    [SerializeField] private float speedRotate;

    void Start()
    {
        StartCoroutine(Acceleration());
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_target), speedRotate * Time.deltaTime);
        if (transform.position == _target)
        {
            _target = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 _getRandomPosition;
        _getRandomPosition.y = 0f;
        _getRandomPosition.x = Random.Range(-4f, 4f);
        _getRandomPosition.z = Random.Range(-4f, 4f);
        return _getRandomPosition;
    }

    IEnumerator Acceleration()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 6));
            speed = 8;
            yield return new WaitForSeconds(0.4f);
            speed = 2;
        }
    }
}
