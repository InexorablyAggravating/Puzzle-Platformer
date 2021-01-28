using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class GameController : MonoBehaviour
{
    private Transform _spawnPoint;
    [SerializeField] private GameObject playerPrefab;
    void Start()
    {
        _spawnPoint = GameObject.FindWithTag(UnityTags.SPAWN_POINT).transform;
        Instantiate(playerPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
