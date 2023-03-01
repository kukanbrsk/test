using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Camera cam;
    private Vector3 pos = new Vector3(0, 8.82f, -17f);
    public static Vector3 touchPos;
    [SerializeField] private UImanager _uIManager;

    private bool canDoAction = true;

    [SerializeField] private GameObject spherePrefab;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canDoAction == true)
        {
            RaycastHit hit;
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(hit.point, pos, Color.red);
                Debug.Log(hit.point);
                touchPos = hit.point;
            }

            Instantiate(spherePrefab, pos, Quaternion.identity);
            _uIManager.RemoveTheBall();

            StartCoroutine(ICooldown());
        }
    }
    private IEnumerator ICooldown()
    {
        canDoAction = false;
        yield return new WaitForSeconds(0.5f);
        canDoAction = true;
    }
}
