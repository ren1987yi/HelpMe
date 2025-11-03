using Godot;
using System;


public partial class Pen : Node2D
{


    
    string bulletScenePath = "res://bullets/BulletV1.tscn";


    PackedScene Bullet;
    Timer Timer;
    Marker2D CrossFire;
    public override void _Ready()
    {

        Bullet = GD.Load<PackedScene>(bulletScenePath);
        Timer = GetNode<Timer>("Timer");

        CrossFire = GetNode<Marker2D>("CrossFire");

        GD.Print("Pen ready");

        Timer.WaitTime = 2f;
        Timer.Timeout += OnTimerTimeout;
        Timer.Start();



    }

    private void OnTimerTimeout()
    {
        Shoot();
        //GetNode<BattleService>("/root/BattleSystem").AA();
        //var bettleSystem = GetTree().Root.GetNodeOrNull<BattleService>("BattleService");
        //if (bettleSystem != null)
        //{
        //    bettleSystem.AA();
        //}
    }


    Random random = new Random(DateTime.Now.Microsecond);
    private void Shoot()
    {
        var bullet = Bullet.Instantiate<BulletV1>();
        bullet.Direction = new Vector2((float)(random.NextDouble() * 2 - 1), (float)(random.NextDouble() * 2 - 1)).Normalized();
        //this.AddChild(bullet);
        GetParent().GetParent().AddChild(bullet);
        bullet.Position = CrossFire.GlobalPosition;
    }
}
