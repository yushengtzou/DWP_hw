' Fig. 25.13: WelcomeRESTXML.vb
' Client that consumes the WelcomeRESTXMLService.
Imports System.Net
Imports System.Xml.Linq
Imports <xmlns="http://schemas.microsoft.com/2003/10/Serialization/">

Public Class WelcomeRESTXML
   ' object to invoke the WelcomeRESTXMLService
   Private WithEvents service As New WebClient()

   ' get user input and pass it to the web service
   Private Sub submitButton_Click(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles submitButton.Click

      ' send request to WelcomeRESTXMLService
      service.DownloadStringAsync(New Uri( _
         "http://localhost:51424/WelcomeRESTXMLService/Service.svc/" _
         & "welcome/" & textBox.Text))
   End Sub ' submitButton_Click

   ' process web service response
   Private Sub service_DownloadStringCompleted(ByVal sender As Object, _
      ByVal e As System.Net.DownloadStringCompletedEventArgs) _
      Handles service.DownloadStringCompleted

      ' check if any error occurred in retrieving service data
      If e.Error Is Nothing Then
         ' parse the returned XML string (e.Result)
         Dim xmlResponse = XDocument.Parse(e.Result)

         ' use XML axis property to access the <string> element's value
         MessageBox.Show(xmlResponse.<string>.Value)
      End If
   End Sub ' service_DownloadStringCompleted
End Class ' WelcomeRESTXML

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