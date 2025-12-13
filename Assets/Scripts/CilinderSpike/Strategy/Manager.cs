using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private ChangeStrategy changeStrategy;
    [SerializeField] private SpikeStrategy spike;
    [SerializeField] private Transform spikeTransform;

    private void Awake()
    {
        // Creamos las estrategias fuera de ChangeStrategy
        MoveStrategy[] strategies = new MoveStrategy[]
        {
            new PointToPointMovement(spikeTransform, 1f),
            new StaticMovement(spikeTransform, 200f)
        };

        // Inyectamos las estrategias y el SpikeStrategy
        changeStrategy.Initialize(spike, strategies, 2f);
    }
}
