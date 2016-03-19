﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PheromoneManager : MonoBehaviour
{
    public GameObject phermoneNodePrefab;
    public GameObject phermoneTrailPrefab;
    List<PheromoneNode> pheromoneNodes = new List<PheromoneNode>();
    List<PheromoneTrail> pheromoneTrails = new List<PheromoneTrail>();

    public PheromoneNode RetrieveNewNode(PheromoneNode parentNode,GV.PhermoneTypes pherType)
    {
        GameObject newNodeGO = Instantiate<GameObject>(phermoneNodePrefab);
        GameObject newTrailGO = Instantiate<GameObject>(phermoneTrailPrefab);
        PheromoneNode newNode = newNodeGO.GetComponent<PheromoneNode>();
        PheromoneTrail newTrail = newTrailGO.GetComponent<PheromoneTrail>();

        newTrail.Initialize(parentNode, newNode, pherType);
        newNode.InitializeNode(newTrail);
        pheromoneNodes.Add(newNode);
        pheromoneTrails.Add(newTrail);
        return newNode;
    }

    public void Update()
    {
        foreach (PheromoneTrail pn in pheromoneTrails)
            pn.GetUpdated();
    }
}
