' Fig. 25.22: ReservationService.vb
' Airline reservation WCF web service.
Public Class ReservationService
   Implements IReservationService

   ' create ticketsDB object to access Tickets database
   Private ticketsDB As New TicketsDataContext()

   ' checks database to determine whether matching seat is available
   Public Function Reserve(ByVal seatType As String,
      ByVal classType As String) As Boolean _
      Implements IReservationService.Reserve

      ' LINQ query to find seats matching the parameters
      Dim result =
         From seat In ticketsDB.Seats
         Where (seat.Taken = 0) And (seat.Type = seatType) And
            (seat.Class = classType)

      ' if the number of seats returned is nonzero, 
      ' obtain the first matching seat number and mark it as taken
      If result.Count() <> 0 Then
         ' get first available seat
         Dim firstAvailableSeat As Seat = result.First()
         firstAvailableSeat.Taken = 1 ' mark the seat as taken
         ticketsDB.SubmitChanges() ' update 
         Return True ' seat was reserved
      End If

      Return False ' no seat was reserved
   End Function ' Reserve
End Class ' ReservationService

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
