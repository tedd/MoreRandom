# Tedd.MoreRandom
Drop-in replacement for System.Random based on RandomNumberGenerator.

## Example
Works exactly like System.Random, except you may want to dispose of it when you are done.
(If you don't dispose of it, the destructor will do it for you upon garbage collect.)

<pre><code>var rnd = new Tedd.MoreRandom.Random();
var dice = rnd.Next(1, 7); // A random number between 1 and 6 inclusive
rnd.Dispose();</code></pre>
<pre><code>using (var rnd = new Tedd.MoreRandom.Random()) {
	var percent = rnd.NextDouble() * 100;
	Console.WriteLine($"You are {percent}% done, please wait...");
}</code></pre>

Note that it is recommended to create a shared Random object, and in case of multiple threads use synchronized access to generate random data.

<pre><code>public static class Main: IDisposable {
	public static Tedd.MoreRandom.Random Rnd = new Tedd.MoreRandom.Random();

	public static void Start() {
		int dice;
		lock (Rnd)
			dice = Rnd.Next(1, 7); // A random number between 1 and 6 inclusive
	}
}</code></pre>


## Thread safety
Any public static (Shared in Visual Basic) members of this type are thread safe. Any instance members are not guaranteed to be thread safe.

## Background
System.Random is based on so called "pseudorandom" algorithm. This means that given a seed (default this is number of milliseconds since computer was started) math is used to generate seemingly random numbers. Given the same seed, a sequence of random numbers will look the same every time. For most cases this is fine, but in some cases you need more random data. One such case is cryptography, where a pseudorandom generator such as System.Random would generate a predictable sequence of numbers.

System.Security.Cryptography.RandomNumberGenerator provides "cryptography grade random" numbers. These numbers are a bit more random as they are provided by the operating system, which has methods of collecting random data.

RandomNumberGenerator gives you a bunch of random bytes. It's up to you to convert to a number and size for whatever purpose. System.Random however has a simple interface, for example rnd.Next(10).

This is where MoreRandom comes in. Tedd.MoreRandom.Random mimics System.Random and is a drop-in replacement. You get the power of RandomNumberGenerator with the ease of System.Random.

## Compatibility
Created using .Net Standard 1.3.

## Unit testing
xUnit in .Net Core with near 100% code coverage. Boundary checks as well as average check on vast number of samples.

## Links
[System.Security.Cryptography.RandomNumberGenerator](https://msdn.microsoft.com/en-us/library/system.security.cryptography.randomnumbergenerator(v=vs.110).aspx) on MSDN