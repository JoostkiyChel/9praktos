using _9praktos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Snake
{
    public List<(int x, int y)> Body { get; set; }
    public (int x, int y) Direction { get; set; }

    public Snake((int x, int y) startPosition, (int x, int y) direction)
    {
        Body = new List<(int x, int y)> { startPosition };
        Direction = direction;
    }

    public void Move()
    {
        (int x, int y) newHead = (Body[0].x + Direction.x, Body[0].y + Direction.y);
        Body.Insert(0, newHead);
        Body.RemoveAt(Body.Count - 1);
    }

    public void Grow()
    {
        (int x, int y) newTail = Body[Body.Count - 1];
        Body.Add(newTail);
    }

    public bool IsSelfCollision()
    {
        (int x, int y) head = Body[0];
        return Body.FindAll(segment => segment.x == head.x && segment.y == head.y).Count > 1;
    }

    public bool IsOutOfBounds()
    {
        (int x, int y) head = Body[0];
        return head.x < 0 || head.x > (int)MapSize.MaxRightBorder || head.y < 0 || head.y > (int)MapSize.MaxLowerBorder;
    }

    public bool Eat(Food food)
    {
        if (Body[0].Equals(food.Position))
        {
            Grow();
            return true;
        }
        return false;
    }
}