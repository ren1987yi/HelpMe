using Godot;
using System;

public partial class BulletV1 : CharacterBody2D
{
    public override void _PhysicsProcess(double delta)
    {
        //base._PhysicsProcess(delta);
        this.Velocity = new Vector2(100, 100);
        this.MoveAndSlide();

        GetTree().CreateTimer(5.0).Timeout += () =>
        {
            this.QueueFree();
        };
    }
}
