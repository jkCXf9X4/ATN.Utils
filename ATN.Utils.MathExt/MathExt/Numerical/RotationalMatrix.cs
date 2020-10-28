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
	/// <summary>
	/// Description of Matrix.
	/// </summary>
	[Serializable]
	public class RotationMatrix
	{
		public Matrix<double> matrix;
		
		public RotationMatrix()
		{
			matrix = new Rotation(0,0,0).ToRotationMatrices().matrix;
		}
		
		public RotationMatrix(Matrix<double> rotationMatrix)
		{
			if (rotationMatrix.ColumnCount != 3 || rotationMatrix.RowCount != 3)
				throw new ArgumentException("Mtrix is not 3x3");
			
			matrix = rotationMatrix;
		}
		
		public RotationMatrix(double x, double y, double z, string order = "xyz")
		{
			matrix = new Rotation(x,y,z).ToRotationMatrices(order).matrix;
		}
		
		public RotationMatrix(Rotation rot, string order = "xyz")
		{
			matrix = rot.ToRotationMatrices(order).matrix;
		}
		
		public void Reset()
		{
			matrix = new Rotation(0,0,0).ToRotationMatrices().matrix;
		}
		
		public bool IsRotationMatrix()
		{
			var t = matrix.Transpose();
			
			var shouldBeI = t * matrix;
			
			var I = Matrix<double>.Build.DenseOfArray(new double[,] {{ 1, 0, 0 },
				{ 0, 1, 0 },
				{ 0, 0, 1 }
			});
			
			if (I == shouldBeI)
				return true;
			return false;
		}
		
		public RotationMatrix GetInverse()
		{
			return new RotationMatrix(this.matrix.Inverse());
		}
		
		public RotationMatrix Multiply(RotationMatrix b)
		{
			return new RotationMatrix(matrix * b.matrix);
		}

		public static Vector<double> GetEulerZYX(Matrix<double> matrix)
		{
			throw new NotImplementedException();
			
			//var M = Vector<double>.Build.Dense(3);

			//return M;
		}
	}
}
