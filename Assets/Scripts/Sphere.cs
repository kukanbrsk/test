using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour
{
    [SerializeField]private float speed = 2;
    [SerializeField] SphereCollider sphereCollider;

    private Vector3 start;
    private float time;

    public AnimationCurve curve;
    public Vector3 end;

    void Update()
    {
        start = transform.position;
        time = Time.deltaTime * speed;
        Vector3 pos = Vector3.Lerp(start, PlayerController.touchPos, time);
        pos.y -= curve.Evaluate(time);
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Delay());
        if (collision.collider.TryGetComponent(out MoveController cube))
        {
            SpawnCube.deathCube?.Invoke();
            Destroy(cube.gameObject);
        }
    }

    private IEnumerator Delay()
    {
        sphereCollider.radius *= 1.2f;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
