using System.Collections;
using UnityEngine;

public class ChangeStrategy : MonoBehaviour
{
    private MoveStrategy[] _strategies;      // estrategias inyectadas
    private SpikeStrategy _spikeStrategy;    // Spike que ejecuta las estrategias
    private int _currentIndex = 0;
    private float _changeTime = 2f;

    public void Initialize(SpikeStrategy spikeStrategy, MoveStrategy[] strategies, float changeTime = 2f)
    {
        _spikeStrategy = spikeStrategy;
        _strategies = strategies;
        _changeTime = changeTime;

        StartCoroutine(ChangeLoop());
    }

    private IEnumerator ChangeLoop()
    {
        while (true)
        {
            if (_strategies != null && _strategies.Length > 0)
            {
                _spikeStrategy.SetStrategy(_strategies[_currentIndex]);

                // Rotación circular
                _currentIndex = (_currentIndex + 1) % _strategies.Length;
            }

            yield return new WaitForSeconds(_changeTime);
        }
    }
}

