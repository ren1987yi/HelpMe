using Godot;
using System;

public partial class PlayerV1 : CharacterBody2D
{

    [Export]
    public float Size { get; set; } = 64;




    float speed = 5.0f;


    float max_x = 1280;
    float max_y = 800;
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
}
