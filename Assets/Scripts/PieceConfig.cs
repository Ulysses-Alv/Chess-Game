using UnityEngine;
using System;
using System.Collections.Generic;

class PieceConfig : MonoBehaviour
{
    #region Obtener Getting

    [SerializeField] private Movement[] movements;
    private static Dictionary<TipoDePieza, Movement> _idToMovement;

    private void Awake()
    {
        foreach (var movement in movements)
        {
            _idToMovement.Add(movement.Id, movement);
        }
    }

    public static Movement GetMovement(TipoDePieza id)
    {
        if (!_idToMovement.TryGetValue(id, out var movement))
        {
            throw new Exception($"Movement with id {id} does not exit");
        }
        return movement;
    }
    #endregion    
}