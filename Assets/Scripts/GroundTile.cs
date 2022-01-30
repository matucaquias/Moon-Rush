using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner _groundSpawner;
    void Start()
    {
        _groundSpawner = FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            _groundSpawner.SpawnTile();
        }
    }
    
}
