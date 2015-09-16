Additions/Changes from Project2 to Project3

- Project2/model was copied to Project3/Models

- Added AccountRepository to Models.
	- provides a mechanism to store/retrieve an account. Needed because we don't know if the consuming application will maintain state.
		(this particular example maintains AccountRepository as a singleton throughout the life of the application so we don't need 
		another method, like a database, to store the account.)

- Console application is replaced with REST API
	- no changes were made in any model classes.
	- Controllers are used as engines of state change.
		- this is analogous to Program.cs in Project2

- Dependency Injection is used
	- all DI bindings are done in one place (UnityConfig.cs)
		- two types of binding are used
			1. RegisterType binds a class to an interface. When an interface is passed as a constructor dependency it is passed as the type specified
			2. RegisterInstance binds a class to an instance.  When the type is passed as a constructor dependency the instance registered is passed.

- Unit Testing
	- leverage DI along with Mocking library to achieve very high test coverage across codebase.

