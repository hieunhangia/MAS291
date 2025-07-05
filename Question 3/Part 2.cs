namespace Question_3;

public abstract class Part2
{
    public static void Result(in int loop)
    {
        Console.WriteLine($"Expected Mean of R = 0.5");
        Console.WriteLine($"Actual Mean of R with {loop} tries = {ActualMean(loop)}");
    }

    private static double ActualMean(in int loop)
    {
        var rd = new Random();
        double sumX = 0;
        for (var i = 0; i < loop; i++)
        {
            sumX += PositionOfFirstTimeBallReturnToOx(rd.NextDouble() * 0.5, rd.NextDouble() * Math.PI);
        }

        return sumX / loop;
    }

    private static double PositionOfFirstTimeBallReturnToOx(double a, double x)
    {
        double b = 0;
        var oldContactRail = "OA";
        while (true)
        {
            Part1.FirstContact(a, b, x,
                out var xFirstContactPoint,
                out var yFirstContactPoint,
                out var angleFirstContact);
            var contactRail = Part1.RailOfFirstContact(a, b, x);
            if (contactRail == "OA") return xFirstContactPoint;
            a = xFirstContactPoint;
            b = yFirstContactPoint;
            x = ComputeAngleOfNextReflectWithOx(x, angleFirstContact, contactRail, oldContactRail);
            oldContactRail = contactRail;
        }
    }

    private static double ComputeAngleOfNextReflectWithOx
        (in double shootAngle, in double reflectAngle, in string contactRail, in string oldContactRail)
    {
        return oldContactRail switch
        {
            "OA" => contactRail switch
            {
                "AB" => reflectAngle + Math.PI / 2,
                "BC" => shootAngle < Math.PI / 2
                    ? 2 * Math.PI - reflectAngle
                    : reflectAngle + Math.PI,
                _ => Math.PI / 2 - reflectAngle //OC
            },
            "BC" => contactRail switch
            {
                "CO" => reflectAngle + 3 * Math.PI / 2,
                _ => 3 * Math.PI / 2 - reflectAngle //AB
            },
            "CO" => contactRail switch
            {
                "AB" => shootAngle < Math.PI / 2
                    ? reflectAngle + Math.PI / 2
                    : 3 * Math.PI / 2 - reflectAngle,
                _ => 2 * Math.PI - reflectAngle //BC
            },
            _ => contactRail switch //AB
            {
                "BC" => reflectAngle + Math.PI,
                _ => shootAngle < Math.PI
                    ? Math.PI / 2 - reflectAngle
                    : 3 * Math.PI / 2 + reflectAngle
            }
        };
    }
}