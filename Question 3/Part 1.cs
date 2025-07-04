namespace Question_3;

public class Part1
{
    public static void Result()
    {
        Console.WriteLine(ComputeAngle(0.5,0.5,0,0,0,1));
    }

    /*private static string FirstContact(double a, double b, double x)
    {
        string result = "";
        return result;
    }
    
    private static void FirstContactCutPoint(double a, double b, double x,
        out double xCutPoint, out double yCutPoint)
    {
        
    }
    
    private static void FirstContact(double a, double b, double x, out string rail)
    {
        
    }

    private static void ComputeFourAngle(double a, double b,
        out double oa, out double ab, out double bc, out double co)
    {
        
    }*/
    
    private static double ComputeAngle(double xBall, double yBall,
        double xFirstVertex, double yFirstVertex,
        double xSecondVertex, double ySecondVertex)
    {
        var xVectorOfBallWithFirstVertex = xFirstVertex - xBall;
        var yVectorOfBallWithFirstVertex = yFirstVertex - yBall;
        var xVectorOfBallWithSecondVertex = xSecondVertex - xBall;
        var yVectorOfBallWithSecondVertex = ySecondVertex - yBall;
        var cosine 
            = (xVectorOfBallWithFirstVertex * xVectorOfBallWithSecondVertex +
               yVectorOfBallWithFirstVertex * yVectorOfBallWithSecondVertex) /
                     (Math.Sqrt(Math.Pow(xVectorOfBallWithFirstVertex, 2) + Math.Pow(yVectorOfBallWithFirstVertex, 2)) *
                      Math.Sqrt(Math.Pow(xVectorOfBallWithSecondVertex, 2) + Math.Pow(yVectorOfBallWithSecondVertex, 2)));
        return Math.Acos(cosine);
    }
}