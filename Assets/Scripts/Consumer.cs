﻿using MovementInterfaces;
using UnityEngine;
using UnityEngine.Assertions;

public class Consumer : MonoBehaviour
{
    [SerializeField] private IMovement[] _possibleMovements;
    [SerializeField] private Coords[] _possibleCords;
    [SerializeField] private Sprite[] _possibleSprite;

    private readonly PieceBuilder _pieceBuilder = new PieceBuilder();

    public void SetMovement(int movIndx, IMovement movemnt)
    {
        Assert.IsTrue(movIndx < _possibleMovements.Length, "Invalid movement index");

        _pieceBuilder.WithMovement(_possibleMovements[movIndx]);
    }

    public void CreateVehicle()
    {
        _pieceBuilder.Build();
    }
}