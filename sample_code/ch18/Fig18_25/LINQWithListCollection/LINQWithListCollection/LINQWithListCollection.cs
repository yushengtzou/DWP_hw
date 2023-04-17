﻿// Fig. 18.25: LINQWithListCollection.cs
// LINQ to Objects using a List< string >.
using System;
using System.Linq;
using System.Collections.Generic;

public class LINQWithListCollection
{
   public static void Main( string[] args )
   {
      // populate a List of strings 
      List< string > items = new List< string >();
      items.Add( "aQua" ); // add "aQua" to the end of the List
      items.Add( "RusT" ); // add "RusT" to the end of the List
      items.Add( "yElLow" ); // add "yElLow" to the end of the List
      items.Add( "rEd" ); // add "rEd" to the end of the List

      // convert all strings to uppercase; select those starting with "R"
      var startsWithR =
         from item in items
         let uppercaseString = item.ToUpper()
         where uppercaseString.StartsWith( "R" )
         orderby uppercaseString
         select uppercaseString;

      // display query results
      foreach ( var item in startsWithR )
         Console.Write( "{0} ", item );

      Console.WriteLine(); // output end of line

      items.Add( "rUbY" ); // add "rUbY" to the end of the List
      items.Add( "SaFfRon" ); // add "SaFfRon" to the end of the List

      // display updated query results
      foreach ( var item in startsWithR )
         Console.Write( "{0} ", item );

      Console.WriteLine(); // output end of line
   } // end Main
} // end class LINQWithListCollection

/**************************************************************************
 * (C) Copyright 1992-2011 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
