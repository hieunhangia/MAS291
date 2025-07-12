namespace Question_3;

public abstract class Part1
{
    public static string Result(in double a, in double b, in double x)
        => $"Output of firstContact({a},{b},{x}) is {FirstContact(a, b, x)}";

    private static string FirstContact(in double a, in double b, in double x)
    {
        FirstContact(a, b, x,
            out var xFirstContactPoint,
            out var yFirstContactPoint,
            out var angleFirstContactPoint);
        return $"({xFirstContactPoint},{yFirstContactPoint},{angleFirstContactPoint})";
    }

    public static void FirstContact(in double xBall, in double yBall, in double angleBall,
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

    public static double ComputeReflectAngle
        (in double xVectorA, in double yVectorA, in double xVectorB, in double yVectorB)
    {
        var angleOfTwoVector = ComputeAngleOfTwoVector(xVectorA, yVectorA, xVectorB, yVectorB);
        return angleOfTwoVector > Math.PI / 2 ? Math.PI - angleOfTwoVector : angleOfTwoVector;
    }

    public static string RailOfFirstContact(in double xBall, in double yBall, in double angleBall)
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
        o = 2 * Math.PI - ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 0, 0);
        a = 2 * Math.PI - ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 1, 0);
        b = ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 1, 1);
        c = ComputeAngleOfBallAndVertexWithOx(xBall, yBall, 0, 1);
    }

    public static double ComputeAngleOfBallAndVertexWithOx
        (in double xBall, in double yBall, in double xVertex, in double yVertex)
        => ComputeAngleOfTwoVector(xVertex - xBall, yVertex - yBall, 1, 0);

    private static double ComputeAngleOfTwoVector
        (in double xVectorA, in double yVectorA, in double xVectorB, in double yVectorB)
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