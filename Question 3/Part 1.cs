namespace Question_3;

public abstract class Part1
{
    public static void Result()
    {
        Console.WriteLine(ComputeAngle(0.5,0.5,0,0,0,1));
    }

    private static string FirstContact(double a, double b, double x)
    {
        string result = "";
        return result;
    }
    
    
    private static void FirstContact(double a, double b, double x, out string rail)
    {
        
    }
    private static void FirstContactCutPoint(double xBall, double yBall, double angleBall,
        out double xCutPoint, out double yCutPoint)
    {
        
    }
    
    private static void ComputeFourAngle(double xBall, double yBall,
        out double oa, out double ab, out double bc, out double co)
    {
        oa = ComputeAngle(xBall, yBall, 0, 0, 1, 0);
        ab = ComputeAngle(xBall, yBall, 1, 0, 1, 1);
        bc = ComputeAngle(xBall, yBall, 1, 1, 0, 1);
        co = 2*Math.PI - oa - ab - bc;
    }
    
    private static double ComputeAngle(double xBall, double yBall,
        double xFirstVertex, double yFirstVertex,
        double xSecondVertex, double ySecondVertex)
    {
        var xVectorOfBallWithFirstVertex = xFirstVertex - xBall;
        var yVectorOfBallWithFirstVertex = yFirstVertex - yBall;
        var xVectorOfBallWithSecondVertex = xSecondVertex - xBall;
        var yVectorOfBallWithSecondVertex = ySecondVertex - yBall;
        var cosAngle 
            = (xVectorOfBallWithFirstVertex * xVectorOfBallWithSecondVertex +
               yVectorOfBallWithFirstVertex * yVectorOfBallWithSecondVertex) /
                     (Math.Sqrt(Math.Pow(xVectorOfBallWithFirstVertex, 2) + Math.Pow(yVectorOfBallWithFirstVertex, 2)) *
                      Math.Sqrt(Math.Pow(xVectorOfBallWithSecondVertex, 2) + Math.Pow(yVectorOfBallWithSecondVertex, 2)));
        return Math.Acos(cosAngle);
    }
}