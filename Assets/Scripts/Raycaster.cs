using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private RaycastHit _hit;

    public event Action<Cube> Raycasted;

    public void PressRaycast()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
        {
            if (_hit.transform.TryGetComponent(out Cube cube))
            {
                Raycasted?.Invoke(cube);
            }
        }
    }
}
