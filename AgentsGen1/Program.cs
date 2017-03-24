using System;
using System.Collections.Generic;

namespace AgentsGen1
{
	class MainClass
	{
		static List<string> Formulas = new List<string>();
		static List<int[,]> Agents64 = new List<int[,]>();

		public static void Main( string[] args )
		{
			var bools = new bool[]{ true, false };

			// Truth/Falsity conditions

			Formulas.Add( "p∧q" );
			Formulas.Add( "p∧¬q" );
			Formulas.Add( "¬p∧q" );
			Formulas.Add( "¬p∧¬q" );
			Formulas.Add( "p∨q" );
			Formulas.Add( "p∨¬q" );
			Formulas.Add( "¬p∨q" );
			Formulas.Add( "¬p∨¬q" );

			var Agents64Index = new List<int>();

			foreach ( var trufrml in Formulas )
			{
				foreach ( var falfrml in Formulas )
				{
					// One agent for every truth/falsity conditions

					var tabela = new int [4 , 2];
					var linha = 0;

					foreach ( var a in bools )
					{
						foreach ( var b in bools )
						{
							tabela[ linha , 0 ] = Interpreta( trufrml , a , b );
							tabela[ linha , 1 ] = Interpreta( falfrml , a , b );
							linha++;
						}
					}

					var index = AgentToIndex( tabela , 0 , 1 );
					if ( Agents64Index.Contains( index ) )
						throw new DataMisalignedException( "repeat" );

					Agents64Index.Add( index );
					Agents64.Add( tabela );
				}
			}

			Agents64Index.Sort();
			foreach ( var item in Agents64Index )
				Console.Write( item + " " );
			Console.WriteLine();
		}

		static int AgentToIndex( int[,] matrix , int col1 , int col2 )
		{
			Console.WriteLine();
			var index = 0;
			for ( int linha = 0 ; linha < matrix.GetLength( 0 ) ; linha++ )
			{
				var a = matrix[ linha , col1 ];
				var b = matrix[ linha , col2 ];

				Console.WriteLine( " " + a + " " + b );

				if ( a < 0 || a > 1 || b < 0 || b > 1 )
					throw new DataMisalignedException();

				index = index * 2 + a;
				index = index * 2 + b;
			}
			Console.WriteLine();
			Console.WriteLine( "index " + index );
			Console.WriteLine();

			if ( index == 0 || index == 255 )
				System.Diagnostics.Debugger.Break();

			return index;
		}

		static int Interpreta( string formula , bool p , bool q )
		{
			formula = formula.Replace( "p" , p.ToString() );
			formula = formula.Replace( "q" , q.ToString() );

			var T = true.ToString();
			var F = false.ToString();

			formula = formula.Replace( "¬" + T , F );
			formula = formula.Replace( "¬" + F , T );

			formula = formula.Replace( T + "∧" + T , T );
			formula = formula.Replace( T + "∧" + F , F );
			formula = formula.Replace( F + "∧" + T , F );
			formula = formula.Replace( F + "∧" + F , F );

			formula = formula.Replace( T + "∨" + T , T );
			formula = formula.Replace( T + "∨" + F , T );
			formula = formula.Replace( F + "∨" + T , T );
			formula = formula.Replace( F + "∨" + F , F );

			if ( formula.Equals( F ) )
				return 0;
			if ( formula.Equals( T ) )
				return 1;

			throw new DataMisalignedException( formula );
		}
	}
}