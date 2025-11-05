using Godot;
using System;
using System.Drawing;

public partial class Enemy1 : CharacterBody2D
{
    [Export]
    public float Damage { get; set; } = 1.0f;


    [Export]
    public float HP { get; set; } = 1000.0f;


    Random random = new Random();

    float speed = 100.0f;
    ProgressBar barHP;
    public override void _Ready()
    {

        barHP = GetNode<ProgressBar>("barHP");

        barHP.MaxValue = HP;
        //base._Ready();
        GetTree().CreateTimer(0.3).Timeout += () =>
        {
            speed = (float)random.Next(50, 200);
            this.Velocity = new Vector2(random.NextSingle() - 0.5f, random.NextSingle() - 0.5f).Normalized() * speed;
        };

    }


    double timeAcc = 0;
    public override void _Process(double delta)
    {
        //base._Process(delta);
        //lbHP.Text = $"{HP:f0}";
        barHP.Value = HP;
    }

    [Export]
    public float Size { get; set; } = 128;




    float max_x = 1280;
    float max_y = 800;

    public override void _PhysicsProcess(double delta)
    {
        //base._PhysicsProcess(delta);
        timeAcc += delta;

        if (timeAcc > 2)
        {


            speed = (float)random.Next(50, 200);
            this.Velocity = new Vector2(random.NextSingle() - 0.5f, random.NextSingle() - 0.5f).Normalized() * speed;
           
            //this.Position = new Vector2(random.NextSingle() * 900, random.NextSingle() * 700);
            timeAcc = 0;
        }

        var curPosion = this.Position;
        if (curPosion.X - Size < 0)
        {
            this.Velocity = new Vector2(this.Velocity.X * -1, this.Velocity.Y);
        }

        if (curPosion.X + Size > max_x)
        {
            this.Velocity = new Vector2(this.Velocity.X * -1, this.Velocity.Y);
        }

        if (curPosion.Y - Size < 0)
        {
            this.Velocity = new Vector2(this.Velocity.X , this.Velocity.Y * -1);

        }

        if (curPosion.Y + Size > max_y)
        {
            this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y * -1);
        }


        this.MoveAndSlide();
    }

    
}
