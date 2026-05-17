using System;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers
{
    public class CalculationHelper
    {
        // Demonstrating ref (Pass by reference)
        public void ApplyDiscount(ref decimal price, decimal discountPercentage)
        {
            if (discountPercentage > 0 && discountPercentage <= 100)
            {
                price = price - (price * (discountPercentage / 100m));
            }
        }

        // Demonstrating out (Returning multiple values / returning value via argument)
        public bool TryCalculateTax(decimal price, decimal taxRate, out decimal taxAmount)
        {
            if (price > 0 && taxRate >= 0)
            {
                taxAmount = price * (taxRate / 100m);
                return true;
            }
            taxAmount = 0;
            return false;
        }

        // Demonstrating params (Variable number of arguments)
        public decimal CalculateTotalCost(decimal basePrice, params decimal[] extraFees)
        {
            decimal total = basePrice;
            // Demonstrating var
            foreach (var fee in extraFees)
            {
                total += fee;
            }
            return total;
        }

        // Demonstrating dynamic and arrays (single and jagged)
        public void ProcessDynamicData()
        {
            // Dynamic variable
            dynamic dynamicValue = "Hello DriveFlow";
            Console.WriteLine(dynamicValue);
            dynamicValue = 100; // Type changes at runtime

            // Single array
            string[] singleArray = new string[] { "Car1", "Car2" };

            // Jagged array
            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new int[] { 1, 2, 3 };
            jaggedArray[1] = new int[] { 4, 5 };
        }

        // Demonstrating Casting and Boxing/Unboxing
        public void DemonstrateTypes()
        {
            // Implicit casting (int to double)
            int myInt = 10;
            double myDouble = myInt;

            // Explicit casting (double to int)
            double myOtherDouble = 9.78;
            int myOtherInt = (int)myOtherDouble;

            // Boxing (Value type to Object)
            int valueType = 123;
            object boxed = valueType;

            // Unboxing (Object to Value type)
            int unboxed = (int)boxed;
        }
    }
}
