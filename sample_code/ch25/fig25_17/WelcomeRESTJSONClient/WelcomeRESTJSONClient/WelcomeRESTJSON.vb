' Fig. 25.19: WelcomeRESTJSON.vb
' Client that consumes WelcomeRESTJSONService.
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Text

Public Class WelcomeRESTJSON
   ' object to invoke the WelcomeRESTJSONService
   Private WithEvents service As New WebClient()

   ' creates welcome message from text input and web service
   Private Sub submitButton_Click(ByVal sender As System.Object,
      ByVal e As System.EventArgs) Handles submitButton.Click

      ' send request to WelcomeRESTJSONService
      service.DownloadStringAsync(New Uri(
         "http://localhost:49745/WelcomeRESTJSONService/Service.svc" &
         "/welcome/" & textBox.Text))
   End Sub ' submitButton

   ' process web service response
   Private Sub service_DownloadStringCompleted(ByVal sender As Object,
      ByVal e As System.Net.DownloadStringCompletedEventArgs) _
      Handles service.DownloadStringCompleted

      ' check if any errors occurred in retrieving service data
      If e.Error Is Nothing Then
         ' deserialize response into a TextMessage object
         Dim JSONSerializer _
            As New DataContractJsonSerializer(GetType(TextMessage))
         Dim welcomeString = JSONSerializer.ReadObject(
            New MemoryStream(Encoding.Unicode.GetBytes(e.Result)))

         ' display Message text
         MessageBox.Show(CType(welcomeString, TextMessage).Message)
      End If
   End Sub ' service_DownloadStringCompleted
End Class ' WelcomeRESTJSON

' TextMessage class representing a JSON object
<Serializable()>
Public Class TextMessage
   Public Message As String
End Class ' TextMessage

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