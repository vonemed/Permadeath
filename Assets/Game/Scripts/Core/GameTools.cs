using System;
using System.Collections.Generic;
using System.Linq;

namespace GameApp
{
    public static class GameTools
    {
        #region helpers

        public static T[] GetRandomElements<T>(T[] collection, int count)
        {
            int collectionLength = collection.Length;
            if (count < 1) count = 1;
            if (collectionLength < count) count = collection.Length;
            var availableIndices = new List<int>();
            for (var i = 0; i < collectionLength; i++) availableIndices.Add(i);
            var elements = new T[count];
            for (var i = 0; i < count; i++)
            {
                int index = UnityEngine.Random.Range(0, availableIndices.Count);
                elements[i] = collection[availableIndices[index]];
                availableIndices.RemoveAt(index);
            }

            return elements;
        }

        public static void ShuffleArray<T>(T[] array)
        {
            for (int i = array.Length - 1; i >= 1; i--)
            {
                int j = UnityEngine.Random.Range(0, i + 1);
                (array[j], array[i]) = (array[i], array[j]);
            }
        }
        
        public static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = UnityEngine.Random.Range(0, n--);
                (array[n], array[k]) = (array[k], array[n]);
            }
        }

        public static void ShuffleList<T>(List<T> list)
        {
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = UnityEngine.Random.Range(0, i + 1);
                (list[j], list[i]) = (list[i], list[j]);
            }
        }

        #endregion

        #region extensions

        public static UnityEngine.Vector3 ConvertTo2D(this UnityEngine.Vector3 v)
        {
            return new UnityEngine.Vector3(v.x, v.z, v.y);
        }

        public static void Alpha(this UnityEngine.UI.Image image, float value)
        {
            image.color = new UnityEngine.Color(image.color.r, image.color.g, image.color.b, value);
        }

        public static void Alpha(this TMPro.TextMeshProUGUI label, float value)
        {
            label.color = new UnityEngine.Color(label.color.r, label.color.g, label.color.b, value);
        }

        public static void ConvertToMinutesSeconds(this float value, out int minutes, out int seconds)
        {
            float t = UnityEngine.Mathf.Max(0, value);
            minutes = (int) t / 60;
            seconds = (int) t % 60;
        }

        public static string ToStringMinSec(this float value)
        {
            float t = UnityEngine.Mathf.Max(0, value);
            int minutes = (int) t / 60;
            int seconds = (int) t % 60;
            return $"{minutes:00}:{seconds:00}";
        }
        
        public static string ToStringMinSec(this int value)
        {
            float t = UnityEngine.Mathf.Max(0, value);
            int minutes = (int) t / 60;
            int seconds = (int) t % 60;
            return $"{minutes:00}:{seconds:00}";
        }

        public static void ConvertToSeconds(this float value, out int seconds)
        {
            float t = UnityEngine.Mathf.Max(0, value);
            seconds = (int) t % 60;
        }

        public static void ConvertToSeconds(this float value, out int seconds, out int milliseconds)
        {
            float t = UnityEngine.Mathf.Max(0, value);
            seconds = (int) t % 60;
            milliseconds = (int) ((value - seconds) * 100);
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            System.Random rnd = new System.Random();
            return source.OrderBy(item => rnd.Next());
        }

        #endregion

        #region misc

        public static string GetRandomPlayerNickname(string prefix = "player")
        {
            if (string.IsNullOrEmpty(prefix)) prefix = "player";
            string[] alphabet =
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };
            string[] gen = new[]
            {
                $"{UnityEngine.Random.Range(0, 99)}",
                alphabet[UnityEngine.Random.Range(0, alphabet.Length)],
                alphabet[UnityEngine.Random.Range(0, alphabet.Length)],
                alphabet[UnityEngine.Random.Range(0, alphabet.Length)],
                $"{UnityEngine.Random.Range(0, 99)}",
                $"{UnityEngine.Random.Range(0, 9)}",
                alphabet[UnityEngine.Random.Range(0, alphabet.Length)]
            };
            return gen.Aggregate($"{prefix}_", (current, g) => $"{current}{g}");
        }


        public static bool IsInRange(in UnityEngine.Vector2 source, in UnityEngine.Vector2 target, in float range)
        {
            return (source - target).sqrMagnitude <= range * range;
        }

        public static bool IsInRange(in UnityEngine.Vector2 source, in UnityEngine.Vector2 target, in float range, out float sqrDistance)
        {
            sqrDistance = (source - target).sqrMagnitude;
            return sqrDistance <= range * range;
        }

        public static bool IsInFlatArea(in UnityEngine.Vector3 source, in UnityEngine.Bounds area)
        {
            return source.x > area.min.x && source.x < area.max.x &&
                   source.z > area.min.z && source.z < area.max.z;
        }

        public static bool IsInArea(in UnityEngine.Vector3 source, in UnityEngine.Bounds area)
        {
            return source.x > area.min.x && source.x < area.max.x &&
                   source.y > area.min.y && source.y < area.max.y &&
                   source.z > area.min.z && source.z < area.max.z;
        }

        public static UnityEngine.Vector3 GetOffsetPosition(in UnityEngine.Vector3 source, in UnityEngine.Vector3 target, in float offset)
        {
            var direction = target - source;
            return source + direction.normalized * (direction.magnitude - offset);
        }

        public static UnityEngine.Quaternion LookAtTarget(in UnityEngine.Vector3 sourcePosition, in UnityEngine.Vector3 targetPosition)
        {
            var direction = UnityEngine.Vector3.Scale(sourcePosition - targetPosition, new UnityEngine.Vector3(1, 0, 1));

            return UnityEngine.Quaternion.LookRotation(direction, UnityEngine.Vector3.up);
        }

        public static int GetLayerIndexFromLayerMask(in UnityEngine.LayerMask layerMask)
        {
            int layerMaskValue = layerMask.value;
            float layerLog = layerMaskValue <= 0 ? 0 : UnityEngine.Mathf.Log(layerMaskValue, 2);
            var layerLogInt = (int) layerLog;
            int layerLogMod = layerLogInt > 0 ? (int) (layerLog % layerLogInt) : 0;
            int layerIndex = layerLogMod == 0 ? layerLogInt : 0;

            return layerIndex;
        }

        public static UnityEngine.Vector2[] GetPointsOnCircle(int pointsCount, float radius, float shiftAngle = 0)
        {
            var points = new UnityEngine.Vector2[pointsCount];
            float step = UnityEngine.Mathf.PI * 2 / pointsCount;
            float shift = shiftAngle * UnityEngine.Mathf.Deg2Rad;
            for (var i = 0; i < pointsCount; i++)
            {
                float sin = UnityEngine.Mathf.Sin(i * step + shift) * radius;
                float cos = UnityEngine.Mathf.Cos(i * step + shift) * radius;
                points[i] = new UnityEngine.Vector2(sin, cos);
            }

            return points;
        }

        public static int GetMinIndexOfEnum<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Min();
        }

        public static int GetMaxIndexOfEnum<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Max();
        }

        public static string RGBAToStringFromColor(UnityEngine.Color color)
        {
            var colorRGBA = $"{color.r}f; {color.g}f; {color.b}f; {color.a}f";
            colorRGBA = colorRGBA.Replace(',', '.');
            colorRGBA = colorRGBA.Replace(';', ',');
            return colorRGBA;
        }

        public static UnityEngine.Bounds GetBoundsOfPoints(in IEnumerable<UnityEngine.Vector3> points)
        {
            var min = UnityEngine.Vector3.positiveInfinity;
            var max = UnityEngine.Vector3.negativeInfinity;
            foreach (var point in points)
            {
                if (point.x < min.x) min.x = point.x;
                if (point.y < min.y) min.y = point.y;
                if (point.z < min.z) min.z = point.z;
                if (point.x > max.x) max.x = point.x;
                if (point.y > max.y) max.y = point.y;
                if (point.z > max.z) max.z = point.z;
            }

            var center = (min + max) / 2;
            return new UnityEngine.Bounds(center, max - min);
        }

        public static UnityEngine.Bounds GetBoundsOfPoints(in List<UnityEngine.Vector3> points)
        {
            var min = UnityEngine.Vector3.positiveInfinity;
            var max = UnityEngine.Vector3.negativeInfinity;
            foreach (var point in points)
            {
                if (point.x < min.x) min.x = point.x;
                if (point.y < min.y) min.y = point.y;
                if (point.z < min.z) min.z = point.z;
                if (point.x > max.x) max.x = point.x;
                if (point.y > max.y) max.y = point.y;
                if (point.z > max.z) max.z = point.z;
            }

            var center = (min + max) / 2;
            return new UnityEngine.Bounds(center, max - min);
        }

        public static int[] GetRandomArray(int amount, out int leader)
        {
            var aList = new List<int>();
            leader = 0;
            for (var i = 0; i < amount; i++)
            {
                aList.Add(i);
            }

            var bList = new List<int>();
            for (var i = 0; i < amount; i++)
            {
                var range = UnityEngine.Random.Range(0, aList.Count);
                bList.Add(aList[range]);
                aList.RemoveAt(range);
            }

            foreach (var i in bList)
            {
                if (i != leader) leader = i;
            }

            return bList.ToArray();
        }


        public static bool GetFirstComponent<T>(this UnityEngine.Transform transform, out T component) where T : UnityEngine.Component
        {
            if (transform.TryGetComponent(out T comp))
            {
                component = comp;
                return true;
            }

            if (transform.Cast<UnityEngine.Transform>().Any(child => GetFirstComponent(child, out comp)))
            {
                component = comp;
                return true;
            }

            component = null;
            return false;
        }

        public static void FindComponentsInParent<T>(in UnityEngine.Transform transform, ref T[] components) where T : UnityEngine.Component
        {
            foreach (UnityEngine.Transform child in transform)
            {
                if (child.TryGetComponent(out T component))
                {
                    Array.Resize(ref components, components.Length + 1);
                    components[components.Length - 1] = component;
                }

                if (child.childCount > 0)
                {
                    FindComponentsInParent(child, ref components);
                }
            }
        }

        public static void FindComponentsInParent<T>(in UnityEngine.Transform transform, ref List<T> components)
        {
            foreach (UnityEngine.Transform child in transform)
            {
                if (child.TryGetComponent(out T component))
                {
                    components.Add(component);
                }

                if (child.childCount > 0)
                {
                    FindComponentsInParent(child, ref components);
                }
            }
        }

        #endregion
    }
}