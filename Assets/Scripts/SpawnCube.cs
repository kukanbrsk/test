using UnityEngine;
using System;
public class SpawnCube : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    public static Action deathCube;

    void Start()
    {
        deathCube += SCube;
    }

    private void SCube()
    {
        Invoke(nameof(AddCube), UnityEngine.Random.Range(1, 3));
    }
    private void AddCube()
    {
        Instantiate(cubePrefab);
    }
}
