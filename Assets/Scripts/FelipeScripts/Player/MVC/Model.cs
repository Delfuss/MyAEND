public class Model : IPlayerStats
{
    public float Velocity { get; private set; } = 5f;
    public float JumpForce { get; private set; } = 4f;
    public bool Jump { get; set; } = false;
    public float Xaxi { get; set; } = 5f;

    private int _life = 4;
    private bool _grounded = true;

    public bool PlaySound { get; set; }

    public int Life
    {
        get { return _life; }
    }

    public bool Grounded
    {
        get { return _grounded; }
    }

    public void SetGrounded(bool value)
    {
        _grounded = value;
    }

    public void SetLife(int value)
    {
        _life -= value;
        if (_life < 0)
        {
            _life = 0;
        }
    }
}
