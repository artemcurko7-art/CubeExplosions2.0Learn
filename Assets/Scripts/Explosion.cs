using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Explosion : MonoBehaviour
{ 
    [SerializeField] private float _minRangeForce;
    [SerializeField] private float _maxRangeForce;
    [SerializeField] private float _minRangeRadius;
    [SerializeField] private float _maxRangeRadius;

    public void Push(Cube cubeClicked)
    {
        List<Rigidbody> cubes = GetRepulsiveCubes(cubeClicked);

        int percent = 100;

        for (int i = 0; i < cubes.Count; i++)
        {
            float force = Random.Range(_minRangeForce, _maxRangeForce + 1);
            float radius = Random.Range(_minRangeRadius, _maxRangeRadius + 1);

            var distance = (cubes[i].transform.position - cubeClicked.transform.position).normalized;

            int currentPercentRadius = 50;
            float scale = cubeClicked.transform.localScale.x;
            float currentForce = force / scale;
            float calculationForceRepulsion = radius / percent * currentPercentRadius + currentForce;

            cubes[i].AddForce(distance * calculationForceRepulsion, ForceMode.Impulse);
        }
    }

    private List<Rigidbody> GetRepulsiveCubes(Cube cubeClicked)
    {
        List<Rigidbody> cubes = new List<Rigidbody>();

        float radius = Random.Range(_minRangeRadius, _maxRangeRadius + 1);

        float scale = cubeClicked.transform.localScale.x;
        float currentRadius =  radius / scale;
        
        Collider[] hits = Physics.OverlapSphere(cubeClicked.transform.position, currentRadius);

        foreach (var hit in hits)
            if (hit.TryGetComponent<Cube>(out Cube cube))
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
