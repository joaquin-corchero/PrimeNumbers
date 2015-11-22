How to run it:
Open the solution on Visual Studio and run it.
The screen will ask for a number, and after clicking send the calculations will appear on the screen. Even though the number of primes is calculated, only 10 multiplications are displayed as per spec.

What you’re pleased with:
To be honest, not much... I was trying to get the app to be able to return a Int32.MaxValue number of primes, but spent too long going on the wrong direction...

What you would do with it if you had more time:
If all the primes would need to be returned on the screen, I would use javascript calling some rest service to get the primes, and let js do the multiplications.
The calls from js could be in batches so the user would get a better experience, the rest service could be cached so no duplicated requests would be executed.
I would create data storage for the primes, in some cases is quicker to generate them on the fly, but when large numbers are requested is easy to get out of memory exceptions, at least with my implementation.
The implementation for he sieve of Erathosthenes is not my own implementation, found it, tested it and I modified a few things to make it work the way I wanted.