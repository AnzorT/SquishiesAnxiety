// The slice of three.js (r166, node_modules/three) that Squish Time's stage computes with, ported operation for
// operation in doubles as JavaScript does, so the port picks, dents and places the card bit for bit like the app:
// Vector3 (applyMatrix4, normalize), Euler XYZ -> Quaternion, Matrix4 (compose, invert, multiply, lookAt,
// makePerspective), Quaternion.setFromRotationMatrix, the PerspectiveCamera R3F makes (fov, position, lookAt(0, 0, 0))
// and Raycaster.setFromCamera / Ray.applyMatrix4. No Unity types: tools/unity/squish-test checks it against three.
using System;

namespace SquishSquad.Games.Squish
{
    public struct V3
    {
        public double X, Y, Z;
        public V3(double x, double y, double z) { X = x; Y = y; Z = z; }
        public static V3 operator +(V3 a, V3 b) => new V3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static V3 operator -(V3 a, V3 b) => new V3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static V3 operator *(V3 a, double k) => new V3(a.X * k, a.Y * k, a.Z * k);
        public double Dot(V3 b) => X * b.X + Y * b.Y + Z * b.Z;
        public double LengthSq => X * X + Y * Y + Z * Z;
        public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);
        // three: divideScalar(length() || 1) = multiplyScalar(1 / len)
        public V3 Normalized() { double l = Length; if (l == 0) l = 1; double k = 1 / l; return new V3(X * k, Y * k, Z * k); }
        public static V3 Cross(V3 a, V3 b) => new V3(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        // Vector3.lerp
        public V3 Lerp(V3 v, double a) => new V3(X + (v.X - X) * a, Y + (v.Y - Y) * a, Z + (v.Z - Z) * a);
        // Vector3.applyMatrix4 (with the perspective divide)
        public V3 ApplyMatrix4(double[] e)
        {
            double w = 1 / (e[3] * X + e[7] * Y + e[11] * Z + e[15]);
            return new V3((e[0] * X + e[4] * Y + e[8] * Z + e[12]) * w, (e[1] * X + e[5] * Y + e[9] * Z + e[13]) * w, (e[2] * X + e[6] * Y + e[10] * Z + e[14]) * w);
        }
        public override string ToString() => $"({X}, {Y}, {Z})";
    }

    public struct Quat
    {
        public double X, Y, Z, W;
        public Quat(double x, double y, double z, double w) { X = x; Y = y; Z = z; W = w; }

        // Quaternion.setFromEuler, order 'XYZ' (Object3D's default)
        public static Quat FromEulerXYZ(double x, double y, double z)
        {
            double c1 = Math.Cos(x / 2), c2 = Math.Cos(y / 2), c3 = Math.Cos(z / 2);
            double s1 = Math.Sin(x / 2), s2 = Math.Sin(y / 2), s3 = Math.Sin(z / 2);
            return new Quat(s1 * c2 * c3 + c1 * s2 * s3, c1 * s2 * c3 - s1 * c2 * s3, c1 * c2 * s3 + s1 * s2 * c3, c1 * c2 * c3 - s1 * s2 * s3);
        }

        // Quaternion.setFromRotationMatrix (the upper 3x3 of a pure rotation)
        public static Quat FromRotationMatrix(double[] te)
        {
            double m11 = te[0], m12 = te[4], m13 = te[8], m21 = te[1], m22 = te[5], m23 = te[9], m31 = te[2], m32 = te[6], m33 = te[10];
            double trace = m11 + m22 + m33, s;
            if (trace > 0)
            {
                s = 0.5 / Math.Sqrt(trace + 1.0);
                return new Quat((m32 - m23) * s, (m13 - m31) * s, (m21 - m12) * s, 0.25 / s);
            }
            if (m11 > m22 && m11 > m33)
            {
                s = 2.0 * Math.Sqrt(1.0 + m11 - m22 - m33);
                return new Quat(0.25 * s, (m12 + m21) / s, (m13 + m31) / s, (m32 - m23) / s);
            }
            if (m22 > m33)
            {
                s = 2.0 * Math.Sqrt(1.0 + m22 - m11 - m33);
                return new Quat((m12 + m21) / s, 0.25 * s, (m23 + m32) / s, (m13 - m31) / s);
            }
            s = 2.0 * Math.Sqrt(1.0 + m33 - m11 - m22);
            return new Quat((m13 + m31) / s, (m23 + m32) / s, 0.25 * s, (m21 - m12) / s);
        }
    }

    /// <summary>three's Matrix4: 16 doubles, column-major (elements[col * 4 + row]).</summary>
    public static class M4
    {
        public static double[] Identity() => new double[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };

        public static double[] Compose(V3 p, Quat q, V3 s)
        {
            var te = new double[16];
            double x = q.X, y = q.Y, z = q.Z, w = q.W;
            double x2 = x + x, y2 = y + y, z2 = z + z;
            double xx = x * x2, xy = x * y2, xz = x * z2;
            double yy = y * y2, yz = y * z2, zz = z * z2;
            double wx = w * x2, wy = w * y2, wz = w * z2;
            double sx = s.X, sy = s.Y, sz = s.Z;
            te[0] = (1 - (yy + zz)) * sx; te[1] = (xy + wz) * sx; te[2] = (xz - wy) * sx; te[3] = 0;
            te[4] = (xy - wz) * sy; te[5] = (1 - (xx + zz)) * sy; te[6] = (yz + wx) * sy; te[7] = 0;
            te[8] = (xz + wy) * sz; te[9] = (yz - wx) * sz; te[10] = (1 - (xx + yy)) * sz; te[11] = 0;
            te[12] = p.X; te[13] = p.Y; te[14] = p.Z; te[15] = 1;
            return te;
        }

        public static double[] Invert(double[] m)
        {
            var te = new double[16];
            double n11 = m[0], n21 = m[1], n31 = m[2], n41 = m[3], n12 = m[4], n22 = m[5], n32 = m[6], n42 = m[7],
                n13 = m[8], n23 = m[9], n33 = m[10], n43 = m[11], n14 = m[12], n24 = m[13], n34 = m[14], n44 = m[15];
            double t11 = n23 * n34 * n42 - n24 * n33 * n42 + n24 * n32 * n43 - n22 * n34 * n43 - n23 * n32 * n44 + n22 * n33 * n44;
            double t12 = n14 * n33 * n42 - n13 * n34 * n42 - n14 * n32 * n43 + n12 * n34 * n43 + n13 * n32 * n44 - n12 * n33 * n44;
            double t13 = n13 * n24 * n42 - n14 * n23 * n42 + n14 * n22 * n43 - n12 * n24 * n43 - n13 * n22 * n44 + n12 * n23 * n44;
            double t14 = n14 * n23 * n32 - n13 * n24 * n32 - n14 * n22 * n33 + n12 * n24 * n33 + n13 * n22 * n34 - n12 * n23 * n34;
            double det = n11 * t11 + n21 * t12 + n31 * t13 + n41 * t14;
            if (det == 0) return te;
            double detInv = 1 / det;
            te[0] = t11 * detInv;
            te[1] = (n24 * n33 * n41 - n23 * n34 * n41 - n24 * n31 * n43 + n21 * n34 * n43 + n23 * n31 * n44 - n21 * n33 * n44) * detInv;
            te[2] = (n22 * n34 * n41 - n24 * n32 * n41 + n24 * n31 * n42 - n21 * n34 * n42 - n22 * n31 * n44 + n21 * n32 * n44) * detInv;
            te[3] = (n23 * n32 * n41 - n22 * n33 * n41 - n23 * n31 * n42 + n21 * n33 * n42 + n22 * n31 * n43 - n21 * n32 * n43) * detInv;
            te[4] = t12 * detInv;
            te[5] = (n13 * n34 * n41 - n14 * n33 * n41 + n14 * n31 * n43 - n11 * n34 * n43 - n13 * n31 * n44 + n11 * n33 * n44) * detInv;
            te[6] = (n14 * n32 * n41 - n12 * n34 * n41 - n14 * n31 * n42 + n11 * n34 * n42 + n12 * n31 * n44 - n11 * n32 * n44) * detInv;
            te[7] = (n12 * n33 * n41 - n13 * n32 * n41 + n13 * n31 * n42 - n11 * n33 * n42 - n12 * n31 * n43 + n11 * n32 * n43) * detInv;
            te[8] = t13 * detInv;
            te[9] = (n14 * n23 * n41 - n13 * n24 * n41 - n14 * n21 * n43 + n11 * n24 * n43 + n13 * n21 * n44 - n11 * n23 * n44) * detInv;
            te[10] = (n12 * n24 * n41 - n14 * n22 * n41 + n14 * n21 * n42 - n11 * n24 * n42 - n12 * n21 * n44 + n11 * n22 * n44) * detInv;
            te[11] = (n13 * n22 * n41 - n12 * n23 * n41 - n13 * n21 * n42 + n11 * n23 * n42 + n12 * n21 * n43 - n11 * n22 * n43) * detInv;
            te[12] = t14 * detInv;
            te[13] = (n13 * n24 * n31 - n14 * n23 * n31 + n14 * n21 * n33 - n11 * n24 * n33 - n13 * n21 * n34 + n11 * n23 * n34) * detInv;
            te[14] = (n14 * n22 * n31 - n12 * n24 * n31 - n14 * n21 * n32 + n11 * n24 * n32 + n12 * n21 * n34 - n11 * n22 * n34) * detInv;
            te[15] = (n12 * n23 * n31 - n13 * n22 * n31 + n13 * n21 * n32 - n11 * n23 * n32 - n12 * n21 * n33 + n11 * n22 * n33) * detInv;
            return te;
        }

        // multiplyMatrices(a, b) = a * b
        public static double[] Multiply(double[] ae, double[] be)
        {
            var te = new double[16];
            double a11 = ae[0], a12 = ae[4], a13 = ae[8], a14 = ae[12], a21 = ae[1], a22 = ae[5], a23 = ae[9], a24 = ae[13];
            double a31 = ae[2], a32 = ae[6], a33 = ae[10], a34 = ae[14], a41 = ae[3], a42 = ae[7], a43 = ae[11], a44 = ae[15];
            double b11 = be[0], b12 = be[4], b13 = be[8], b14 = be[12], b21 = be[1], b22 = be[5], b23 = be[9], b24 = be[13];
            double b31 = be[2], b32 = be[6], b33 = be[10], b34 = be[14], b41 = be[3], b42 = be[7], b43 = be[11], b44 = be[15];
            te[0] = a11 * b11 + a12 * b21 + a13 * b31 + a14 * b41;
            te[4] = a11 * b12 + a12 * b22 + a13 * b32 + a14 * b42;
            te[8] = a11 * b13 + a12 * b23 + a13 * b33 + a14 * b43;
            te[12] = a11 * b14 + a12 * b24 + a13 * b34 + a14 * b44;
            te[1] = a21 * b11 + a22 * b21 + a23 * b31 + a24 * b41;
            te[5] = a21 * b12 + a22 * b22 + a23 * b32 + a24 * b42;
            te[9] = a21 * b13 + a22 * b23 + a23 * b33 + a24 * b43;
            te[13] = a21 * b14 + a22 * b24 + a23 * b34 + a24 * b44;
            te[2] = a31 * b11 + a32 * b21 + a33 * b31 + a34 * b41;
            te[6] = a31 * b12 + a32 * b22 + a33 * b32 + a34 * b42;
            te[10] = a31 * b13 + a32 * b23 + a33 * b33 + a34 * b43;
            te[14] = a31 * b14 + a32 * b24 + a33 * b34 + a34 * b44;
            te[3] = a41 * b11 + a42 * b21 + a43 * b31 + a44 * b41;
            te[7] = a41 * b12 + a42 * b22 + a43 * b32 + a44 * b42;
            te[11] = a41 * b13 + a42 * b23 + a43 * b33 + a44 * b43;
            te[15] = a41 * b14 + a42 * b24 + a43 * b34 + a44 * b44;
            return te;
        }

        // Matrix4.lookAt(eye, target, up): the rotation part only
        public static double[] LookAt(V3 eye, V3 target, V3 up)
        {
            var te = Identity();
            var z = eye - target;
            if (z.LengthSq == 0) z.Z = 1;
            z = z.Normalized();
            var x = V3.Cross(up, z);
            if (x.LengthSq == 0)
            {
                if (Math.Abs(up.Z) == 1) z.X += 0.0001; else z.Z += 0.0001;
                z = z.Normalized();
                x = V3.Cross(up, z);
            }
            x = x.Normalized();
            var y = V3.Cross(z, x);
            te[0] = x.X; te[4] = y.X; te[8] = z.X;
            te[1] = x.Y; te[5] = y.Y; te[9] = z.Y;
            te[2] = x.Z; te[6] = y.Z; te[10] = z.Z;
            return te;
        }

        public static double[] MakePerspective(double left, double right, double top, double bottom, double near, double far)
        {
            var te = new double[16];
            double x = 2 * near / (right - left), y = 2 * near / (top - bottom);
            double a = (right + left) / (right - left), b = (top + bottom) / (top - bottom);
            double c = -(far + near) / (far - near), d = -2 * far * near / (far - near);
            te[0] = x; te[4] = 0; te[8] = a; te[12] = 0;
            te[1] = 0; te[5] = y; te[9] = b; te[13] = 0;
            te[2] = 0; te[6] = 0; te[10] = c; te[14] = d;
            te[3] = 0; te[7] = 0; te[11] = -1; te[15] = 0;
            return te;
        }

        /// <summary>Matrix3.getNormalMatrix(m): the inverse transpose of m's upper 3x3, column-major 9 doubles.</summary>
        public static double[] NormalMatrix(double[] me)
        {
            // setFromMatrix4, then Matrix3.invert, then transpose (three's own formulas)
            double n11 = me[0], n21 = me[1], n31 = me[2], n12 = me[4], n22 = me[5], n32 = me[6], n13 = me[8], n23 = me[9], n33 = me[10];
            double t11 = n33 * n22 - n32 * n23, t12 = n32 * n13 - n33 * n12, t13 = n23 * n12 - n22 * n13;
            double det = n11 * t11 + n21 * t12 + n31 * t13;
            var te = new double[9];
            if (det == 0) return te;
            double detInv = 1 / det;
            te[0] = t11 * detInv; te[1] = (n31 * n23 - n33 * n21) * detInv; te[2] = (n32 * n21 - n31 * n22) * detInv;
            te[3] = t12 * detInv; te[4] = (n33 * n11 - n31 * n13) * detInv; te[5] = (n31 * n12 - n32 * n11) * detInv;
            te[6] = t13 * detInv; te[7] = (n21 * n13 - n23 * n11) * detInv; te[8] = (n22 * n11 - n21 * n12) * detInv;
            // transpose
            double tmp;
            tmp = te[1]; te[1] = te[3]; te[3] = tmp;
            tmp = te[2]; te[2] = te[6]; te[6] = tmp;
            tmp = te[5]; te[5] = te[7]; te[7] = tmp;
            return te;
        }
    }

    /// <summary>The stage's camera as SquishScreen's Canvas makes it: PerspectiveCamera(fov 30, aspect 1 (the square
    /// stage), near 0.1, far 100) at (0, 0.1, 4.6), and R3F's lookAt(0, 0, 0).</summary>
    public sealed class StageCamera
    {
        public const double Fov = 30, Near = 0.1, Far = 100;
        public static readonly V3 Position = new V3(0, 0.1, 4.6);
        public readonly double[] MatrixWorld, MatrixWorldInverse, Projection, ProjectionInverse;

        public StageCamera(double aspect = 1)
        {
            var q = Quat.FromRotationMatrix(M4.LookAt(Position, new V3(0, 0, 0), new V3(0, 1, 0)));
            MatrixWorld = M4.Compose(Position, q, new V3(1, 1, 1));
            MatrixWorldInverse = M4.Invert(MatrixWorld);
            double top = Near * Math.Tan(Math.PI / 180 * 0.5 * Fov), height = 2 * top, width = aspect * height, left = -0.5 * width;
            Projection = M4.MakePerspective(left, left + width, top, top - height, Near, Far);
            ProjectionInverse = M4.Invert(Projection);
        }

        /// <summary>Raycaster.setFromCamera(ndc, camera): the ray through a point of the stage, in world space.</summary>
        public void Ray(double ndcX, double ndcY, out V3 origin, out V3 dir)
        {
            origin = new V3(MatrixWorld[12], MatrixWorld[13], MatrixWorld[14]);
            dir = (new V3(ndcX, ndcY, 0.5).ApplyMatrix4(ProjectionInverse).ApplyMatrix4(MatrixWorld) - origin).Normalized();
        }

        /// <summary>Ray.applyMatrix4(m)</summary>
        public static void RayApply(ref V3 origin, ref V3 dir, double[] m)
        {
            var d = (dir + origin).ApplyMatrix4(m);
            origin = origin.ApplyMatrix4(m);
            dir = (d - origin).Normalized();
        }
    }
}
