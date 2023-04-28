using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var newCube = Instantiate(_cube);
            newCube.transform.position = new Vector3(Random.Range(-5f, 5f), 10, Random.Range(-5f, 5f));
        }
    }
}
