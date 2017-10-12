﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell {

    GameObject projectilePrefab;

    public Fireball(GameObject _owner, GameObject _projectilePrefab) : base(_owner) {
        reloadTime = 1.0f;
        projectilePrefab = _projectilePrefab;
    }

    public override void Cast(Vector3 _dir) {

        ProjectileBasic pBasic = ProjectileManager.CreateProjectile(projectilePrefab, EntityType.Player, owner, owner.transform.position + Vector3.up * 0.5f) as ProjectileBasic;
        pBasic.Init(_dir, 14);

    }

}