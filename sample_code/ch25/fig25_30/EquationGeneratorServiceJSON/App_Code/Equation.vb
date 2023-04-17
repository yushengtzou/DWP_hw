' Fig. 22.28: Equation.vb
' Class Equation that contains information about an equation.
<DataContract()> _
Public Class Equation
   Private leftOperand As Integer ' number to the left of the operator
   Private rightOperand As Integer ' number to the right of the operator
   Private resultValue As Integer ' result of the operation
   Private operationType As String ' type of the operation

   ' required default constructor
   Public Sub New()
      MyClass.New(0, 0, "add")
   End Sub ' parameterless New 

   ' three-argument constructor for class Equation
   Public Sub New(ByVal leftValue As Integer, _
      ByVal rightValue As Integer, ByVal type As String)
      Left = leftValue
      Right = rightValue

      Select Case type ' perform appropriate operation
         Case "add" ' addition
            Result = leftOperand + rightOperand
            operationType = "+"
         Case "subtract" ' subtraction
            Result = leftOperand - rightOperand
            operationType = "-"
         Case "multiply" ' multiplication
            Result = leftOperand * rightOperand
            operationType = "*"
      End Select
   End Sub ' three-parameter New 

   ' return string representation of the Equation object
   Public Overrides Function ToString() As String
      Return leftOperand.ToString() & " " & operationType & " " & _
         rightOperand.ToString() & " = " & resultValue.ToString()
   End Function ' ToString

   ' property that returns a string representing left-hand side
   <DataMember()> _
   Public Property LeftHandSide() As String
      Get
         Return leftOperand.ToString() & " " & operationType & " " & _
            rightOperand.ToString()
      End Get

      Set(ByVal value As String) ' required set accessor
         ' empty body
      End Set
   End Property ' LeftHandSide

   ' property that returns a string representing right-hand side
   <DataMember()> _
   Public Property RightHandSide() As String
      Get
         Return resultValue.ToString()
      End Get

      Set(ByVal value As String) ' required set accessor
         ' empty body
      End Set
   End Property ' RightHandSide

   ' property to access the left operand 
   <DataMember()> _
   Public Property Left() As Integer
      Get
         Return leftOperand
      End Get

      Set(ByVal value As Integer)
         leftOperand = value
      End Set
   End Property ' Left

   ' property to access the right operand 
   <DataMember()> _
   Public Property Right() As Integer
      Get
         Return rightOperand
      End Get

      Set(ByVal value As Integer)
         rightOperand = value
      End Set
   End Property ' Right

   ' property to access the result of applying
   ' an operation to the left and right operands
   <DataMember()> _
   Public Property Result() As Integer
      Get
         Return resultValue
      End Get

      Set(ByVal value As Integer)
         resultValue = value
      End Set
   End Property ' Result

   ' property to access the operation
   <DataMember()> _
   Public Property Operation() As String
      Get
         Return operationType
      End Get

      Set(ByVal value As String)
         operationType = value
      End Set
   End Property ' Operation
End Class ' Equation

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