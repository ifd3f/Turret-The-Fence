﻿using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargetingControl : MonoBehaviour {

    /**
     * The furthest we can shoot. Use a negative value for infinite distance.
     */
    public float maxDistance;
    public GameObject target;
    public Vector3 pointingOffset;

    private const string TARGET_TAG = "TurretTargets";
    private TurretDirectionControl directionControl;

	// Use this for initialization
	void Start () {
        directionControl = GetComponent<TurretDirectionControl>();
	}
	
	// Update is called once per frame
	void Update () {
        target = null;
        float closestDist = maxDistance >= 0 ? maxDistance * maxDistance : float.MaxValue;
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag(TARGET_TAG);
        foreach (GameObject obj in possibleTargets) {
            float dist = (obj.transform.position - transform.position).sqrMagnitude;
            if (dist < closestDist && !obj.GetComponent<EnemyHealth>().isDead) {
                target = obj;
                closestDist = dist;
            }
        }
        if (target != null) {
            directionControl.targetPosition = target.transform.position + pointingOffset;
        }
	}
}