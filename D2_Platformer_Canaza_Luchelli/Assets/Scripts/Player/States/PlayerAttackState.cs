using UnityEngine;

/// <summary>
/// State behavior for basic melee attack.
/// </summary>
public class PlayerAttackState : PlayerState
{
    private bool isAnimationFinished;

    public PlayerAttackState(PlayerBrain player, PlayerStateMachine stateMachine, string animBoolName)
        : base(player, stateMachine, animBoolName) { }

    public override void Enter()
    {
        base.Enter();
        isAnimationFinished = false;

        // Stop movement except for y velociti (mid-air)
        player.MovementHandler.SetVelocity(0f, player.RB.linearVelocity.y);
        // Consume attack
        player.Anim.SetTrigger("attack");
        player.InputHandler.UseAttackInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // Check state transition when animation is finished
        if (isAnimationFinished)
        {
            if (player.CheckIfGrounded())
                stateMachine.ChangeState(player.IdleState);
            else
                stateMachine.ChangeState(player.FallState);
        }
    }

    /// <summary>
    /// Called via Animation Event to poitn the state machine that the attack is over.
    /// </summary>
    public void FinishAttackAnimation()
    {
        isAnimationFinished = true;
    }
}