Module Module1

	Sub Main()
		Console.WriteLine("Enter your name:")
			Dim aName = Console.ReadLine()
			Dim aBalance As Decimal = 0D
			Dim aTransactionCount = 0
			Dim aEvents = New List(Of String)()
			Dim aActionLower = String.Empty

			Do
				' greeting and command instructions
				Console.WriteLine("What would you like to do {0}:", aName)
				Console.WriteLine("Balance is ${0:C}", aBalance)
				Console.WriteLine("Interest is 5% and is calculated on the balance every third transaction")
				Console.WriteLine("(D)eposit, (W)ithdrawal, Get (B)alance, (L)ist actions for this session, E(X)it? (not case sensitive)")

				' read console to get command
				Dim aAction = Console.ReadLine()

				If String.IsNullOrEmpty(aAction) Then
					Continue Do
				End If

				aActionLower = aAction.ToLower()

				' do a deposit
				If aActionLower = "d" OrElse aActionLower = "deposit" Then
					Console.WriteLine("Enter amount to deposit")
					Dim aAmountEntered = Console.ReadLine()
					' if nothing was entered then continue
					If String.IsNullOrEmpty(aAmountEntered) Then
						Continue Do
					End If
					' if a non-numeric value was entered then continue
					Dim aAmount As Decimal
					If Not Decimal.TryParse(aAmountEntered, aAmount) Then
						Continue Do
					End If
					' increment transaction count
					aTransactionCount += 1
					' adjust the balance
					aBalance += aAmount

					' decide to apply intereset
					If aTransactionCount Mod 3 = 0 Then
						aBalance = aBalance * 1.05D
					End If
					aEvents.Add("Deposit" & vbTab & "Amount:{aAmount:C}" & vbTab & "Balance:{aBalance:C}")
					' print the balance
					Console.Clear()
					Console.WriteLine("Balance is {0:C}", aBalance)
				End If
				' do a withdrawal
				If aActionLower = "w" OrElse aActionLower = "withdrawal" Then
					Console.WriteLine("Enter amount to withdrawal")
					Dim aAmountEntered = Console.ReadLine()
					' if nothing was entered then continue
					If String.IsNullOrEmpty(aAmountEntered) Then
						Continue Do
					End If
					' if a non-numeric value was entered then contine
					Dim aAmount As Decimal
					If Not Decimal.TryParse(aAmountEntered, aAmount) Then
						Continue Do
					End If
					' increment the transaction count
					aTransactionCount += 1
					Console.Clear()
					If aAmount > aBalance Then
						Console.WriteLine("You don't have that much money in your account {0}", aName)
						Continue Do
					End If
					' adjust the balance
					aBalance -= aAmount
					' decide to apply interest
					If aTransactionCount Mod 3 = 0 Then
						Dim aInterest = aBalance * 0.05D
						aBalance = aBalance * 1.05D
						aEvents.Add("Interest" & vbTab & "Amount:{aInterest:C}" & vbTab & "Balance:{aBalance:C}")
					End If
					aEvents.Add("Withdrawal" & vbTab & "Amount:{aAmount:C}" & vbTab & "Balance:{aBalance:C}")
					' print the balance
					Console.WriteLine("Balance is {0:C}", aBalance)
				End If
				' do a balance inquiry
				If aActionLower = "b" OrElse aActionLower = "balance" Then
					aEvents.Add("Balance" & vbTab & "Balance:{aBalance:C}")
					Console.Clear()
					' print the balance
					Console.WriteLine("Balance is {0:C}", aBalance)
				End If
				' show the log for the session
				If aActionLower = "l" OrElse aActionLower = "list" Then
					aEvents.ForEach(AddressOf Console.WriteLine)

				End If
			Loop While aActionLower <> "x" AndAlso aActionLower <> "exit"


			' exit
			Console.WriteLine("Goodbye {0}, press ""Enter"" to exit", aName)
			Console.ReadLine()
	End Sub

End Module
