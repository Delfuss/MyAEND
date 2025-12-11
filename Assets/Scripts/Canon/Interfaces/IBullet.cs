using UnityEngine;

public interface IBullet
{
    Transform Transform { get; }
    void Activate();
    void Deactivate();
}
