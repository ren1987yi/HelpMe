using Godot;
using HelpMe;
using Microsoft.Extensions.DependencyInjection;
using System;

[GlobalClass]
public partial class Hitbox : Area2D
{


    [Export]
    public float Damage { get; set; } = 1.0f;

    [Export]
    public Node Producer { get; set; } = null;


    int hitCount = 0;

    bool isHit = false;

    BattleService battleService;

    public Hitbox()
    {

        AreaEntered += Hitbox_AreaEntered;

        battleService = Application.Service.GetService<BattleService>();

        //AreaExited += Hitbox_AreaExited;
    }

    private void Hitbox_AreaEntered(Area2D area)
    {
        
        hitCount++;
        //throw new NotImplementedException();
        GD.Print($"{hitCount} Hitbox Area Entered: {area.Name},Producer is {Producer.Name}");

        var Hurtbox = area as Hurtbox;
        if (Hurtbox != null)
        {

            var result = battleService.CalcDamage(this.Producer,Hurtbox.Producer);
            
            if(result != 0)
            {

                Hurtbox.OnHurt();
                isHit = true;
            }



            if(Producer is RemoteWeaponBase)
            {
                this.GetParent().QueueFree();
            }


        }

        
    }

    public override void _Process(double delta)
    {
        //base._Process(delta);

        if (isHit)
        {
            isHit = false;
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
