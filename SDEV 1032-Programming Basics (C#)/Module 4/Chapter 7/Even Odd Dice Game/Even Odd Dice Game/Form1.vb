﻿Public Class Form1
    Dim mdecTotalPoints As Decimal = 1000


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblPoints.Text = "Total Points: " & mdecTotalPoints
        Randomize()
    End Sub

    Private Sub BtnEven_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEven.Click
        'Declarations
        Dim shoRiskInput As Short
        Dim bytTotalDie As Byte
        Dim strOddOrEven As String
        'Input - User's risk points entered
        shoRiskInput = Convert.ToDecimal(txtRisk.Text)
        'Processing
        'Function ValidateInput checks if there is a valid input
        If ValidateInput(shoRiskInput) = True Then
            'Function DieRollTotal adds the sum of the two random dice
            bytTotalDie = DieRollTotal()
            'Function OddOrEven checks if the dice are odd or even.
            strOddOrEven = OddOrEven(bytTotalDie)
            If strOddOrEven = "Even" Then
                'Procedure UpdatePoints checks for win or lose outcome
                Call UpdatePoints("Win", shoRiskInput)
                'Procedure GameOver checks and disables Even and Odd buttons if the user runs out of points
                Call GameOver()
            Else
                'Procedure UpdatePoints checks for win or lose outcome
                Call UpdatePoints("Lose", shoRiskInput)
                'Procedure GameOver checks and disables Even and Odd buttons if the user runs out of points
                Call GameOver()
            End If
        End If
    End Sub

    Private Sub BtnOdd_Click(sender As Object, e As EventArgs) Handles btnOdd.Click
        'Declarations
        Dim shoRiskInput As Short
        Dim bytTotalDie As Byte
        Dim strOddOrEven As String
        'Input - User's risk points entered
        shoRiskInput = Convert.ToDecimal(txtRisk.Text)
        'Processing
        'Function ValidateInput checks if there is a valid input
        If ValidateInput(shoRiskInput) = True Then
            'Function DieRollTotal adds the sum of the two random dice
            bytTotalDie = DieRollTotal()
            'Function OddOrEven checks if the dice are odd or even.
            strOddOrEven = OddOrEven(bytTotalDie)
            If strOddOrEven = "Odd" Then
                'Procedure UpdatePoints checks for win or lose outcome
                Call UpdatePoints("Win", shoRiskInput)
                'Procedure GameOver checks and disables Even and Odd buttons if the user runs out of points
                Call GameOver()
            Else
                'Procedure UpdatePoints checks for win or lose outcome
                Call UpdatePoints("Lose", shoRiskInput)
                'Procedure GameOver checks and disables Even and Odd buttons if the user runs out of points
                Call GameOver()
            End If
        End If
    End Sub

    Private Function ValidateInput(ByVal shoRiskInput As Short) As Boolean
        'Checks to see if there is a valid input.
        If shoRiskInput <= 0 Then
            lblOutput.Text = "Invalid risk points submitted."
            Return False
        ElseIf shoRiskInput > mdecTotalPoints Then
            lblOutput.Text = "Invalid. Not enough risk points."
            Return False
        Else
            Return True
        End If
    End Function

    Private Function DieRoll() As Byte
        'Declarations
        Dim bytDieRoll As Byte
        'Processing - Rolls die #1 for random number
        bytDieRoll = Int(Rnd() * 6 + 1)
        'Returns a value
        Return bytDieRoll
    End Function

    Private Function DieRollTotal() As Byte
        'Declarations
        Dim bytDieRoll1 As Byte
        Dim bytDieRoll2 As Byte
        Dim bytTotalDie As Byte
        'Processing - Adds the random numbers generated by Die #1 & #2
        'Calls DieRoll function for die roll 1
        bytDieRoll1 = DieRoll()
        lblDice1.Text = bytDieRoll1
        'Calls DieRoll function for die roll 2
        bytDieRoll2 = DieRoll()
        lblDice2.Text = bytDieRoll2
        'Adds both randomly generated die rolls to get total
        bytTotalDie = bytDieRoll1 + bytDieRoll2
        lblResult.Text = bytTotalDie.ToString
        'Returns a value
        Return bytTotalDie
    End Function

    Private Function OddOrEven(ByVal bytTotalDie As Byte) As String
        'Declarations
        Dim strOddOrEven As String
        'Processing - Determines if the Dice total is Even or Odd
        If bytTotalDie Mod 2 = 0 Then
            strOddOrEven = "Even"
        Else
            strOddOrEven = "Odd"
        End If
        'Output
        lblOddOrEven.Text = strOddOrEven
        'Returns a value
        Return strOddOrEven
    End Function

    Private Sub UpdatePoints(ByVal strWinOrLose As String, ByVal intPointsRisk As Int32)
        'Processing - Adds points from point total if it is a win. Subtracts points from point total if it is a lose.
        If strWinOrLose = "Win" Then
            mdecTotalPoints += intPointsRisk
        Else
            mdecTotalPoints -= intPointsRisk
        End If
        'Output
        lblOutput.Text = strWinOrLose
        lblPoints.Text = "Total Points: " & mdecTotalPoints.ToString
    End Sub

    Private Sub GameOver()
        'Checks to see if game is over by checking amount of points available.
        'If 0 points, prints "Game Over" and disables Even and Odd buttons.
        If mdecTotalPoints = 0 Then
            lblOutput.Text = "Game Over!"
            btnEven.Enabled = False
            btnOdd.Enabled = False
        End If
    End Sub
End Class