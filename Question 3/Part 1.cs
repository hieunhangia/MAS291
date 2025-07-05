namespace Question_3;

public abstract class Part1
{
    public static void Result(double a, double b, double x)
    {
        FirstContact(a, b, x,
            out var xFirstContactPoint, out var yFirstContactPoint, out var angleFirstContactPoint);
        Console.WriteLine($"Output of firstContact({a},{b},{x})" +
                          $" = ({xFirstContactPoint},{yFirstContactPoint},{angleFirstContactPoint})");
    }

    public static void FirstContact(double xBall, double yBall, double angleBall,
        out double xFirstContactPoint, out double yFirstContactPoint, out double angleFirstContact)
    {
        var a = Math.Tan(angleBall);
        var b = yBall - a * xBall;
        switch (RailOfFirstContact(xBall, yBall, angleBall))
        {
            case "OA":
                xFirstContactPoint = -b / a;
                yFirstContactPoint = 0;
                angleFirstContact = ComputeReflectAngle(1, a, 1, 0);
                break;
            case "BC":
                xFirstContactPoint = (1 - b) / a;
                yFirstContactPoint = 1;
                angleFirstContact = ComputeReflectAngle(1, a, 1, 0);
                break;
            case "CO":
                xFirstContactPoint = 0;
                yFirstContactPoint = b;
                angleFirstContact = ComputeReflectAngle(1, a, 0, 1);
                break;
            default:
                xFirstContactPoint = 1;
                yFirstContactPoint = a + b;
                angleFirstContact = ComputeReflectAngle(1, a, 0, 1);
                break;
        }
    }

    private static double ComputeReflectAngle
        (double xVectorA, double yVectorA, double xVectorB, double yVectorB)
    {
        var angleOfTwoVector = ComputeAngleOfTwoVector(xVectorA, yVectorA, xVectorB, yVectorB);
        return angleOfTwoVector > Math.PI / 2 ? Math.PI - angleOfTwoVector : angleOfTwoVector;
    }

    private static string RailOfFirstContact(double xBall, double yBall, double angleBall)
    {
        ComputeAngleOfBallAndVertexOfSquareWithOx
            (xBall, yBall, out var o, out var a, out var b, out var c);
        if (angleBall >= o && angleBall <= a) return "OA";

        if (angleBall >= b && angleBall <= c) return "BC";

        if (angleBall >= c && angleBall <= o) return "CO";

        return "AB";
    }

    private static void ComputeAngleOfBallAndVertexOfSquareWithOx(double xBall, double yBall,
        out double o, out double a, out double b, out double c)
    {
        o = 2 * Math.PI - ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 0, 0);
        a = 2 * Math.PI - ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 1, 0);
        b = ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 1, 1);
        c = ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 0, 1);
    }

    private static double ComputeAngleOfBallAndVertexWithOx
        (double xBall, double yBall, int xVertex, int yVertex)
        => ComputeAngleOfTwoVector(xVertex - xBall, yVertex - yBall, 1, 0);

    private static double ComputeAngleOfTwoVector
        (double xVectorA, double yVectorA, double xVectorB, double yVectorB)
        => Math.Acos(
            (xVectorA * xVectorB + yVectorA * yVectorB)
            /
            (
                Math.Sqrt(xVectorA * xVectorA + yVectorA * yVectorA)
                *
                Math.Sqrt(xVectorB * xVectorB + yVectorB * yVectorB)
            )
        );
}