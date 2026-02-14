using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH10
{
    internal class SwitchExample
    {
        public abstract class Shape { }
        public class Square : Shape
        {
            public double Side { get; set; }
        }
        public class Circle : Shape
        {
            public double Radius { get; set; }
        }
        public class Triangle : Shape
        {
            public double Height { get; set; }
        }
        public static void Main()
        {
            var shapes = new List<Shape> { };
            shapes.Add(new Circle() { Radius = 7 });
            shapes.Add(new Square() { Side = 5 });
            shapes.Add(new Triangle() { Height = 4 });
            shapes.Add(new Triangle() { Height = 8 });
            var nullSquare = (Shape)null;
            shapes.Add(nullSquare);
            foreach (var shape in shapes)
            {
                switch (shape)
                {
                    case Circle circle:         //等價於if(shape is Circle)
                        Console.WriteLine($"This shape is a circle with radius {circle.Radius}");
                        break;
                    case Square square when square.Side > 10:       //僅僅匹配一部份Square
                        Console.WriteLine($"This shape is a large square of side {square.Side}");
                        break;
                    case Square square:
                        Console.WriteLine($"This shape is a square of side {square.Side}");
                        break;
                    case Triangle trabgle:
                        Console.WriteLine($"This shape is a triangle of height {trabgle.Height}");
                        break;
                    //case Triangle triangle when triangle.Height < 5:      //編譯錯
                    //    Console.WriteLine($"This shape si a traingle of height {triangle.Height}");
                    //    break;
                    case null:
                        Console.WriteLine($"This shape could be a Square, Circle or a  Triangle");
                        break;
                    default:
                        throw new ArgumentException(
                            message: "shape is not a recognized shape",
                            paramName: nameof(shape));
                }
            }
        }
    }
}