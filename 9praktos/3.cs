using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9praktos
{
    public class Game
    {
        private Snake _snake;
        private Random _random;
        private Food _food;

        public Game()
        {
            _snake = new Snake((10, 10), (1, 0));
            _random = new Random();
            GenerateFood();
        }

        public void GenerateFood()
        {
            int x = _random.Next(0, (int)MapSize.MaxRightBorder + 1);
            int y = _random.Next(0, (int)MapSize.MaxLowerBorder + 1);
            _food = new Food((x, y));
        }

        public void HandleInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    _snake.Direction = (0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    _snake.Direction = (0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    _snake.Direction = (-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    _snake.Direction = (1, 0);
                    break;
            }
        }

        public void Draw()
        {
            Console.Clear();

            // Рисуем верхнюю границу
            for (int i = 0; i <= (int)MapSize.MaxRightBorder + 1; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
            }

            // Рисуем нижнюю границу
            for (int i = 0; i <= (int)MapSize.MaxRightBorder + 1; i++)
            {
                Console.SetCursorPosition(i, (int)MapSize.MaxLowerBorder + 1);
                Console.Write("#");
            }

            // Рисуем левую и правую границы
            for (int i = 1; i <= (int)MapSize.MaxLowerBorder; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");

                Console.SetCursorPosition((int)MapSize.MaxRightBorder + 1, i);
                Console.Write("#");
            }

            // Рисуем сегменты змеи
            foreach (var segment in _snake.Body)
            {
                Console.SetCursorPosition(segment.x, segment.y);
                Console.Write("*");
            }

            // Рисуем еду
            Console.SetCursorPosition(_food.Position.x, _food.Position.y);
            Console.Write("$");
        }

        public bool IsGameOver()
        {
            return _snake.IsSelfCollision();
            _snake.IsOutOfBounds();
        }

        public void Play()
        {
            while (!IsGameOver())
            {
                Draw();
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    HandleInput(keyInfo.Key);
                }
                if (_snake.Eat(_food))
                {
                    GenerateFood();
                }
                _snake.Move();
                Thread.Sleep(100);
            }
        }
    }
}