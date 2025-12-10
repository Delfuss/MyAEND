using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerWalls : IMechanism
{
    private ModelWalls _model;

    private ViewWalls _view;

    public ControllerWalls(ModelWalls model, ViewWalls view)
    { 
      _model = model;
      _view = view;
    
    }
  
    public void Mechanism()
    {
        _view.PlaySound();
        _view.PlayAnimation();
        EventsTypes.InvokeEvent(EventStrings.PlayerDamage);
    }
}
