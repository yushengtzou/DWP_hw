' Fig. 25.23: ReservationClient.aspx.vb
' ReservationClient code behind file.
Partial Class ReservationClient
   Inherits System.Web.UI.Page
   ' object of proxy type used to connect to Reservation service
   Private ticketAgent As New ServiceReference.ReservationServiceClient()

   Protected Sub reserveButton_Click(ByVal sender As Object,
      ByVal e As System.EventArgs) Handles reserveButton.Click

      ' if the ticket is reserved
      If ticketAgent.Reserve(seatList.SelectedItem.Text,
         classList.SelectedItem.Text.ToString()) Then

         ' hide other controls
         instructionsLabel.Visible = False
         seatList.Visible = False
         classList.Visible = False
         reserveButton.Visible = False
         errorLabel.Visible = False

         ' display message indicating success
         Response.Write("Your reservation has been made. Thank you.")
      Else ' service method returned false, so signal failure
         ' display message in the initially blank errorLabel
         errorLabel.Text = "This type of seat is not available. " &
            "Please modify your request and try again."
      End If
   End Sub ' reserveButton_Click
End Class ' ReservationClient

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
