using System;
using UI;
using UnityEngine;
using Zenject;

namespace Controls
{

    public class ClickController: ITickable, IInitializable
{

    public event Action<Vector3> OnClickNotUIRestreactAreaReturnWorldCoordinateEvent;
    public event Action<Vector3> OnClickReturnScreenCoordinateEvent;
    private BlockerRaycastForUI _blockerRaycastForUI;
    private Camera _camera;

    [Inject]
    public ClickController(BlockerRaycastForUI blockerRaycastForUIArg)
    {
        _blockerRaycastForUI = blockerRaycastForUIArg;
    }
    
    public void Initialize()
    {
        _camera = Camera.main;
    }
    
    public void Tick()
    {
        ClickOnScreen();  
    }
    
    
    public void ClickOnScreen()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        
        Vector2 clickPosition = Input.mousePosition;
        OnClickReturnScreenCoordinateEvent?.Invoke(clickPosition);
            
        
        Ray ray = _camera.ScreenPointToRay(clickPosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);
        plane.Raycast(ray, out var distance);
        Vector3 pointForAim = ray.GetPoint(distance);
        
        if (!_blockerRaycastForUI.CheckThisIsItRestrectArea(clickPosition))
        {
            OnClickNotUIRestreactAreaReturnWorldCoordinateEvent?.Invoke(pointForAim);
        }
       
    }
}
    

 
}