using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;

    private void OnEnable() =>
        _raycaster.Raycasted += Raycast;

    private void OnDisable() =>
        _raycaster.Raycasted -= Raycast;

    private void Raycast(Cube cube)
    {
        if (CanSplit(cube.ChanceDivision))
        {
            _spawner.GetObjectsSpawn(cube);
            _explosion.Push(cube);
        }

        _spawner.DestroyCube(cube);
    }

    private bool CanSplit(int chancePercent)
    {
        int percent = 100;

        int randomChance = Random.Range(0, percent + 1);

        return randomChance <= chancePercent;
    }
}
