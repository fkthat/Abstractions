# FkThat.Abstractions

The collection of adapters (wrappers) to some types of the standard .NET library.

There's a good deal of commonly used library types that make your code hard to test with unit tests
in case it uses them. The reasons could be:

- The type cannot be mocked because it either has no separate abstract interface or is a static type.
- The type runs the way you cannot control (e.g. `DateTime`, GUID or random number generators, etc).

The common solution to this problem is to wrap such a type with a simple adapter that has separated
interface and implementation and to use it with DI instead of direct usage of the original type.

Also the package includes a couple of features beyond the standard library:

- [GUID v7 implementation](https://github.com/fkthat/Abstractions/blob/main/src/FkThat.Abstractions/V7GuidGenerator.cs) (sequential GUIDs).
- Generic service provider [`IServiceProvider<T>`](https://github.com/fkthat/Abstractions/blob/main/src/FkThat.Abstractions/IServiceProvider.cs)
  that lets you to avoid the ['Service Locator' antipattern](https://blog.ploeh.dk/2010/02/03/ServiceLocatorisanAnti-Pattern/)
  in case you still need resolving dependencies manually in your code.
