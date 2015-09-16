Steps for refactoring

1. Create a class for the account
	- this class maintains the balance
	- this class knows how to do deposits
	- this class knows how to do withdrawals
	- this class knows how to return the balance
	- this class knows the interest rate
	- this class applies interest returned from an interest calculator

2. Create a Withdrawal Exception
	- this class is used as a message to notify a consumer of Account that they tried to withdraw more tan the account balance.

3. Create a class for calculating interest
	- calculates interest for a principal

4. Create a class to log events
	- stores messages written by the program

These classes encapsulate various aspects of application logic.  The result of this refactoring is to decouple the User Interface (Program.cs)
from the application logic.

