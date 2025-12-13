using System.Collections;
using UnityEngine;

public class ChangeStrategy : MonoBehaviour
{
    [SerializeField] SpikeStrategy spikeStrategy;
    [SerializeField] float changeTime = 2f;

    MoveStrategy[] _strategies;
    int _currentIndex;

    private void Awake()
    {
        _strategies = new MoveStrategy[]
        {
            new PointToPointMovement(transform, 1f),
            new StaticMovement(transform, 200f)
        };
    }

    private void Start()
    {
        StartCoroutine(ChangeLoop());
    }

    private IEnumerator ChangeLoop()
    {
        while (true)
        {
            spikeStrategy.SetStrategy(_strategies[_currentIndex]);
            _currentIndex = (_currentIndex + 1) % _strategies.Length;
            yield return new WaitForSeconds(changeTime);
        }
    }
}
