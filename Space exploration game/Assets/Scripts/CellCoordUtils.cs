using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCoordUtils {

    public static double Distance(CellCoordPosition a, CellCoordPosition b, long CellSize)
    {
        var x = b.LocalX - a.LocalX + (b.GlobalX - a.GlobalX) * CellSize;
        var y = b.LocalY - a.LocalY + (b.GlobalY - a.GlobalY) * CellSize;
        var z = b.LocalZ - a.LocalZ + (b.GlobalZ - a.GlobalZ) * CellSize;

        return System.Math.Sqrt(x * x + y * y + z * z);
    }

    public static double Distance(ref CellCoordPosition a, ref CellCoordPosition b, long CellSize)
    {
        var x = b.LocalX - a.LocalX + (b.GlobalX - a.GlobalX) * CellSize;
        var y = b.LocalY - a.LocalY + (b.GlobalY - a.GlobalY) * CellSize;
        var z = b.LocalZ - a.LocalZ + (b.GlobalZ - a.GlobalZ) * CellSize;

        return System.Math.Sqrt(x * x + y * y + z * z);
    }

    public static double SqrDistance(CellCoordPosition a, CellCoordPosition b, long CellSize)
    {
        var x = b.LocalX - a.LocalX + (b.GlobalX - a.GlobalX) * CellSize;
        var y = b.LocalY - a.LocalY + (b.GlobalY - a.GlobalY) * CellSize;
        var z = b.LocalZ - a.LocalZ + (b.GlobalZ - a.GlobalZ) * CellSize;

        return x * x + y * y + z * z;
    }

    public static double SqrDistance(ref CellCoordPosition a, ref CellCoordPosition b, long CellSize)
    {
        var x = b.LocalX - a.LocalX + (b.GlobalX - a.GlobalX) * CellSize;
        var y = b.LocalY - a.LocalY + (b.GlobalY - a.GlobalY) * CellSize;
        var z = b.LocalZ - a.LocalZ + (b.GlobalZ - a.GlobalZ) * CellSize;

        return x * x + y * y + z * z;
    }

    public static CellCoordPosition Delta(ref CellCoordPosition a, ref CellCoordPosition b)
    {
        var o = default(CellCoordPosition);

        o.LocalX = a.LocalX - b.LocalX;
        o.LocalY = a.LocalY - b.LocalY;
        o.LocalZ = a.LocalZ - b.LocalZ;
        o.GlobalX = a.GlobalX - b.GlobalX;
        o.GlobalY = a.GlobalY - b.GlobalY;
        o.GlobalZ = a.GlobalZ - b.GlobalZ;

        return o;
    }

    public static bool Equal(ref CellCoordPosition a, ref CellCoordPosition b)
    {
        if (a.GlobalX == b.GlobalX && a.GlobalY == b.GlobalY && a.GlobalZ == b.GlobalZ)
        {
            if (a.LocalX == b.LocalX && a.LocalY == b.LocalY && a.LocalZ == b.LocalZ)
            {
                return true;
            }
        }

        return false;
    }

    public static Vector3 Direction(ref CellCoordPosition a, ref CellCoordPosition b, long CellSize)
    {
        var x = b.LocalX - a.LocalX + (b.GlobalX - a.GlobalX) * CellSize;
        var y = b.LocalY - a.LocalY + (b.GlobalY - a.GlobalY) * CellSize;
        var z = b.LocalZ - a.LocalZ + (b.GlobalZ - a.GlobalZ) * CellSize;
        var m = System.Math.Sqrt(x * x + y * y + z * z);

        if (m > 0.0)
        {
            x /= m;
            y /= m;
            z /= m;
        }

        return new Vector3((float)x, (float)y, (float)z);
    }

    public static CellCoordPosition Lerp(CellCoordPosition a, CellCoordPosition b, double t, long CellSize)
    {
        var o = a;

        o.LocalX += ((b.GlobalX - a.GlobalX) * CellSize + b.LocalX - a.LocalX) * t;
        o.LocalY += ((b.GlobalY - a.GlobalY) * CellSize + b.LocalY - a.LocalY) * t;
        o.LocalZ += ((b.GlobalZ - a.GlobalZ) * CellSize + b.LocalZ - a.LocalZ) * t;

        o.SnapLocal();

        return o;
    }

    public static Vector3 Vector(CellCoordPosition a, CellCoordPosition b, long CellSize)
    {
        var ax = a.LocalX + a.GlobalX * CellSize;
        var ay = a.LocalY + a.GlobalY * CellSize;
        var az = a.LocalZ + a.GlobalZ * CellSize;
        var bx = b.LocalX + b.GlobalX * CellSize;
        var by = b.LocalY + b.GlobalY * CellSize;
        var bz = b.LocalZ + b.GlobalZ * CellSize;

        var x = bx - ax;
        var y = by - ay;
        var z = bz - az;

        return new Vector3((float)x, (float)y, (float)z);
    }
}
