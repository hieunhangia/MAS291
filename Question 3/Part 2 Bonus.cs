namespace Question_3;

public abstract class Part2Bonus
{
    private static double l;

    public static string Result(in int loop, in double l)
    {
        Part2Bonus.l = l;
        return $"Actual Mean of R = {ActualMean(loop)}";
    }

    private static double ActualMean(in int loop)
    {
        var rd = new Random();
        double sumX = 0;
        for (var i = 0; i < loop; i++)
            sumX += PositionOfFirstTimeBallReturnToOx(rd.NextDouble() * 0.5, rd.NextDouble() * Math.PI);

        return sumX / loop;
    }

    private static double PositionOfFirstTimeBallReturnToOx(double a, double x)
    {
        double b = 0;
        var oldContactRail = "OA";
        while (true)
        {
            FirstContact(a, b, x,
                out var xFirstContactPoint,
                out var yFirstContactPoint,
                out var angleFirstContact);
            var contactRail = RailOfFirstContact(a, b, x);
            if (yFirstContactPoint < 1e-8) return xFirstContactPoint;
            a = xFirstContactPoint;
            b = yFirstContactPoint;
            x = Part2.ComputeAngleOfNextReflectWithOx(x, angleFirstContact, contactRail, oldContactRail);
            oldContactRail = contactRail;
        }
    }

    private static void FirstContact(in double xBall, in double yBall, in double angleBall,
        out double xFirstContactPoint, out double yFirstContactPoint, out double angleFirstContact)
    {
        var a = Math.Tan(angleBall);
        var b = yBall - a * xBall;
        switch (RailOfFirstContact(xBall, yBall, angleBall))
        {
            case "OA":
                xFirstContactPoint = -b / a;
                yFirstContactPoint = 0;
                angleFirstContact = Part1.ComputeReflectAngle(1, a, 1, 0);
                break;
            case "BC":
                xFirstContactPoint = (l - b) / a;
                yFirstContactPoint = l;
                angleFirstContact = Part1.ComputeReflectAngle(1, a, 1, 0);
                break;
            case "CO":
                xFirstContactPoint = 0;
                yFirstContactPoint = b;
                angleFirstContact = Part1.ComputeReflectAngle(1, a, 0, 1);
                break;
            default:
                xFirstContactPoint = 1;
                yFirstContactPoint = a + b;
                angleFirstContact = Part1.ComputeReflectAngle(1, a, 0, 1);
                break;
        }
    }

    private static string RailOfFirstContact(in double xBall, in double yBall, in double angleBall)
    {
        ComputeAngleOfBallAndVertexOfSquareWithOx
            (xBall, yBall, out var o, out var a, out var b, out var c);
        if (angleBall >= o && angleBall <= a) return "OA";

        if (angleBall >= b && angleBall <= c) return "BC";

        if (angleBall >= c && angleBall <= o) return "CO";

        return "AB";
    }

    private static void ComputeAngleOfBallAndVertexOfSquareWithOx
        (in double xBall, in double yBall, out double o, out double a, out double b, out double c)
    {
        o = 2 * Math.PI - Part1.ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 0, 0);
        a = 2 * Math.PI - Part1.ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 1, 0);
        b = Part1.ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 1, l);
        c = Part1.ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 0, l);
    }

}