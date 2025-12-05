using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    public List<Cube> GetObjectsSpawn(Cube cubeClicked)
    {
        List<Cube> cubes = new List<Cube>();

        int minRange = 2;
        int maxRange = 6;

        int amountCubes = Random.Range(minRange, maxRange + 1);

        for (int i = 0; i < amountCubes; i++)
        {
            Cube cube = Instantiate(_cube, cubeClicked.transform.position, Quaternion.identity);

            Vector3 scale = GetScale(cubeClicked);
            Color color = GetRandomColor();
            int numberReduce = 2;
            int chanceDivision = cubeClicked.ChanceDivision / numberReduce;

            cube.Initialize(scale, color, chanceDivision);
            cubes.Add(cube);
        }

        return cubes;
    }

    public void DestroyCube(Cube cube) =>
        Destroy(cube.gameObject);

    private Vector3 GetScale(Cube cube)
    {
        var scale = cube.transform.localScale;

        int numberReduction = 2;

        scale.x /= numberReduction;
        scale.y /= numberReduction;
        scale.z /= numberReduction;

        return scale;
    }

    private Color GetRandomColor() =>
        Random.ColorHSV();
}
