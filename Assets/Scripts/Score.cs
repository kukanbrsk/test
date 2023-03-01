using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI _invoiceDisplay;

    void Start()
    {
        SpawnCube.deathCube += AddPoints;
        _invoiceDisplay.text = (_score).ToString();
    }

    private void AddPoints()
    {
        _score++;
        _invoiceDisplay.text = (_score).ToString();
    }
}
