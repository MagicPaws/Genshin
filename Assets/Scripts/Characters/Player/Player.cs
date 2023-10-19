using System;
using Genshin.Characters.Player.StateMachines.Movement;
using Genshin.Characters.Player.StateMachines.Movement.States;
using Genshin.Characters.Player.StateMachines.Movement.States.Grounded;
using UnityEngine;

namespace Genshin.Characters.Player
{
    public class Player : MonoBehaviour
    {
        private PlayerMovementStateMachine movementStateMachine;

        private void Awake()
        {
            movementStateMachine = new PlayerMovementStateMachine();
        }

        private void Start()
        {
            movementStateMachine.ChangeState(movementStateMachine.IdlingState);
        }

        private void Update()
        {
            movementStateMachine.HandleInput();
            movementStateMachine.Update();
        }

        private void FixedUpdate()
        {
            movementStateMachine.PhysicsUpdate();
        }
    }
}