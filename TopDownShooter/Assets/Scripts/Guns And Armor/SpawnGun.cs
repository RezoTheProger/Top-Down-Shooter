using System.Collections.Generic;
using UnityEngine;

public class SpawnGun : MonoBehaviour
{
    [SerializeField] private List<Transform> Place = new();
    [SerializeField] private GameObject[] Gun;
    private void Start()
    {
        for (int i = 0; i < Place.Count; i++)
        {

            int j = Random.Range(0, Place.Count);
            GameObject GO = Instantiate(Gun[i], Place[j].position, Gun[i].transform.rotation);
            GO.transform.SetParent(transform);
            
            Place.RemoveAt(j);
        }

    }
}
