' Fig. 22.17: ProtectedContent_Books.aspx.vb
' Code-behind file for the password-protected Books page.
Partial Class ProtectedContent_Books
   Inherits System.Web.UI.Page

   ' data context queried by data sources
   Private database As New BooksDataContext()

   ' specify the Select query that creates a combined first and last name
   Protected Sub authorsLinqDataSource_Selecting(ByVal sender As Object,
      ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) _
      Handles authorsLinqDataSource.Selecting

      e.Result =
         From author In database.Authors
         Select Name = author.FirstName & " " & author.LastName,
            author.AuthorID
   End Sub ' authorsLinqDataSource_Selecting

   ' specify the Select query that gets the specified author's books
   Protected Sub titlesLinqDataSource_Selecting(ByVal sender As Object,
      ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) _
      Handles titlesLinqDataSource.Selecting

      e.Result =
         From book In database.AuthorISBNs
         Where book.AuthorID = authorsDropDownList.SelectedValue
         Select book.Title
   End Sub ' titlesLinqDataSource_Selecting

   ' refresh the GridView when a different author is selected
   Protected Sub authorsDropDownList_SelectedIndexChanged(
      ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles authorsDropDownList.SelectedIndexChanged

      titlesGridView.DataBind() ' update the GridView
   End Sub ' authorsDropDownList_SelectedIndexChanged
End Class ' ProtectedContent_Books


'**************************************************************************
'* (C) Copyright 1992-2011 by Deitel & Associates, Inc. and               *
'* Pearson Education, Inc. All Rights Reserved.                           *
'*                                                                        *
'* DISCLAIMER: The authors and publisher of this book have used their     *
'* best efforts in preparing the book. These efforts include the          *
'* development, research, and testing of the theories and programs        *
'* to determine their effectiveness. The authors and publisher make       *
'* no warranty of any kind, expressed or implied, with regard to these    *
'* programs or to the documentation contained in these books. The authors *
'* and publisher shall not be liable in any event for incidental or       *
'* consequential damages in connection with, or arising out of, the       *
'* furnishing, performance, or use of these programs.                     *
'**************************************************************************

