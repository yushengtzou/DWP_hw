' Fig. 22.20: Blackjack.vb
' Blackjack game that uses the BlackjackService web service.
Imports System.Net

Public Class Blackjack
   ' reference to web service
   Private dealer As ServiceReference.BlackjackServiceClient

   ' string representing the dealer's cards
   Private dealersCards As String

   ' string representing the player's cards
   Private playersCards As String
   Private cardBoxes As List(Of PictureBox) ' list of card images
   Private currentPlayerCard As Integer ' player's current card number
   Private currentDealerCard As Integer ' dealer's current card number 

   ' enum representing the possible game outcomes 
   Public Enum GameStatus
      PUSH ' game ends in a tie
      LOSE ' player loses
      WIN ' player wins
      BLACKJACK ' player has blackjack
   End Enum ' GameStatus

   ' sets up the game
   Private Sub Blackjack_Load(ByVal sender As Object,
      ByVal e As System.EventArgs) Handles Me.Load
      ' instantiate object allowing communication with Web service
      dealer = New ServiceReference.BlackjackServiceClient

      cardBoxes = New List(Of PictureBox)

      ' put PictureBoxes into cardBoxes List
      cardBoxes.Add(pictureBox1)
      cardBoxes.Add(pictureBox2)
      cardBoxes.Add(pictureBox3)
      cardBoxes.Add(pictureBox4)
      cardBoxes.Add(pictureBox5)
      cardBoxes.Add(pictureBox6)
      cardBoxes.Add(pictureBox7)
      cardBoxes.Add(pictureBox8)
      cardBoxes.Add(pictureBox9)
      cardBoxes.Add(pictureBox10)
      cardBoxes.Add(pictureBox11)
      cardBoxes.Add(pictureBox12)
      cardBoxes.Add(pictureBox13)
      cardBoxes.Add(pictureBox14)
      cardBoxes.Add(pictureBox15)
      cardBoxes.Add(pictureBox16)
      cardBoxes.Add(pictureBox17)
      cardBoxes.Add(pictureBox18)
      cardBoxes.Add(pictureBox19)
      cardBoxes.Add(pictureBox20)
      cardBoxes.Add(pictureBox21)
      cardBoxes.Add(pictureBox22)
   End Sub ' Blackjack_Load

   ' deals cards to dealer while dealer's total is less than 17, 
   ' then computes value of each hand and determines winner
   Private Sub DealerPlay()
      ' reveal dealer's second card
      Dim tab As Char = Convert.ToChar(vbTab)
      Dim cards As String() = dealersCards.Split(tab)
      DisplayCard(1, cards(1))

      Dim nextCard As String

      ' while value of dealer's hand is below 17,
      ' dealer must take cards
      While dealer.GetHandValue(dealersCards) < 17
         nextCard = dealer.DealCard() ' deal new card
         dealersCards &= vbTab & nextCard

         ' update GUI to show new card
         MessageBox.Show("Dealer takes a card")
         DisplayCard(currentDealerCard, nextCard)
         currentDealerCard += 1
      End While

      Dim dealerTotal As Integer = dealer.GetHandValue(dealersCards)
      Dim playerTotal As Integer = dealer.GetHandValue(playersCards)

      ' if dealer busted, player wins
      If dealerTotal > 21 Then
         GameOver(GameStatus.WIN)
      Else
         ' if dealer and player have not exceeded 21,
         ' higher score wins equal scores is a push.
         If dealerTotal > playerTotal Then ' player loses game
            GameOver(GameStatus.LOSE)
         ElseIf playerTotal > dealerTotal Then ' player wins game
            GameOver(GameStatus.WIN)
         Else ' player and dealer tie
            GameOver(GameStatus.PUSH)
         End If
      End If
   End Sub ' DealerPlay

   ' displays card represented by cardValue in specified PictureBox
   Public Sub DisplayCard(
      ByVal card As Integer, ByVal cardValue As String)
      ' retrieve appropriate PictureBox
      Dim displayBox As PictureBox = cardBoxes(card)

      ' if string representing card is empty,
      ' set displayBox to display back of card
      If String.IsNullOrEmpty(cardValue) Then
         displayBox.Image =
            Image.FromFile("blackjack_images/cardback.png")
         Return
      End If

      ' retrieve face value of card from cardValue
      Dim face As String =
         cardValue.Substring(0, cardValue.IndexOf(" "))

      ' retrieve the suit of the card from cardValue
      Dim suit As String =
         cardValue.Substring(cardValue.IndexOf(" ") + 1)

      Dim suitLetter As Char ' suit letter used to form image file name

      ' determine the suit letter of the card
      Select Case Convert.ToInt32(suit)
         Case 0 ' clubs
            suitLetter = "c"c
         Case 1 ' diamonds
            suitLetter = "d"c
         Case 2 ' hearts
            suitLetter = "h"c
         Case Else ' spades 
            suitLetter = "s"c
      End Select

      ' set displayBox to display appropriate image
      displayBox.Image = Image.FromFile(
         "blackjack_images/" & face & suitLetter & ".png")
   End Sub ' DisplayCard

   ' displays all player cards and shows 
   ' appropriate game status message
   Public Sub GameOver(ByVal winner As GameStatus)
      ' display appropriate status image
      If winner = GameStatus.PUSH Then ' push
         statusPictureBox.Image =
            Image.FromFile("blackjack_images/tie.png")
      ElseIf winner = GameStatus.LOSE Then ' player loses
         statusPictureBox.Image =
            Image.FromFile("blackjack_images/lose.png")
      ElseIf winner = GameStatus.BLACKJACK Then
         ' player has blackjack
         statusPictureBox.Image =
            Image.FromFile("blackjack_images/blackjack.png")
      Else ' player wins
         statusPictureBox.Image =
            Image.FromFile("blackjack_images/win.png")
      End If

      ' display final totals for dealer and player
      dealerTotalLabel.Text =
         "Dealer: " & dealer.GetHandValue(dealersCards)
      playerTotalLabel.Text =
         "Player: " & dealer.GetHandValue(playersCards)

      ' reset controls for new game
      stayButton.Enabled = False
      hitButton.Enabled = False
      dealButton.Enabled = True
   End Sub ' GameOver

   ' deal two cards each to dealer and player
   Private Sub dealButton_Click(ByVal sender As System.Object,
      ByVal e As System.EventArgs) Handles dealButton.Click
      Dim card As String ' stores a card temporarily until added to a hand

      ' clear card images
      For Each cardImage As PictureBox In cardBoxes
         cardImage.Image = Nothing
      Next

      statusPictureBox.Image = Nothing ' clear status image
      dealerTotalLabel.Text = String.Empty ' clear final total for dealer
      playerTotalLabel.Text = String.Empty ' clear final total for player

      ' create a new, shuffled deck on the web service host
      dealer.Shuffle()

      ' deal two cards to player
      playersCards = dealer.DealCard() ' deal a card to player's hand

      ' update GUI to display new card
      DisplayCard(11, playersCards)
      card = dealer.DealCard() ' deal a second card
      DisplayCard(12, card) ' update GUI to display new card
      playersCards &= vbTab & card ' add second card to player's hand

      ' deal two cards to dealer, only display face of first card
      dealersCards = dealer.DealCard() ' deal a card to dealer's hand
      DisplayCard(0, dealersCards) ' update GUI to display new card
      card = dealer.DealCard() ' deal a second card
      DisplayCard(1, String.Empty) ' update GUI to show face-down card
      dealersCards &= vbTab & card ' add second card to dealer's hand

      stayButton.Enabled = True ' allow player to stay
      hitButton.Enabled = True ' allow player to hit
      dealButton.Enabled = False ' disable Deal Button

      ' determine the value of the two hands
      Dim dealerTotal As Integer = dealer.GetHandValue(dealersCards)
      Dim playerTotal As Integer = dealer.GetHandValue(playersCards)

      ' if hands equal 21, it is a push
      If dealerTotal = playerTotal And dealerTotal = 21 Then
         GameOver(GameStatus.PUSH)
      ElseIf dealerTotal = 21 Then ' if dealer has 21, dealer wins
         GameOver(GameStatus.LOSE)
      ElseIf playerTotal = 21 Then ' player has blackjack
         GameOver(GameStatus.BLACKJACK)
      End If

      currentDealerCard = 2 ' next dealer card has index 2 in cardBoxes
      currentPlayerCard = 13 ' next player card has index 13 in cardBoxes
   End Sub ' dealButton_Click

   ' deal another card to player
   Private Sub hitButton_Click(ByVal sender As System.Object,
      ByVal e As System.EventArgs) Handles hitButton.Click
      ' get player another card
      Dim card As String = dealer.DealCard() ' deal new card
      playersCards &= vbTab & card ' add new card to player's hand

      ' update GUI to show new card
      DisplayCard(currentPlayerCard, card)
      currentPlayerCard += 1

      ' determine the value of the player's hand
      Dim total As Integer = dealer.GetHandValue(playersCards)

      ' if player exceeds 21, house wins
      If total > 21 Then
         GameOver(GameStatus.LOSE)
      End If

      ' if player has 21,
      ' they cannot take more cards, and dealer plays
      If total = 21 Then
         hitButton.Enabled = False
         DealerPlay()
      End If
   End Sub ' hitButton_Click

   ' play the dealer's hand after the play chooses to stay
   Private Sub stayButton_Click(ByVal sender As System.Object,
      ByVal e As System.EventArgs) Handles stayButton.Click
      stayButton.Enabled = False ' disable Stay Button
      hitButton.Enabled = False ' disable Hit Button
      dealButton.Enabled = True ' re-enable Deal Button
      DealerPlay() ' player chose to stay, so play the dealer's hand
   End Sub ' stayButton_Click
End Class ' Blackjack

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

