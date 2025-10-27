using Godot;
using System;


public partial class RemoteWeaponBase : Node2D
{
    [Export]
    public int Slot { get; set; }

    [Export]
    public string BulletNodePath { get; set; }

    [Export]
    public double CoolDownTime { get; set; }
    

    PackedScene bulletScene;
    Marker2D CrossFire;
    Sprite2D Img;
    Timer Timer;
    public override void _Ready()
    {
        init();
    }


    private void init()
    {
        if (!string.IsNullOrWhiteSpace(BulletNodePath))
        {
            bulletScene = GD.Load<PackedScene>(BulletNodePath);
        }


        CrossFire = GetNode<Marker2D>("CrossFire");
        Img = GetNode<Sprite2D>("Img");
        Timer = GetNode<Timer>("Timer");
        
        //load weapon image
        //load bullet 
        //load markpos


       
        Timer.WaitTime = CoolDownTime;
        Timer.Timeout += Timer_Timeout;
        Timer.Start();
    }

    private void Timer_Timeout()
    {
        //throw new NotImplementedException();
        shoot();
    }

    public void Shoot()
    {
        shoot();
    }

    Random random = new Random(DateTime.Now.Microsecond);
    private void shoot()
    {

        //TODO 计算朝向

        var bullet = bulletScene.Instantiate() as BulletV1;
        bullet.Direction = new Vector2((float)(random.NextDouble() * 2 - 1), (float)(random.NextDouble() * 2 - 1)).Normalized();
        bullet.Position = CrossFire.GlobalPosition;
        //this.AddChild(bullet);
        GetParent().GetParent().AddChild(bullet);
    }

}
