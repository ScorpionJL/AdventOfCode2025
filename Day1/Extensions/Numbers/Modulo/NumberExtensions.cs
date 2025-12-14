using System.Numerics;

namespace AOC25.Extensions.Numbers.Modulo;

public static class NumberExtensions
{
    extension<T>(T value) where T : INumber<T>
    {
        public T Modulo(T modulus) => 
            T.IsZero(modulus) 
            ? throw new DivideByZeroException() 
            : (value % modulus + modulus) % modulus;
    }

    public static bool IsPositive<T>(this T number) where T : INumber<T>
    {
        // Use INumber<T>.Zero for comparison
        return number > T.Zero;
    }
}