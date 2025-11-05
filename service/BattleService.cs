using Godot;
using HelpMe.service;
using System;

public partial class BattleService : Node
{

    readonly SceneService scene;

    public BattleService(SceneService sceneService)
    {
        scene = sceneService;
    }


    /// <summary>
    /// 计算伤害
    /// </summary>
    /// <param name="attch"></param>
    /// <param name="defense"></param>
    /// <returns>伤害多少</returns>
   public float CalcDamage(Node attch,Node defense)
   {
        var damage = attch.Get("Damage").AsSingle();

        if(attch.GetType() == defense.GetType())
        {
            return 0.0f;
        }

        GD.Print($"CalcDamge:{attch.Name}->{defense.Name}  lost:{damage}");
        var hp = defense.Get("HP").AsSingle();
        hp -= damage;

        defense.Set("HP", hp);

        if(hp <= 0)
        {
            GD.Print($"{defense.Name} is dead!");
            scene.OnDead(defense);
        }


        return damage;
   }




}
