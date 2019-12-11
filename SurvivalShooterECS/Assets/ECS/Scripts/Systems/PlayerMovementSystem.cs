﻿using Unity.Entities;
using UnityEngine;

[DisableAutoCreation]
public class PlayerMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var speed = SurvivalShooterBootstrap.Settings.PlayerMoveSpeed;
        var dt = Time.DeltaTime;

        Entities.WithAll<PlayerInputData>().WithNone<DeadData>().ForEach(
            (Entity entity, Rigidbody rigidBody, ref PlayerInputData input) =>
            {
                var move = input.Move;

                var movement = new Vector3(move.x, 0, move.y);
                movement = movement.normalized * speed * dt;

                var go = rigidBody.gameObject;
                var position = go.transform.position;
                var newPos = new Vector3(position.x, position.y, position.z) + movement;
                rigidBody.MovePosition(newPos);
            });
    }
}
