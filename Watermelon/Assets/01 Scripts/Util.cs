using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static Vector3[] ToVector3(this Vector2[] vectors)
        => System.Array.ConvertAll<Vector2, Vector3>(vectors, v => v);

    public static Vector2 Centroid(this ICollection<Vector2> vectors)
        => vectors.Aggregate((agg, next) => agg + next) / vectors.Count();

    public static Vector2 Abs(this Vector2 vector)
        => new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
}
