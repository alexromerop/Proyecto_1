﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEdgeCollider : MonoBehaviour
{
    private Camera cam;
    private EdgeCollider2D edge;
    private Vector2[] edgePoints;

    void Awake()
    {
        if (Camera.main == null) Debug.LogError("Camera.main not found, failed to create edge colliders");
        else cam = Camera.main;

        if (!cam.orthographic) Debug.LogError("Camera.main is not Orthographic, failed to create edge colliders");

        edge = GetComponent<EdgeCollider2D>();

        edgePoints = new Vector2[4];

        AddCollider();
    }

    void AddCollider()
    {
        //Vector2's for the corners of the screen
        Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        Vector2 topLeft = new Vector2(bottomLeft.x, topRight.y);
        Vector2 bottomRight = new Vector2(topRight.x, bottomLeft.y);

        //Update Vector2 array for edge collider
        edgePoints[0] = bottomLeft;
        edgePoints[1] = topLeft;
        edgePoints[2] = topRight;
        edgePoints[3] = bottomRight;
        //edgePoints[4] = bottomLeft;

        edge.points = edgePoints;
    }
}
