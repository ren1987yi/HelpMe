using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerV1 : CharacterBody2D
{

    [Export]
    public float Size { get; set; } = 64;

    [Export]
    public int HP { get; set; } = 100;

    

    float speed = 5.0f;


    float max_x = 1280;
    float max_y = 800;

    Sprite2D Normal, Hurt;
    Sprite2D Sprite;

    Dictionary<string, Texture2D> animations = new Dictionary<string, Texture2D>()
    {
        { "Normal", GD.Load<Texture2D>("res://assets/images/lucas_2.png")},
        {"Hurt", GD.Load<Texture2D>("res://assets/images/hurt1.png")},
    };
    public override void _Ready()
    {
        Sprite = GetNode<Sprite2D>("Normal");
        
        //Sprite.Texture = animations["Normal"];

        Normal = GetNode<Sprite2D>("Normal");
        Hurt = GetNode<Sprite2D>("Hurt");
        Normal.Visible = true;
        Hurt.Visible = false;
    }


    public override void _PhysicsProcess(double delta)
    {
        
        
        var curPosion = this.Position;
        var offset = new Vector2(0, 0);

        if (Input.IsActionPressed("ui_left"))
        {
            offset += new Vector2(-1.0f , 0);

        }
        if (Input.IsActionPressed("ui_right"))
        {
            offset += new Vector2(1.0f, 0);
        }
        if (Input.IsActionPressed("ui_up"))
        {
            offset += new Vector2(0,-1.0f);
        }
        if (Input.IsActionPressed("ui_down"))
        {
            offset += new Vector2(0, 1.0f);
        }


        curPosion += offset * (float)speed;
        if(curPosion.X - Size < 0)
        {
            curPosion.X = Size;
        }

        if(curPosion.X + Size > max_x)
        {
            curPosion.X = max_x - Size;
        }

        if(curPosion.Y - Size < 0)
        {
            curPosion.Y = Size;

        }

        if(curPosion.Y + Size > max_y)
        {
            curPosion.Y = max_y - Size;
        }

        

        this.Position = curPosion;

        

    }


    public void OnHurt()
    {
        Hurt.Visible = true;
        Normal.Visible = false;
        //Sprite.Texture = animations["Hurt"];
        if (this.IsInsideTree())
        {

            GetTree().CreateTimer(0.5).Timeout += () =>
            {
                Hurt.Visible = false;
                Normal.Visible = true;
                //Sprite.Texture = animations["Normal"];
            };
        }
    }

}
