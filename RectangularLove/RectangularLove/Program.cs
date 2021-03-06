using System;

namespace RectangularLove
{
  public class Program
  {
    public static void Main()
    {
      var r1 = new Rectangle(new Point(3, 2), 5, 6);

      // одинаковые
      var r2 = new Rectangle(new Point(3, 2), 5, 6);
      var o1 = RectangularOverlap(r1, r2);
      Console.WriteLine(o1 == r1);

      // пересекаются
      var r3 = new Rectangle(new Point(-2, -3), 7, 6);
      var o2 = RectangularOverlap(r1, r3);
      Console.WriteLine(o2 == new Rectangle(new Point(3, 2), 2, 1));

      // касаются гранью
      var r4 = new Rectangle(new Point(0, 8), 5, 8);
      var o3 = RectangularOverlap(r2, r4);
      Console.WriteLine(o3 == new Rectangle(new Point(3, 8), 2, 0));

      // касаются точкой
      var r5 = new Rectangle(new Point(5, 4), 3, 4);
      var o4 = RectangularOverlap(r5, r4);
      Console.WriteLine(o4 == new Rectangle(new Point(5, 8), 0, 0));

      // не касаются
      var r6 = new Rectangle(new Point(0, 0), 2, 2);
      var o5 = RectangularOverlap(r1, r6);
      Console.WriteLine(o5 == null);
      Console.ReadLine();
    }

public static Rectangle RectangularOverlap(Rectangle r1, Rectangle r2)
{
  // находим пересечение по оси x
  Segment xOverlap = Overlap(new Segment(r1.StartPoint.X, r1.Width), new Segment(r2.StartPoint.X, r2.Width));
  // находим пересечение по оси у
  Segment yOverlap = Overlap(new Segment(r1.StartPoint.Y, r1.Height), new Segment(r2.StartPoint.Y, r2.Height));

  if (xOverlap?.Length >= 0 && yOverlap?.Length >= 0)
    return new Rectangle(
        new Point(xOverlap.StartPoint, yOverlap.StartPoint),
          xOverlap.Length,
          yOverlap.Length
        );

  // не пересекаются
  return null;
}

    /// <summary>
    /// Пересечение отрезков
    /// </summary>
    /// <param name="s1">Отрезок 1</param>
    /// <param name="s2">Отрезок 2</param>
    /// <returns>Общий отрезок</returns>
static Segment Overlap(Segment s1, Segment s2)
{
  // начальная точка (максимальная из начальных)
  double start = Math.Max(s1.StartPoint, s2.StartPoint);
  // конечная точка (минимальная из конечных)
  double end = Math.Min(s1.StartPoint + s1.Length, s2.StartPoint + s2.Length);

  // отрезки не пересекаются
  if (start > end)
    return null;

  return new Segment(start, end - start);
}
  }

  public record Point(double X, double Y);
  public record Segment(double StartPoint, double Length);
  public record Rectangle(Point StartPoint, double Width, double Height);
}