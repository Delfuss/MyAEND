using UnityEngine;

public class Model : IPlayerStats
{
    private float _baseVelocity = 5f;
    private float _baseJumpForce = 4f;

    public float Velocity { get; private set; }
    public float JumpForce { get; private set; }

    public bool Jump { get; set; }
    public float Xaxi { get; set; }
    public float Yaxi { get; set; }

    private int _life = 4;
    private bool _grounded = true;

    public int Life => _life;
    public bool Grounded => _grounded;

    public Model()
    {
        ResetStats();
    }

    public void ResetStats()
    {
        Velocity = _baseVelocity;
        JumpForce = _baseJumpForce;
    }
    public void ApplyStats(float velocity, float jumpForce)
    {
        Velocity = velocity;
        JumpForce = jumpForce;
    }

    public void SetGrounded(bool value)
    {
        _grounded = value;
    }

    public void SetLife(int value)
    {
        _life -= value;
        if (_life < 0) _life = 0;
    }
}
