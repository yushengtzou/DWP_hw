// Fig. 18.18: DisplayAuthorsTable.cs
// Displaying data from a database table in a DataGridView.
using System;
using System.Linq;
using System.Windows.Forms;

namespace DisplayTable
{
   public partial class DisplayAuthorsTable : Form
   {
      // constructor
      public DisplayAuthorsTable()
      {
         InitializeComponent();
      } // end constructor

      // LINQ to SQL data context
      private BooksDataContext database = new BooksDataContext();

      // load data from database into DataGridView
      private void DisplayAuthorsTable_Load( object sender, EventArgs e )
      {
         // use LINQ to order the data for display
         authorBindingSource.DataSource =
            from author in database.Authors
            orderby author.AuthorID
            select author;
      } // end method DisplayTableForm_Load

      // click event handler for the Save Button in the 
      // BindingNavigator saves the changes made to the data
      private void authorBindingNavigatorSaveItem_Click(
         object sender, EventArgs e )
      {
         Validate(); // validate input fields
         authorBindingSource.EndEdit(); // indicate edits are complete
         database.SubmitChanges(); // write changes to database file
      } // end method authorBindingNavigatorSaveItem_Click
   } // end class DisplayAuthorsTable
} // end namespace DisplayTable

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
