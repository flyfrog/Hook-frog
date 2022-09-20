using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Zenject;

public class EyesLookController : MonoBehaviour
{
    private GameObject[] _eyes;
    private Vector3 _pointToLook;
    private const float _timePointLookup = 0.8f;
    private float _currentTime = _timePointLookup;
    private InputManager _inputManager;
    private float _pointCoordinateZAdjustment = 10f;
    private float _pointCoordinateXAdjustment = 8f;

    [Inject]
    private void Construct(InputManager inputManagerArg)
    {
        _inputManager = inputManagerArg;
        _inputManager.OnMouseClickEvent += PlayerClicked;
    }

    private void Awake()
    {
        _eyes = TakeEyesChildren();
    }

    private void Update()
    {
        ReturnLookToCameraInTime();
        LookToPoint();
    }

    private void ReturnLookToCameraInTime()
    {
        if (_currentTime > _timePointLookup)
        {
            SetPointToLook(Camera.main.transform.position);
            return;
        }

        _currentTime += Time.deltaTime;
    }

    private GameObject[] TakeEyesChildren()
    {
        int childCount = transform.childCount;
        GameObject[] eyes = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            eyes[i] = transform.GetChild(i).gameObject;
        }

        return eyes;
    }


    private void LookToPoint()
    {
        foreach (var eye in _eyes)
        {
            eye.transform.LookAt(_pointToLook);
        }
    }

    private void SetPointToLook(Vector3 newPointToLookArg)
    {
        ResetReturnLookToCameraTime();
        _pointToLook = newPointToLookArg;
    }

    private void ResetReturnLookToCameraTime()
    {
        _currentTime = 0f;
    }


    private void PlayerClicked(Vector3 clickPosition)
    {
        Vector3 pointToLook = clickPosition;
        pointToLook = AdjustCoordinatesToLookABitForward(pointToLook);
        SetPointToLook(pointToLook);
    }

    private Vector3 AdjustCoordinatesToLookABitForward(Vector3 pointCoordinate)
    {
        pointCoordinate.z -= _pointCoordinateZAdjustment;
        pointCoordinate.x += _pointCoordinateXAdjustment; 
        return pointCoordinate;
    }
}