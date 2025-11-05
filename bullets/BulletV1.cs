using Godot;
using System;

public partial class BulletV1 : CharacterBody2D
{
    [Export]
    public int WeaponSlot {  get; set; }

    [Export]
    public float Speed { get; set; } = 200f;

    [Export]
    public Vector2 Direction { get; set; } = Vector2.Right;

    [Export]
    public Node Producer { get; set; }


    Hitbox hitbox;

    override public void _Ready()
    {
        //base._Ready();

        hitbox = GetNode<Hitbox>("Hitbox");
        hitbox.Producer = this.Producer;
        hitbox.Damage = this.Producer.Get("Damage").AsSingle();


        GetTree().CreateTimer(5.0).Timeout += () =>
        {
            if (this.IsInsideTree())
            {

                this.QueueFree();
            }
        };
    }


    public override void _PhysicsProcess(double delta)
    {
        //base._PhysicsProcess(delta);
        this.Velocity = Direction * Speed;  
        this.MoveAndSlide();
        

    }
}
