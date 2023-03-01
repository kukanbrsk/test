using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{
    [SerializeField] private Transform spherePanel;
    [SerializeField] private Image circle;
    [SerializeField] private List<Image> circles = new List<Image>();
    private Coroutine delay;

    private int lastIndex = 5;
    private int _ballCounter;


    [SerializeField] private Timer timer;
    void Start()
    {
        timer.getBall += AddBalls;
        for (int i = 0; i < lastIndex; i++)
        {
            circles.Add(Instantiate(circle, spherePanel));
        }
    }

    public void RemoveTheBall()
    {
        circles[lastIndex-1].gameObject.SetActive(false);
        lastIndex -= 1;
        if (delay == null|| _ballCounter>1)
        {
           delay =  StartCoroutine(timer.StartTimer());
        }
        else
        {
            _ballCounter++;
        }
    }
    public void AddBalls()
    {
        circles[lastIndex].gameObject.SetActive(true);
        lastIndex++;
        if (lastIndex > 4)
        {
            return;
        }
         StartCoroutine(timer.StartTimer());
    }
}
