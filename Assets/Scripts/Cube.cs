using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [field:SerializeField] public int ChanceDivision {  get; private set; }

    public Rigidbody Rigidbody { get; private set; }

    private void Awake() =>
        Rigidbody = GetComponent<Rigidbody>();

    public void Initialize(Vector3 scale, Color color, int chanceDivision)
    {
        transform.localScale = scale;
        transform.GetComponent<MeshRenderer>().material.color = color;
        ChanceDivision = chanceDivision;
    }
}
