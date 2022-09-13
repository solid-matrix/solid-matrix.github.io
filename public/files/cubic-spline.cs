public class InterpolatingCubicSpline
{
    private readonly Vector2<double>[] p;
    private readonly double[] k;

    public InterpolatingCubicSpline(IEnumerable<Vector2<double>> points)
    {
        LinkedList<Vector2<double>> tmp = new(points.OrderBy(p => p.X));

        // add one (0.0, 0.0) as the first and one (1.0, 1.0) as the last if not exist
        if (tmp.First().X != 0.0 || tmp.First().Y != 0.0) tmp.AddFirst(new Vector2<double>(0.0, 0.0));
        if (tmp.Last().X != 1.0 || tmp.Last().Y != 1.0) tmp.AddLast(new Vector2<double>(1.0, 1.0));

        p = tmp.ToArray();
        k = CalcNaturalK(p);
    }

    public double Eval(double x)
    {
        int i = 1;
        while (p[i].X < x) i++;

        double t = (x - p[i - 1].X) / (p[i].X - p[i - 1].X);
        double a = k[i - 1] * (p[i].X - p[i - 1].X) - (p[i].Y - p[i - 1].Y);
        double b = -k[i] * (p[i].X - p[i - 1].X) + (p[i].Y - p[i - 1].Y);
        return (1 - t) * p[i - 1].Y + t * p[i].Y + t * (1 - t) * (a * (1 - t) + b * t);
    }

    private static double[] CalcNaturalK(Vector2<double>[] p)
    {
        int n = p.Length;
        double[][] m = ZeroMatrix(n, 3);
        double[] d = new double[n];

        m[0][0] = 0.0;
        m[0][1] = 2.0 / (p[1].X - p[0].X);
        m[0][2] = 1.0 / (p[1].X - p[0].X);

        d[0] = 3.0 * (p[1].Y - p[0].Y) / (p[1].X - p[0].X) / (p[1].X - p[0].X);

        for (int i = 1; i < n - 1; i++)
        {
            m[i][0] = 1.0 / (p[i].X - p[i - 1].X);
            m[i][1] = 2.0 * (1.0 / (p[i].X - p[i - 1].X) + 1.0 / (p[i + 1].X - p[i].X));
            m[i][2] = 1.0 / (p[i + 1].X - p[i].X);


            d[i] = 3.0 * ((p[i].Y - p[i - 1].Y) / (p[i].X - p[i - 1].X) / (p[i].X - p[i - 1].X) + (p[i + 1].Y - p[i].Y) / (p[i + 1].X - p[i].X) / (p[i + 1].X - p[i].X));
        }

        m[n - 1][0] = 1.0 / (p[n - 1].X - p[n - 2].X);
        m[n - 1][1] = 2.0 / (p[n - 1].X - p[n - 2].X);
        m[n - 1][2] = 0.0;
        d[n - 1] = 3.0 * (p[n - 1].Y - p[n - 2].Y) / (p[n - 1].X - p[n - 2].X) / (p[n - 1].X - p[n - 2].X);

        return SolveTridiagonalLinearEquation(m, d);
    }

    private static double[] SolveTridiagonalLinearEquation(double[][] m, double[] d)
    {
        int n = d.Length;
        double[] k = new double[n];

        m[0][2] = m[0][2] / m[0][1];
        d[0] = d[0] / m[0][1];

        m[0][1] = 1.0;

        for (int i = 1; i < n; i++)
        {
            m[i][1] = m[i][1] - m[i][0] * m[i - 1][2];
            d[i] = d[i] - m[i][0] * d[i - 1];
            d[i] = d[i] / m[i][1];
            m[i][2] = m[i][2] / m[i][1];
            m[i][0] = 0.0;
            m[i][1] = 1.0;
        }
        k[n - 1] = d[n - 1];

        for (int i = n - 2; i >= 0; i--)
        {
            k[i] = d[i] - k[i + 1] * m[i][2];
        }

        return k;
    }

    private static double[][] ZeroMatrix(int r, int c)
    {
        double[][] m = new double[r][];
        for (int i = 0; i < r; i++)
        {
            m[i] = new double[c];
            for (int j = 0; j < c; j++) m[i][j] = 0;
        }
        return m;
    }
}
