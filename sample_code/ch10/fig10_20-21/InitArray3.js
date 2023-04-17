// Fig. 10.13: InitArray3.js
// Initializing multidimensional arrays. 
function start()
{
   var array1 = [ [ 1, 2, 3 ], // row 0  
                  [ 4, 5, 6 ] ]; // row 1
   var array2 = [ [ 1, 2 ], // row 0     
                  [ 3 ], // row 1       
                  [ 4, 5, 6 ] ]; // row 2

   outputArray( "Values in array1 by row", array1,
      document.getElementById( "output1" ) );
   outputArray( "Values in array2 by row", array2,
      document.getElementById("output2"));

   output3DArray("Values in a 3-D array", document.getElementById("output3"));

} // end function start

function output3DArray(heading, output)
{
    var results = "";
    // Define a 3-D array
    var d1 = 2;
    var d2 = 3;
    var d3 = 4;
    var array3d = new Array(d1);
    for (i = 0 ; i < d2 ; i++) {
        array3d[i] = new Array(d2);
        for (j = 0 ; j < d3 ; j++) {
            array3d[i][j] = new Array(d3);
        }
    }
    // assign values to array2d and display its content
    for (i = 0 ; i < d1 ; i++) {
        for (j = 0 ; j < d2 ; j++) {
            for (k = 0 ; k < d3 ; k++) {
                array3d[i][j][k] = i + j + k
                results += "<br>array3d[" + i + "][" + j + "][" + k + "] = " + array3d[i][j][k];
            }
        }
    }
    output.innerHTML = results;
}
// display array contents
function outputArray( heading, theArray, output )
{
   var results = "";

   // iterates through the set of one-dimensional arrays
   for ( var row in theArray )                       
   {              
      results += "<ol>";

      // iterates through the elements of each one-dimensional array
      for ( var column in theArray[ row ] ) 
      {
         results += "<li>" + theArray[ row ][ column ] + "</li>";
      } // end inner for
      
      results += "</ol>"; // end ordered list
   } // end outer for

   output.innerHTML = results;
} // end function outputArray

window.addEventListener( "load", start, false );

/**************************************************************************
* (C) Copyright 1992-2012 by Deitel & Associates, Inc. and               *
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
**************************************************************************/