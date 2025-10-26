using Godot;
using System;

public partial class BulletV1 : CharacterBody2D
{
    [Export]
    public float Speed { get; set; } = 200f;

    [Export]
    public Vector2 Direction { get; set; } = Vector2.Right;


    override public void _Ready()
    {
        //base._Ready();
        GetTree().CreateTimer(5.0).Timeout += () =>
        {
            this.QueueFree();
        };
    }


    public override void _PhysicsProcess(double delta)
    {
        //base._PhysicsProcess(delta);
        this.Velocity = Direction * Speed;  
        this.MoveAndSlide();
        

    }
}
