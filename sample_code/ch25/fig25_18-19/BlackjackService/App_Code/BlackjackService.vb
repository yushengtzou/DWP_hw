' Fig. 25.19: BlackjackService.vb
' Blackjack game WCF web service.
Imports System.Collections.Generic

<ServiceBehavior(InstanceContextMode:=InstanceContextMode.PerSession)> _
Public Class BlackjackService
   Implements IBlackjackService
   ' create persistent session deck of cards object
   Dim deck As New List(Of String)

   ' deals card that has not yet been dealt
   Public Function DealCard() As String _
      Implements IBlackjackService.DealCard

      Dim card As String = Convert.ToString(deck(0)) ' get first card
      deck.RemoveAt(0) ' remove card from deck
      Return card
   End Function ' DealCard

   ' creates and shuffles a deck of cards
   Public Sub Shuffle() Implements IBlackjackService.Shuffle
      Dim randomObject As New Random() ' generates random numbers

      deck.Clear() ' clears deck for new game

      ' generate all possible cards
      For face = 1 To 13 ' loop through face values
         For suit As Integer = 0 To 3 ' loop through suits
            deck.Add(face & " " & suit) ' add card (string) to deck
         Next suit
      Next face

      ' shuffles deck by swapping each card with another card randomly
      For i = 0 To deck.Count - 1
         ' get random index
         Dim newIndex = randomObject.Next(deck.Count - 1)
         Dim temporary = deck(i) ' save current card in temporary variable
         deck(i) = deck(newIndex) ' copy randomly selected card
         deck(newIndex) = temporary ' copy current card back into deck
      Next
   End Sub ' Shuffle

   ' computes value of hand
   Public Function GetHandValue(ByVal dealt As String) As Integer _
      Implements IBlackjackService.GetHandValue
      ' split string containing all cards
      Dim tab As Char = Convert.ToChar(vbTab)
      Dim cards As String() = dealt.Split(tab) ' get array of cards
      Dim total As Integer = 0 ' total value of cards in hand
      Dim face As Integer ' face of the current card
      Dim aceCount As Integer = 0 ' number of aces in hand

      ' loop through the cards in the hand
      For Each card In cards
         ' get face of card
         face = Convert.ToInt32(card.Substring(0, card.IndexOf(" ")))

         Select Case face
            Case 1 ' if ace, increment aceCount
               aceCount += 1
            Case 11 To 13 ' if jack, queen or king add 10
               total += 10
            Case Else ' otherwise, add value of face 
               total += face
         End Select
      Next

      ' if there are any aces, calculate optimum total
      If aceCount > 0 Then
         ' if it is possible to count one ace as 11, and the rest
         ' as 1 each, do so; otherwise, count all aces as 1 each
         If (total + 11 + aceCount - 1 <= 21) Then
            total += 11 + aceCount - 1
         Else
            total += aceCount
         End If
      End If

      Return total
   End Function ' GetHandValue
End Class ' BlackjackService

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