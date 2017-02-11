 # ShiftWise Code Exercise

This exercise was created as a .NET Standard library using the new .csproj system, so you'll need to use a copy of VS 2017 RC if you want to open the solution inside VS.

For this exercise, I (Nathan Becker) decided to take a simple approach, using built-in methods wherever possible and trying to write the solution using as few lines as possible while maintaining readability and potential future expansion/modification. 

For the sorting algorithm, I utilized .NET's built-in sorting method in conjunction with a unique ID that's computed for each Card object.  Each Card object contains an enum for suit and value.  When the enum values are concatenated, they form a unique, sortable ID that can be used with the built-in OrderBy() method.

For the shuffling algorithm, I essentially run through the deck a bunch of times, and switch each card to a random position each time, using the Cryptography library to generate a better random variable than the pseudo Random() object.
