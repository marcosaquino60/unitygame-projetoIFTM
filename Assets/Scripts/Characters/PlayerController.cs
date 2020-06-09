﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavGame.Core;

public class PlayerController : TouchableGameObject
{
    NavMeshAgent agent;
    Camera cam;
    public LayerMask walkableLayer;
    public GameObject prefab;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
        GameObject obj = GameObject.FindWithTag("Finish");
        DamageableGameObject dgo = obj.GetComponent<DamageableGameObject>();
        GameObject projectile = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        ProjectileController controller = projectile.GetComponent<ProjectileController>();
        controller.Init(dgo, 20);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, walkableLayer))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}