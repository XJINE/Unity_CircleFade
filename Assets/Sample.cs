using UnityEngine;

public class Sample : MonoBehaviour
{
    public int count = 30;

    [ContextMenu("Generate")]
    void Generate()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.transform.position = new Vector3(Random.Range(-3f, 3f),
                                                  Random.Range(-3f, 3f),
                                                  Random.Range(-3f, 3f));

            cube.transform.Rotate(Random.Range(0, 360f),
                                  Random.Range(0, 360f),
                                  Random.Range(0, 360f));

            cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            cube.transform.SetParent(this.transform);
        }
    }
}