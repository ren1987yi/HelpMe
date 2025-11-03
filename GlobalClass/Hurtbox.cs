using Godot;
using System;

[GlobalClass]
public partial class Hurtbox : Area2D
{
    [Export]
    public Node Producer { get; set; } = null;



    bool isHurt = false;
    public void OnHurt()
    {
        var _p = GetParent();
        if( _p is PlayerV1)
        {
            PlayerV1 p = _p as PlayerV1; 
            p.OnHurt();
            isHurt = true;
        }
       
    }

    public override void _Process(double delta)
    {
        //base._Process(delta);

        if (isHurt)
        {
            isHurt = false;
            this.Monitoring = false;
            this.Monitorable = false;
            GetTree().CreateTimer(1).Timeout += () =>
            {
                this.Monitoring = true;
                this.Monitorable = true;
            };
        }

    }
}
