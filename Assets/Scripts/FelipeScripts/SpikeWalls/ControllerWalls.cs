public class ControllerWalls
{
    private readonly IActive _model;
    private readonly ViewWalls _view;

    public ControllerWalls(IActive model, ViewWalls view)
    {
        _model = model;
        _view = view;
    }

    public void Execute()
    {
        if (!_model.IsActive)
            return;

        _view.PlayFeedback();
    }
}
