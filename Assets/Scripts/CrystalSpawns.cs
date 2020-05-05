using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public class CrystalSpawns : MonoBehaviour
{
  [SerializeField] private Transform[] _transform;
  [SerializeField] private GameObject _crystal;

  static Random _random = new Random();
  private float _runingTime;
  private int _appointPosition;

  private void Update()
  {
    _runingTime += Time.deltaTime;
    if (_runingTime >= 3)
    {
      _appointPosition = _random.Next(0, _transform.Length);
      Instantiate(_crystal, _transform[_appointPosition].position, Quaternion.identity);
      _runingTime = 0;
    }
  }
}
