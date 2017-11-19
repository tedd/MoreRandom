# MoreRandom
Drop in replacement for System.Random based on RNGCryptoServiceProvider.
.Net Standard 2.0.

RNGCryptoServiceProvider provides more random numbers than System.Random, but the interface is slightly harder to use. MoreRandom provides a Random object that has the same interface as System.Random, but uses RNGCryptoServiceProvider as source for random numbers.
