' Fig. 25.8: WelcomeSOAPXMLForm.vb
' Client that consumes WelcomeSOAPXMLService.
Public Class WelcomeSOAPXMLForm
   ' reference to web service
   Private client As New ServiceReference.WelcomeSOAPXMLServiceClient()

   ' creates welcome message from text input and web service
   Private Sub submitButton_Click(ByVal sender As System.Object,
      ByVal e As System.EventArgs) Handles submitButton.Click

      MessageBox.Show(client.Welcome(textBox.Text))
   End Sub ' submitButton_Click
End Class ' WelcomeSOAPXMLForm

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