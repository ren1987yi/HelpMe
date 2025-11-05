using Godot;
using System;


public partial class RemoteWeaponBase : Node2D
{
    /// <summary>
    /// 武器槽号
    /// </summary>
    [Export]
    public int Slot { get; set; } = -1;

    [Export]
    public string BulletNodePath { get; set; }

    [Export]
    public double CoolDownTime { get; set; }


    [Export]
    public float Damage { get; set; } = 1.0f;

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

    public override void _ExitTree()
    {
        //base._ExitTree();
        Timer.Timeout -= Timer_Timeout;
        Timer.Stop();
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
        //bullet.Direction = new Vector2((float)(random.NextDouble() * 2 - 1), (float)(random.NextDouble() * 2 - 1)).Normalized();
        bullet.Direction = new Vector2(10, (random.NextSingle()-0.5f)).Normalized();
        bullet.Position = CrossFire.GlobalPosition;
        bullet.Producer = this;
        bullet.Speed = 1000f;
        //this.AddChild(bullet);
        GetParent().GetParent().AddChild(bullet);
    }

}
