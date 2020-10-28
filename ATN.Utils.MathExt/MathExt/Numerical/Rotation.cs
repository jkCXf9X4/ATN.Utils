/*
 * Created by SharpDevelop.
 * User: erxzr5
 * Date: 2018-02-09
 * Time: 16:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Spatial.Units;
 

namespace ATN.Utils.MathExt.Numerical
{
	[Serializable]
	public class Rotation
	{
		public Vector<double> rotation = Vector<double>.Build.Dense(3);
		
		public double Phi {
			get {
				return rotation[0];
			}
			set {
				rotation[0] = value;
			}
		}
		public double Teta {
			get {
				return rotation[1];
			}
			set {
				rotation[1] = value;
			}
		}
		public double Psi {
			get {
				return rotation[2];
			}
			set {
				rotation[2] = value;
			}
		}
		
		public Rotation()
		{
		}
		
		public Rotation(double Phi, double Teta, double Psi)
		{
			this.Phi = Phi;
			this.Teta = Teta;
			this.Psi = Psi;
		}
		
				
		public Rotation(double[] array)
		{
			this.Phi = array[0];
			this.Teta = array[1];
			this.Psi = array[2];
		}
		
		public Rotation(Vector<double> rot)
		{
			rotation = rot;
		}
		
		public static Rotation operator + (Rotation a, Rotation b)
		{
			var c = a.rotation + b.rotation;
			return new Rotation(c);
		}
		
		public static Rotation operator - (Rotation a, Rotation b)
		{
			return new Rotation(a.rotation-b.rotation);
		}
		
		public void Reset()
		{
			this.Phi = 0;
			this.Teta = 0;
			this.Psi = 0;
		}
		
		public Rotation GetInverse()
		{
			return new Rotation(-this.Phi,-this.Teta, -this.Psi);
		}
		
		
		public RotationMatrix ToRotationMatrices(string order = "xyz")
		{
			var xRot = MathNet.Spatial.Euclidean.Matrix3D.RotationAroundXAxis(Angle.FromDegrees(Phi));
			var yRot = MathNet.Spatial.Euclidean.Matrix3D.RotationAroundYAxis(Angle.FromDegrees(Teta));
			var zRot = MathNet.Spatial.Euclidean.Matrix3D.RotationAroundZAxis(Angle.FromDegrees(Psi));
        	
			var I = Matrix<double>.Build.DenseOfArray(new double[,] {{ 1, 0, 0 },
				{ 0, 1, 0 },
				{ 0, 0, 1 }
			});
			foreach (char  i in order.ToCharArray()) {
				if (i == 'x')
					I = I * xRot;
				if (i == 'y')
					I = I * yRot;
				if (i == 'z')
					I = I * zRot;
			}
        	
			return new RotationMatrix(I);
		}
		
		public Rotation GetSimplifiedRotation()
		{
			return new Rotation( Phi % 360, Teta % 360, Psi % 360);
		}
	}
}
