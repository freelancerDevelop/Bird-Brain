﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlayer : Entity {

    public int exp;
    public int expToNextLevel;

    protected override void OnStart() {
        base.OnStart();
    }

    protected override void OnUpdate() {
        base.OnUpdate();
    }

    protected override void OnDeath() {
        base.OnDeath();
    }

    protected override void OnDamage() {
        base.OnDamage();
        MakeInvulnerable(2);
    }

}