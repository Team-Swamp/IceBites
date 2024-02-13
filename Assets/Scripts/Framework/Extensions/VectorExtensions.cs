using UnityEngine;

namespace FrameWork.Extensions
{
    /// <summary>
    /// Provides versatile extensions for Vector2 and Vector3, enhancing functionality for various operations.
    /// Ideal for integration into any Unity project.
    /// Extensions:
    /// - Set Axis
    /// - Divide Vector & Axis
    /// - Add Vector & Axis
    /// - Subtract Vector & Axis
    /// - Multiply Vector & Axis
    /// - Compare Vector & Axis (with optional margin)
    /// - Randomize Vector & Axis
    /// - Invert Vector & Axis
    /// - Calculate Midpoint between 2 vectors
    /// - Calculate Weighted Average Vector
    /// - IsWithinRange Vector & Axis
    /// </summary>
    public static class VectorExtensions
    {
        #region Vector 3

        #region Set Axis

        /// <summary>
        /// Change the X vector of this Vector3
        /// </summary>
        /// <param name="v">This vector3.</param>
        /// <param name="x">Target value for the X vector.</param>
        public static ref Vector3 SetX(ref this Vector3 v, float x)
        {
            v.x = x;
            return ref v;
        }

        /// <summary>
        /// Change the Y vector of this Vector3.
        /// </summary>
        /// <param name="v">This vector3.</param>
        /// <param name="y">Target value for the Y vector.</param>
        public static ref Vector3 SetY(ref this Vector3 v, float y)
        {
            v.y = y;
            return ref v;
        }

        /// <summary>
        /// Change the Z vector of this Vector3.
        /// </summary>
        /// <param name="v">This vector3.</param>
        /// <param name="z">Target value for the Z vector.</param>
        public static ref Vector3 SetZ(ref this Vector3 v, float z)
        {
            v.z = z;
            return ref v;
        }

        #endregion

        #region Add

        /// <summary>
        /// Add the Axis of two Vector3 into one.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to add.</param>
        /// <returns>A new Vector3 with combined Axis.</returns>
        public static ref Vector3 Add(ref this Vector3 v, Vector3 f)
        {
            v += f;
            return ref v;
        }

        /// <summary>
        /// Add the specified values to the Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="x">The value to add to the X Axis.</param>
        /// <param name="y">The value to add to the Y Axis.</param>
        /// <param name="z">The value to add to the Z Axis.</param>
        /// <returns>A new Vector3 with updated Axis.</returns>
        public static ref Vector3 Add(ref this Vector3 v, float x, float y, float z) => ref v.AddX(x).AddY(y).AddZ(z);

        /// <summary>
        /// Add the X Axis of two Vector3 into one.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to add.</param>
        /// <returns>A new Vector3 with combined X Axis.</returns>
        public static ref Vector3 AddX(ref this Vector3 v, Vector3 f) => ref v.AddX(f.x);

        /// <summary>
        /// Add the specified value to the X Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="x">The value to add to the X Axis.</param>
        /// <returns>A new Vector3 with updated X Axis.</returns>
        public static ref Vector3 AddX(ref this Vector3 v, float x)
        {
            v.x += x;
            return ref v;
        }

        /// <summary>
        /// Add the Y Axis of two Vector3 into one.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to add.</param>
        /// <returns>A new Vector3 with combined Y Axis.</returns>
        public static ref Vector3 AddY(ref this Vector3 v, Vector3 f) => ref v.AddY(f.y);

        /// <summary>
        /// Add the specified value to the Y Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="y">The value to add to the Y Axis.</param>
        /// <returns>A new Vector3 with updated Y Axis.</returns>
        public static ref Vector3 AddY(ref this Vector3 v, float y)
        {
            v.y += y;
            return ref v;
        }

        /// <summary>
        /// Add the Z Axis of two Vector3 into one.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to add.</param>
        /// <returns>A new Vector3 with combined Z Axis.</returns>
        public static ref Vector3 AddZ(ref this Vector3 v, Vector3 f) => ref v.AddZ(f.z);

        /// <summary>
        /// Add the specified value to the Z Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="z">The value to add to the Z Axis.</param>
        /// <returns>A new Vector3 with updated Z Axis.</returns>
        public static ref Vector3 AddZ(ref this Vector3 v, float z)
        {
            v.z += z;
            return ref v;
        }

        #endregion

        #region Subtract

        /// <summary>
        /// Subtract the Axis of the second Vector3 from the first Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to subtract.</param>
        /// <returns>A new Vector3 with subtracted Axis.</returns>
        public static ref Vector3 Subtract(ref this Vector3 v, Vector3 f)
        {
            v -= f;
            return ref v;
        }

        /// <summary>
        /// Subtract the specified values from the Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="x">The value to subtract from the X Axis.</param>
        /// <param name="y">The value to subtract from the Y Axis.</param>
        /// <param name="z">The value to subtract from the Z Axis.</param>
        /// <returns>A new Vector3 with updated Axis.</returns>
        public static ref Vector3 Subtract(ref this Vector3 v, float x, float y, float z) => ref v.SubtractX(x).SubtractY(y).SubtractZ(z);

        /// <summary>
        /// Subtract the X Axis of the second Vector3 from the first Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to subtract.</param>
        /// <returns>A new Vector3 with subtracted X Axis.</returns>
        public static ref Vector3 SubtractX(ref this Vector3 v, Vector3 f) => ref v.SubtractX(f.x);

        /// <summary>
        /// Subtract the specified value from the X Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="x">The value to subtract from the X Axis.</param>
        /// <returns>A new Vector3 with updated X Axis.</returns>
        public static ref Vector3 SubtractX(ref this Vector3 v, float x)
        {
            v.x -= x;
            return ref v;
        }

        /// <summary>
        /// Subtract the Y Axis of the second Vector3 from the first Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to subtract.</param>
        /// <returns>A new Vector3 with subtracted Y Axis.</returns>
        public static ref Vector3 SubtractY(ref this Vector3 v, Vector3 f) => ref v.SubtractY(f.y);

        /// <summary>
        /// Subtract the specified value from the Y Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="y">The value to subtract from the Y Axis.</param>
        /// <returns>A new Vector3 with updated Y Axis.</returns>
        public static ref Vector3 SubtractY(ref this Vector3 v, float y)
        {
            v.y -= y;
            return ref v;
        }

        /// <summary>
        /// Subtract the Z Axis of the second Vector3 from the first Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to subtract.</param>
        /// <returns>A new Vector3 with subtracted Z Axis.</returns>
        public static ref Vector3 SubtractZ(ref this Vector3 v, Vector3 f) => ref v.SubtractZ(f.z);

        /// <summary>
        /// Subtract the specified value from the Z Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="z">The value to subtract from the Z Axis.</param>
        /// <returns>A new Vector3 with updated Z Axis.</returns>
        public static ref Vector3 SubtractZ(ref this Vector3 v, float z)
        {
            v.z -= z;
            return ref v;
        }

        #endregion
        
        #region Multiply

        /// <summary>
        /// Multiply the Axis of this Vector3 with the corresponding Axis of another Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to multiply.</param>
        /// <returns>A new Vector3 with multiplied Axis.</returns>
        public static ref Vector3 Multiply(ref this Vector3 v, Vector3 f) => ref v.MultiplyX(f.x).MultiplyY(f.y).MultiplyZ(f.z);

        /// <summary>
        /// Multiply the specified values with the Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="x">The value to multiply with the X Axis.</param>
        /// <param name="y">The value to multiply with the Y Axis.</param>
        /// <param name="z">The value to multiply with the Z Axis.</param>
        /// <returns>A new Vector3 with updated Axis.</returns>
        public static ref Vector3 Multiply(ref this Vector3 v, float x, float y, float z) => ref v.MultiplyX(x).MultiplyY(y).MultiplyZ(z);

        /// <summary>
        /// Multiply the X Axis of this Vector3 with the X Axis of another Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to multiply.</param>
        /// <returns>A new Vector3 with multiplied X Axis.</returns>
        public static ref Vector3 MultiplyX(ref this Vector3 v, Vector3 f) => ref v.MultiplyX(f.x);

        /// <summary>
        /// Multiply the specified value with the X Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="x">The value to multiply with the X Axis.</param>
        /// <returns>A new Vector3 with updated X Axis.</returns>
        public static ref Vector3 MultiplyX(ref this Vector3 v, float x)
        {
            v.x *= x;
            return ref v;
        }

        /// <summary>
        /// Multiply the Y Axis of this Vector3 with the Y Axis of another Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to multiply.</param>
        /// <returns>A new Vector3 with multiplied Y Axis.</returns>
        public static ref Vector3 MultiplyY(ref this Vector3 v, Vector3 f) => ref v.MultiplyY(f.y);

        /// <summary>
        /// Multiply the specified value with the Y Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="y">The value to multiply with the Y Axis.</param>
        /// <returns>A new Vector3 with updated Y Axis.</returns>
        public static ref Vector3 MultiplyY(ref this Vector3 v, float y)
        {
            v.y *= y;
            return ref v;
        }

        /// <summary>
        /// Multiply the Z Axis of this Vector3 with the Z Axis of another Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to multiply.</param>
        /// <returns>A new Vector3 with multiplied Z Axis.</returns>
        public static ref Vector3 MultiplyZ(ref this Vector3 v, Vector3 f) => ref v.MultiplyZ(f.z);

        /// <summary>
        /// Multiply the specified value with the Z Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="z">The value to multiply with the Z Axis.</param>
        /// <returns>A new Vector3 with updated Z Axis.</returns>
        public static ref Vector3 MultiplyZ(ref this Vector3 v, float z)
        {
            v.z *= z;
            return ref v;
        }

        #endregion

        #region Divide

        /// <summary>
        /// Divide the Axis of this Vector3 by the corresponding Axis of another Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to divide by.</param>
        /// <returns>A new Vector3 with divided Axis.</returns>
        public static ref Vector3 Divide(ref this Vector3 v, Vector3 f) => ref v.DivideX(f.x).DivideY(f.y).DivideZ(f.z);

        /// <summary>
        /// Divide the specified values by the Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="x">The value to divide by the X Axis.</param>
        /// <param name="y">The value to divide by the Y Axis.</param>
        /// <param name="z">The value to divide by the Z Axis.</param>
        /// <returns>A new Vector3 with updated Axis.</returns>
        public static ref Vector3 Divide(ref this Vector3 v, float x, float y, float z) => ref v.DivideX(x).DivideY(y).DivideZ(z);

        /// <summary>
        /// Divide the X Axis of this Vector3 by the X Axis of another Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to divide by.</param>
        /// <returns>A new Vector3 with divided X Axis.</returns>
        public static ref Vector3 DivideX(ref this Vector3 v, Vector3 f) => ref v.DivideX(f.x);

        /// <summary>
        /// Divide the X Axis of this Vector3 by the specified value and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="x">The value to divide by.</param>
        /// <returns>A new Vector3 with updated X Axis.</returns>
        public static ref Vector3 DivideX(ref this Vector3 v, float x)
        {
            v.x /= x;
            return ref v;
        }

        /// <summary>
        /// Divide the Y Axis of this Vector3 by the Y Axis of another Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to divide by.</param>
        /// <returns>A new Vector3 with divided Y Axis.</returns>
        public static ref Vector3 DivideY(ref this Vector3 v, Vector3 f) => ref v.DivideY(f.y);

        /// <summary>
        /// Divide the Y Axis of this Vector3 by the specified value and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="y">The value to divide by.</param>
        /// <returns>A new Vector3 with updated Y Axis.</returns>
        public static ref Vector3 DivideY(ref this Vector3 v, float y)
        {
            v.y /= y;
            return ref v;
        }

        /// <summary>
        /// Divide the Z Axis of this Vector3 by the Z Axis of another Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The Vector3 to divide by.</param>
        /// <returns>A new Vector3 with divided Z Axis.</returns>
        public static ref Vector3 DivideZ(ref this Vector3 v, Vector3 f) => ref v.DivideZ(f.z);

        /// <summary>
        /// Divide the Z Axis of this Vector3 by the specified value and return the result.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="z">The value to divide by.</param>
        /// <returns>A new Vector3 with updated Z Axis.</returns>
        public static ref Vector3 DivideZ(ref this Vector3 v, float z)
        {
            v.z /= z;
            return ref v;
        }

        #endregion
        
        #region Compare

        /// <summary>
        /// Compare two Vector3 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The f Vector3 to compare with.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the vectors are approximately equal within the specified margin.</returns>
        public static bool Compare(this Vector3 v, Vector3 f, float margin = 0.0001f)
        {
            return v.CompareX(f.x, margin)
                   && v.CompareY(f.y, margin)
                   && v.CompareZ(f.x, margin);
        }

        /// <summary>
        /// Compare the X axis of two Vector3 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The f Vector3 to compare with.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the X axes are approximately equal within the specified margin.</returns>
        public static bool CompareX(this Vector3 v, Vector3 f, float margin = 0.0001f) => v.CompareX(f.x, margin);
        
        /// <summary>
        /// Compare a float value with the X Axis of this Vector3 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="x">The float value to compare with the X Axis.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the X Axis is approximately equal to the specified float value within the margin.</returns>
        public static bool CompareX(this Vector3 v, float x, float margin = 0.0001f) => Mathf.Abs(v.x - x) < margin;

        /// <summary>
        /// Compare the Y axis of two Vector3 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The f Vector3 to compare with.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the Y axes are approximately equal within the specified margin.</returns>
        public static bool CompareY(this Vector3 v, Vector3 f, float margin = 0.0001f) => v.CompareY(f.y, margin);
        
        /// <summary>
        /// Compare a float value with the Y Axis of this Vector3 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="y">The float value to compare with the Y Axis.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the Y Axis is approximately equal to the specified float value within the margin.</returns>
        public static bool CompareY(this Vector3 v, float y, float margin = 0.0001f) => Mathf.Abs(v.y - y) < margin;

        /// <summary>
        /// Compare the Z axis of two Vector3 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The f Vector3 to compare with.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the Z axes are approximately equal within the specified margin.</returns>
        public static bool CompareZ(this Vector3 v, Vector3 f, float margin = 0.0001f) => v.CompareZ(f.z, margin);

        /// <summary>
        /// Compare a float value with the Z Axis of this Vector3 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="z">The float value to compare with the Z Axis.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the Z Axis is approximately equal to the specified float value within the margin.</returns>
        public static bool CompareZ(this Vector3 v, float z, float margin = 0.0001f) => Mathf.Abs(v.z - z) < margin;

        #endregion

        #region Randomize

        /// <summary>
        /// Randomize the X, Y, and Z axes of this Vector3 within specified ranges.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="xRange">Range for the X axis.</param>
        /// <param name="yRange">Range for the Y axis.</param>
        /// <param name="zRange">Range for the Z axis.</param>
        /// <returns>A new Vector3 with randomized axes.</returns>
        public static ref Vector3 Randomize(ref this Vector3 v, Vector2 xRange, Vector2 yRange, Vector2 zRange)
        {
            v.RandomizeX(xRange);
            v.RandomizeY(yRange);
            v.RandomizeZ(zRange);
            return ref v;
        }
        
        /// <summary>
        /// Randomize the X, Y, and Z axes of this Vector3 within the specified range.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="range">Range for all axes.</param>
        /// <returns>A new Vector3 with randomized axes.</returns>
        public static ref Vector3 Randomize(ref this Vector3 v, Vector2 range)
        {
            v.RandomizeX(range);
            v.RandomizeY(range);
            v.RandomizeZ(range);
            return ref v;
        }
        
        /// <summary>
        /// Randomize all axes of this Vector3 with the same random number within the specified range.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="range">Range for all axes.</param>
        /// <returns>A new Vector3 with the same randomized value for all axes.</returns>
        public static ref Vector3 RandomizeUniform(ref this Vector3 v, Vector2 range)
        {
            float randomValue = Random.Range(range.x, range.y);
            v.x = randomValue;
            v.y = randomValue;
            v.z = randomValue;
            return ref v;
        }

        /// <summary>
        /// Randomize the X axis of this Vector3 within a specified range.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="xRange">Range for the X axis.</param>
        /// <returns>A new Vector3 with a randomized X axis.</returns>
        public static ref Vector3 RandomizeX(ref this Vector3 v, Vector2 xRange)
        {
            v.x = Random.Range(xRange.x, xRange.y);
            return ref v;
        }

        /// <summary>
        /// Randomize the Y axis of this Vector3 within a specified range.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="yRange">Range for the Y axis.</param>
        /// <returns>A new Vector3 with a randomized Y axis.</returns>
        public static ref Vector3 RandomizeY(ref this Vector3 v, Vector2 yRange)
        {
            v.y = Random.Range(yRange.x, yRange.y);
            return ref v;
        }

        /// <summary>
        /// Randomize the Z axis of this Vector3 within a specified range.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="zRange">Range for the Z axis.</param>
        /// <returns>A new Vector3 with a randomized Z axis.</returns>
        public static ref Vector3 RandomizeZ(ref this Vector3 v, Vector2 zRange)
        {
            v.z = Random.Range(zRange.x, zRange.y);
            return ref v;
        }
        
        #endregion

        #region Invert

        /// <summary>
        /// Invert the X, Y, and Z axes of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <returns>The Vector3 with inverted axes.</returns>
        public static ref Vector3 Invert(ref this Vector3 v) => ref v.InvertX().InvertY().InvertZ();
        
        /// <summary>
        /// Invert the X axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <returns>The Vector3 with the inverted X axis.</returns>
        public static ref Vector3 InvertX(ref this Vector3 v)
        {
            v.x = -v.x;
            return ref v;
        }

        /// <summary>
        /// Invert the Y axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <returns>The Vector3 with the inverted Y axis.</returns>
        public static ref Vector3 InvertY(ref this Vector3 v)
        {
            v.y = -v.y;
            return ref v;
        }

        /// <summary>
        /// Invert the Z axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <returns>The Vector3 with the inverted Z axis.</returns>
        public static ref Vector3 InvertZ(ref this Vector3 v)
        {
            v.z = -v.z;
            return ref v;
        }

        #endregion

        #region Midpoint

        /// <summary>
        /// Calculate the midpoint between two Vector3.
        /// </summary>
        /// <param name="v">The first Vector3.</param>
        /// <param name="f">The second Vector3.</param>
        /// <returns>The midpoint Vector3.</returns>
        public static Vector3 Midpoint(this Vector3 v, Vector3 f)
        {
            return v.Add(f) / 2;
        }
        
        /// <summary>
        /// Calculate the weighted average of two Vector3 based on specified weight.
        /// </summary>
        /// <param name="v">The first Vector3.</param>
        /// <param name="f">The second Vector3.</param>
        /// <param name="weight">Weight for the first Vector3. Should be in the range [0, 100], it's a percentage.</param>
        /// <returns>The weighted average Vector3.</returns>
        public static Vector3 WeightedAverage(this Vector3 v, Vector3 f, float weight)
        {
            const float TOTAL_WEIGHT = 100f;
            float weightF = TOTAL_WEIGHT - weight;

            Vector3 weightedV = v * weight;
            Vector3 weightedF = f * weightF;

            return weightedV.Add(weightedF) / TOTAL_WEIGHT;
        }

        #endregion
        
        #region IsWithinRange

        /// <summary>
        /// Checks if this Vector3 is within the specified range of another Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The target Vector3.</param>
        /// <param name="range">The range within which the f Vector3 is considered "within."</param>
        /// <returns>True if the f Vector3 is within the specified range; otherwise, false.</returns>
        public static bool IsWithinRange(this Vector3 v, Vector3 f, float range)
        {
            float distance = Vector3.Distance(v, f);
            return distance <= range;
        }

        /// <summary>
        /// Checks if the X Axis of this Vector3 is within the specified range of the X Axis of another Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The f Vector3 to compare with.</param>
        /// <param name="range">The range within which the X Axis are considered "within."</param>
        /// <returns>True if the X Axis are within the specified range; otherwise, false.</returns>
        public static bool IsXWithinRange(this Vector3 v, Vector3 f, float range)
        {
            return Mathf.Abs(v.x - f.x) <= range;
        }

        /// <summary>
        /// Checks if the Y Axis of this Vector3 is within the specified range of the Y Axis of another Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The f Vector3 to compare with.</param>
        /// <param name="range">The range within which the Y Axis are considered "within."</param>
        /// <returns>True if the Y Axis are within the specified range; otherwise, false.</returns>
        public static bool IsYWithinRange(this Vector3 v, Vector3 f, float range)
        {
            return Mathf.Abs(v.y - f.y) <= range;
        }

        /// <summary>
        /// Checks if the Z Axis of this Vector3 is within the specified range of the Z Axis of another Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="f">The f Vector3 to compare with.</param>
        /// <param name="range">The range within which the Z Axis are considered "within."</param>
        /// <returns>True if the Z Axis are within the specified range; otherwise, false.</returns>
        public static bool IsZWithinRange(this Vector3 v, Vector3 f, float range)
        {
            return Mathf.Abs(v.z - f.z) <= range;
        }

        #endregion

        #endregion

        #region Vector 2

        #region Change Axis

        /// <summary>
        /// Change the X vector of this Vector2 in place.
        /// </summary>
        /// <param name="v">This vector2.</param>
        /// <param name="x">Target value for the X vector.</param>
        public static ref Vector2 SetX(ref this Vector2 v, float x)
        {
            v.x = x;
            return ref v;
        }

        /// <summary>
        /// Change the Y vector of this Vector2.
        /// </summary>
        /// <param name="v">This vector2.</param>
        /// <param name="y">Target value for the Y vector.</param>
        public static ref Vector2 SetY(ref this Vector2 v, float y)
        {
            v.y = y;
            return ref v;
        }

        #endregion

        #region Add

        /// <summary>
        /// Add the Axis of two Vector2 into one.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to add.</param>
        /// <returns>A new Vector2 with combined Axis.</returns>
        public static ref Vector2 Add(ref this Vector2 v, Vector2 f)
        {
            v += f;
            return ref v;
        }

        /// <summary>
        /// Add the specified values to the Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="x">The value to add to the X Axis.</param>
        /// <param name="y">The value to add to the Y Axis.</param>
        /// <returns>A new Vector2 with updated Axis.</returns>
        public static ref Vector2 Add(ref this Vector2 v, float x, float y) => ref v.AddX(x).AddY(y);

        /// <summary>
        /// Add the X Axis of two Vector2 into one.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to add.</param>
        /// <returns>A new Vector2 with combined X Axis.</returns>
        public static ref Vector2 AddX(ref this Vector2 v, Vector2 f) => ref v.AddX(f.x);

        /// <summary>
        /// Add the specified value to the X Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="x">The value to add to the X Axis.</param>
        /// <returns>A new Vector2 with updated X Axis.</returns>
        public static ref Vector2 AddX(ref this Vector2 v, float x)
        {
            v.x += x;
            return ref v;
        }

        /// <summary>
        /// Add the Y Axis of two Vector2 into one.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to add.</param>
        /// <returns>A new Vector2 with combined Y Axis.</returns>
        public static ref Vector2 AddY(ref this Vector2 v, Vector2 f) => ref v.AddY(f.y);

        /// <summary>
        /// Add the specified value to the Y Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="y">The value to add to the Y Axis.</param>
        /// <returns>A new Vector2 with updated Y Axis.</returns>
        public static ref Vector2 AddY(ref this Vector2 v, float y)
        {
            v.y += y;
            return ref v;
        }

        #endregion

        #region Subtract

        /// <summary>
        /// Subtract the Axis of the second Vector2 from the first Vector2 and return the result.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to subtract.</param>
        /// <returns>A new Vector2 with subtracted Axis.</returns>
        public static ref Vector2 Subtract(ref this Vector2 v, Vector2 f)
        {
            v -= f;
            return ref v;
        }

        /// <summary>
        /// Subtract the specified values from the Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="x">The value to subtract from the X Axis.</param>
        /// <param name="y">The value to subtract from the Y Axis.</param>
        /// <returns>A new Vector2 with updated Axis.</returns>
        public static ref Vector2 Subtract(ref this Vector2 v, float x, float y) => ref v.SubtractX(x).SubtractY(y);

        /// <summary>
        /// Subtract the X Axis of the second Vector2 from the first Vector2 and return the result.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to subtract.</param>
        /// <returns>A new Vector2 with subtracted X Axis.</returns>
        public static ref Vector2 SubtractX(ref this Vector2 v, Vector2 f) => ref v.SubtractX(f.x);

        /// <summary>
        /// Subtract the specified value from the X Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="x">The value to subtract from the X Axis.</param>
        /// <returns>A new Vector2 with updated X Axis.</returns>
        public static ref Vector2 SubtractX(ref this Vector2 v, float x)
        {
            v.x -= x;
            return ref v;
        }

        /// <summary>
        /// Subtract the Y Axis of the second Vector2 from the first Vector2 and return the result.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to subtract.</param>
        /// <returns>A new Vector2 with subtracted Y Axis.</returns>
        public static ref Vector2 SubtractY(ref this Vector2 v, Vector2 f) => ref v.SubtractY(f.y);

        /// <summary>
        /// Subtract the specified value from the Y Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="y">The value to subtract from the Y Axis.</param>
        /// <returns>A new Vector2 with updated Y Axis.</returns>
        public static ref Vector2 SubtractY(ref this Vector2 v, float y)
        {
            v.y -= y;
            return ref v;
        }

        #endregion
        
        #region Multiply

        /// <summary>
        /// Multiply the Axis of this Vector2 with the corresponding Axis of another Vector2 and return the result.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to multiply.</param>
        /// <returns>A new Vector2 with multiplied Axis.</returns>
        public static ref Vector2 Multiply(ref this Vector2 v, Vector2 f) => ref v.MultiplyX(f.x).MultiplyY(f.y);

        /// <summary>
        /// Multiply the specified values with the Axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <param name="x">The value to multiply with the X Axis.</param>
        /// <param name="y">The value to multiply with the Y Axis.</param>
        /// <returns>A new Vector2 with updated Axis.</returns>
        public static ref Vector2 Multiply(ref this Vector2 v, float x, float y) => ref v.MultiplyX(x).MultiplyY(y);

        /// <summary>
        /// Multiply the X Axis of this Vector2 with the X Axis of another Vector2 and return the result.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to multiply.</param>
        /// <returns>A new Vector2 with multiplied X Axis.</returns>
        public static ref Vector2 MultiplyX(ref this Vector2 v, Vector2 f) => ref v.MultiplyX(f.x);

        /// <summary>
        /// Multiply the specified value with the X Axis of this Vector2.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="x">The value to multiply with the X Axis.</param>
        /// <returns>A new Vector2 with updated X Axis.</returns>
        public static ref Vector2 MultiplyX(ref this Vector2 v, float x)
        {
            v.x *= x;
            return ref v;
        }

        /// <summary>
        /// Multiply the Y Axis of this Vector2 with the Y Axis of another Vector2 and return the result.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to multiply.</param>
        /// <returns>A new Vector2 with multiplied Y Axis.</returns>
        public static ref Vector2 MultiplyY(ref this Vector2 v, Vector2 f) => ref v.MultiplyY(f.y);

        /// <summary>
        /// Multiply the specified value with the Y Axis of this Vector2.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="y">The value to multiply with the Y Axis.</param>
        /// <returns>A new Vector2 with updated Y Axis.</returns>
        public static ref Vector2 MultiplyY(ref this Vector2 v, float y)
        {
            v.y *= y;
            return ref v;
        }

        #endregion

        #region Divide

        /// <summary>
        /// Divide the Axis of this Vector2 by the corresponding Axis of another Vector2 and return the result.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to divide by.</param>
        /// <returns>A new Vector2 with divided Axis.</returns>
        public static ref Vector2 Divide(ref this Vector2 v, Vector2 f) => ref v.DivideX(f.x).DivideY(f.y);

        /// <summary>
        /// Divide the specified values by the Axis of this Vector2.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="x">The value to divide by the X Axis.</param>
        /// <param name="y">The value to divide by the Y Axis.</param>
        /// <returns>A new Vector2 with updated Axis.</returns>
        public static ref Vector2 Divide(ref this Vector2 v, float x, float y) => ref v.DivideX(x).DivideY(y);

        /// <summary>
        /// Divide the X Axis of this Vector2 by the X Axis of another Vector3 and return the result.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to divide by.</param>
        /// <returns>A new Vector2 with divided X Axis.</returns>
        public static ref Vector2 DivideX(ref this Vector2 v, Vector2 f) => ref v.DivideX(f.x);

        /// <summary>
        /// Divide the X Axis of this Vector2 by the specified value and return the result.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="x">The value to divide by.</param>
        /// <returns>A new Vector2 with updated X Axis.</returns>
        public static ref Vector2 DivideX(ref this Vector2 v, float x)
        {
            v.x /= x;
            return ref v;
        }

        /// <summary>
        /// Divide the Y Axis of this Vector2 by the Y Axis of another Vector2 and return the result.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The Vector2 to divide by.</param>
        /// <returns>A new Vector2 with divided Y Axis.</returns>
        public static ref Vector2 DivideY(ref this Vector2 v, Vector2 f) => ref v.DivideY(f.y);

        /// <summary>
        /// Divide the Y Axis of this Vector2 by the specified value and return the result.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="y">The value to divide by.</param>
        /// <returns>A new Vector2 with updated Y Axis.</returns>
        public static ref Vector2 DivideY(ref this Vector2 v, float y)
        {
            v.y /= y;
            return ref v;
        }

        #endregion
        
        #region Compare

        /// <summary>
        /// Compare two Vector2 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The f Vector2 to compare with.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the vectors are approximately equal within the specified margin.</returns>
        public static bool Compare(this Vector2 v, Vector2 f, float margin = 0.0001f)
        {
            return v.CompareX(f.x, margin)
                   && v.CompareY(f.y, margin);
        }

        /// <summary>
        /// Compare the X axis of two Vector2 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The f Vector2 to compare with.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the X axes are approximately equal within the specified margin.</returns>
        public static bool CompareX(this Vector2 v, Vector2 f, float margin = 0.0001f) => v.CompareX(f.x, margin);
        
        /// <summary>
        /// Compare a float value with the X Axis of this Vector2 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="x">The float value to compare with the X Axis.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the X Axis is approximately equal to the specified float value within the margin.</returns>
        public static bool CompareX(this Vector2 v, float x, float margin = 0.0001f) => Mathf.Abs(v.x - x) < margin;

        /// <summary>
        /// Compare the Y axis of two Vector2 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The f Vector2 to compare with.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the Y axes are approximately equal within the specified margin.</returns>
        public static bool CompareY(this Vector2 v, Vector2 f, float margin = 0.0001f) => v.CompareY(f.y, margin);
        
        /// <summary>
        /// Compare a float value with the Y Axis of this Vector2 with an optional margin for floating-point precision.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="y">The float value to compare with the Y Axis.</param>
        /// <param name="margin">Optional margin for floating-point precision. Default is 0.</param>
        /// <returns>True if the Y Axis is approximately equal to the specified float value within the margin.</returns>
        public static bool CompareY(this Vector2 v, float y, float margin = 0.0001f) => Mathf.Abs(v.y - y) < margin;

        #endregion

        #region Randomize

        /// <summary>
        /// Randomize the X, Y, and Z axes of this Vector2 within specified ranges.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="xRange">Range for the X axis.</param>
        /// <param name="yRange">Range for the Y axis.</param>
        /// <returns>A new Vector2 with randomized axes.</returns>
        public static ref Vector2 Randomize(ref this Vector2 v, Vector2 xRange, Vector2 yRange)
        {
            v.RandomizeX(xRange);
            v.RandomizeY(yRange);
            return ref v;
        }
        
        /// <summary>
        /// Randomize the X and Y Axis of this Vector2 within the specified range.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="range">Range for X and Y Axis.</param>
        /// <returns>A new Vector2 with randomized X and Y Axis.</returns>
        public static ref Vector2 Randomize(ref this Vector2 v, Vector2 range)
        {
            v.RandomizeX(range);
            v.RandomizeY(range);
            return ref v;
        }

        /// <summary>
        /// Randomize both Axis of this Vector2 with the same random number within the specified range.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="range">Range for both Axis.</param>
        /// <returns>A new Vector2 with the same randomized value for both Axis.</returns>
        public static ref Vector2 RandomizeUniform(ref this Vector2 v, Vector2 range)
        {
            float randomValue = Random.Range(range.x, range.y);
            v.x = randomValue;
            v.y = randomValue;
            return ref v;
        }

        /// <summary>
        /// Randomize the X axis of this Vector2 within a specified range.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="xRange">Range for the X axis.</param>
        /// <returns>A new Vector2 with a randomized X axis.</returns>
        public static ref Vector2 RandomizeX(ref this Vector2 v, Vector2 xRange)
        {
            v.x = Random.Range(xRange.x, xRange.y);
            return ref v;
        }

        /// <summary>
        /// Randomize the Y axis of this Vector2 within a specified range.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="yRange">Range for the Y axis.</param>
        /// <returns>A new Vector2 with a randomized Y axis.</returns>
        public static ref Vector2 RandomizeY(ref this Vector2 v, Vector2 yRange)
        {
            v.y = Random.Range(yRange.x, yRange.y);
            return ref v;
        }

        #endregion

        #region Invert

        /// <summary>
        /// Invert the X, Y, and Z axes of this Vector2.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <returns>The Vector3 with inverted axes.</returns>
        public static ref Vector2 Invert(ref this Vector2 v) => ref v.InvertX().InvertY();
        
        /// <summary>
        /// Invert the X axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <returns>The Vector3 with the inverted X axis.</returns>
        public static ref Vector2 InvertX(ref this Vector2 v)
        {
            v.x = -v.x;
            return ref v;
        }

        /// <summary>
        /// Invert the Y axis of this Vector3.
        /// </summary>
        /// <param name="v">This Vector3.</param>
        /// <returns>The Vector3 with the inverted Y axis.</returns>
        public static ref Vector2 InvertY(ref this Vector2 v)
        {
            v.y = -v.y;
            return ref v;
        }

        #endregion
        
        #region Midpoint

        /// <summary>
        /// Calculate the midpoint between two Vector2.
        /// </summary>
        /// <param name="v">The first Vector2.</param>
        /// <param name="f">The second Vector2.</param>
        /// <returns>The midpoint Vector2.</returns>
        public static Vector2 Midpoint(this Vector2 v, Vector2 f)
        {
            return v.Add(f) / 2;
        }

        /// <summary>
        /// Calculate the weighted average of two Vector2 based on specified weight.
        /// </summary>
        /// <param name="v">The first Vector2.</param>
        /// <param name="f">The second Vector2.</param>
        /// <param name="weight">Weight for the first Vector2. Should be in the range [0, 100], it's a percentage.</param>
        /// <returns>The weighted average Vector2.</returns>
        public static Vector2 WeightedAverage(this Vector2 v, Vector2 f, float weight)
        {
            const float TOTAL_WEIGHT = 100f;
            float weightF = TOTAL_WEIGHT - weight;

            Vector2 weightedV = v * weight;
            Vector2 weightedF = f * weightF;

            return weightedV.Add(weightedF) / TOTAL_WEIGHT;
        }

        #endregion

        #region IsWithinRange

        /// <summary>
        /// Checks if this Vector2 is within the specified range of another Vector2.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The target Vector2.</param>
        /// <param name="range">The range within which the f Vector2 is considered "within."</param>
        /// <returns>True if the f Vector2 is within the specified range; otherwise, false.</returns>
        public static bool IsWithinRange(this Vector2 v, Vector2 f, float range)
        {
            float distance = Vector2.Distance(v, f);
            return distance <= range;
        }

        /// <summary>
        /// Checks if the X Axis of this Vector2 is within the specified range of the X Axis of another Vector2.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The f Vector2 to compare with.</param>
        /// <param name="range">The range within which the X Axis are considered "within."</param>
        /// <returns>True if the X Axis are within the specified range; otherwise, false.</returns>
        public static bool IsXWithinRange(this Vector2 v, Vector2 f, float range)
        {
            return Mathf.Abs(v.x - f.x) <= range;
        }

        /// <summary>
        /// Checks if the Y Axis of this Vector2 is within the specified range of the Y Axis of another Vector2.
        /// </summary>
        /// <param name="v">This Vector2.</param>
        /// <param name="f">The f Vector2 to compare with.</param>
        /// <param name="range">The range within which the Y Axis are considered "within."</param>
        /// <returns>True if the Y Axis are within the specified range; otherwise, false.</returns>
        public static bool IsYWithinRange(this Vector2 v, Vector2 f, float range)
        {
            return Mathf.Abs(v.y - f.y) <= range;
        }
        
        #endregion

        #endregion
    }
}