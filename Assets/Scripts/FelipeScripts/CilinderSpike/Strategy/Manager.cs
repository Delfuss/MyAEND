using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private ChangeStrategy changeStrategy;
    [SerializeField] private SpikeStrategy spike;
    [SerializeField] private Transform spikeTransform;

    private void Awake()
    {
        MoveStrategy[] strategies = new MoveStrategy[]
        {
            new PointToPointMovement(spikeTransform, 1f),
            new StaticMovement(spikeTransform, 200f)
        };

        changeStrategy.Initialize(spike, strategies, 2f);
    }
}
