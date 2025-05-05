using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

// Base class for all stats.  This is made non-generic.
public abstract class BaseStat
{
    public string Name { get; protected set; } // Name of the stat.

    // Format the stat's value as a string.  This is important for display.
    public abstract string GetDisplayValue();
}

// Generic class for numeric stats.  This handles the common pattern of a numeric value.
public class NumericStat<T> : BaseStat, IComparable<NumericStat<T>>, IEquatable<NumericStat<T>> where T : struct, IComparable<T>
{
    public T Value { get; set; } // The stat's value.

    public NumericStat(string name, T initialValue)
    {
        Name = name;
        Value = initialValue;
    }

    // Provide a user-friendly string representation of the value.
    public override string GetDisplayValue()
    {
        return Value.ToString();
    }

     public int CompareTo(NumericStat<T> other)
    {
        if (other == null)
        {
            return 1; // Consider null to be less than any instance.
        }
        return Value.CompareTo(other.Value);
    }

    public bool Equals(NumericStat<T> other)
    {
        if (other == null)
        {
            return false;
        }
        return Value.Equals(other.Value);
    }
    public override bool Equals(object obj)
    {
        if (obj is NumericStat<T> other)
        {
            return this.Equals(other);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    // Overload operators for more natural syntax.
    public static bool operator ==(NumericStat<T> a, NumericStat<T> b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }
        if (a is null || b is null)
        {
            return false;
        }
        return a.Equals(b);
    }

    public static bool operator !=(NumericStat<T> a, NumericStat<T> b)
    {
        return !(a == b);
    }

    public static bool operator <(NumericStat<T> a, NumericStat<T> b)
    {
        if (a is null || b is null) return false; //handle nulls
        return a.CompareTo(b) < 0;
    }

    public static bool operator >(NumericStat<T> a, NumericStat<T> b)
    {
       if (a is null || b is null) return false;
        return a.CompareTo(b) > 0;
    }

    public static bool operator <=(NumericStat<T> a, NumericStat<T> b)
    {
        if (a is null || b is null) return false;
        return a.CompareTo(b) <= 0;
    }

    public static bool operator >=(NumericStat<T> a, NumericStat<T> b)
    {
        if (a is null || b is null) return false;
        return a.CompareTo(b) >= 0;
    }
}

// Example usage:  Specific stat classes.  These are very lightweight.
public class Health : NumericStat<int>
{
    public Health(int initialValue) : base("Health", initialValue) { }
}

public class Mana : NumericStat<int>
{
    public Mana(int initialValue) : base("Mana", initialValue) { }
}

public class Strength : NumericStat<float>
{
    public Strength(float initialValue) : base("Strength", initialValue) { }
}

public class Experience : NumericStat<long>
{
    public Experience(long initialValue) : base("Experience", initialValue) { }
}

public class Level : NumericStat<int>
{
    public Level(int initialValue) : base("Level", initialValue) { }
}

// Class to manage a collection of stats.  This is the core of the system.
public class PlayerStats
{
    private Dictionary<string, BaseStat> stats = new Dictionary<string, BaseStat>();

    // Constructor.  You could initialize stats here, or in a separate method.
    public PlayerStats()
    {
        //  No stats are added here.  Add them using AddStat.
    }

    // Add a stat to the collection.  Checks for duplicates.
    public void AddStat(BaseStat stat)
    {
        if (stats.ContainsKey(stat.Name))
        {
            throw new ArgumentException($"A stat with the name '{stat.Name}' already exists.");
        }
        stats.Add(stat.Name, stat);
    }

    // Get a stat by its name.  Returns null if the stat doesn't exist.
    public T GetStat<T>(string statName) where T : BaseStat
    {
        if (stats.TryGetValue(statName, out BaseStat stat))
        {
            return (T)stat; // Cast to the correct type.
        }
        return null; // Important:  Return null, not default(T), for non-existent stats.
    }

     // Get a stat by its name.  Returns null if the stat doesn't exist.
    public BaseStat GetStat(string statName)
    {
        if (stats.TryGetValue(statName, out BaseStat stat))
        {
            return stat;
        }
        return null; // Important:  Return null, not default(T), for non-existent stats.
    }

    // Get the value of a numeric stat.  Returns a default value if the stat doesn't exist.
    public T GetStatValue<T>(string statName, T defaultValue = default(T)) where T : struct
    {
       NumericStat<T> stat = GetStat<NumericStat<T>>(statName);
        return stat != null ? stat.Value : defaultValue;
    }

    // Set the value of a numeric stat.  Throws an exception if the stat doesn't exist or is the wrong type.
    public void SetStatValue<T>(string statName, T value) where T : struct
    {
        NumericStat<T> stat = GetStat<NumericStat<T>>(statName);
        if (stat != null)
        {
            stat.Value = value;
        }
        else
        {
            throw new ArgumentException($"Stat '{statName}' not found or is not a NumericStat<{typeof(T).Name}>.");
        }
    }

    // Helper method to easily get a stat's display value as a string.
    public string GetStatDisplayValue(string statName)
    {
        BaseStat stat = GetStat(statName); // Use the non-generic version.
        return stat?.GetDisplayValue() ?? "N/A"; // null-safe: returns "N/A" if stat is null.
    }

    // Method to get all stats
    public IEnumerable<BaseStat> GetAllStats()
    {
        return stats.Values;
    }

    // You could add methods here to modify stats, e.g., AddExperience, TakeDamage, etc.
    public void AddExperience(long amount)
    {
        Experience expStat = GetStat<Experience>("Experience");
        if (expStat != null)
        {
            expStat.Value += amount;
        }
        //  Consider adding level-up logic here.
    }

     public void TakeDamage(int amount)
    {
        Health healthStat = GetStat<Health>("Health");
        if (healthStat != null)
        {
            healthStat.Value -= amount;
            if (healthStat.Value <= 0)
            {
                // Handle death.
                Console.WriteLine("Player has died!");
            }
        }
    }
}

// Example Script:  Demonstrates how to use the stats system.
public class StatScript
{
    public static void Run()
    {
        // Create a PlayerStats object.
        PlayerStats playerStats = new PlayerStats();

        // Add some stats.
        playerStats.AddStat(new Health(100));
        playerStats.AddStat(new Mana(50));
        playerStats.AddStat(new Strength(10.5f));
        playerStats.AddStat(new Experience(0));
        playerStats.AddStat(new Level(1));

        // Get and display some stats.
        Console.WriteLine($"Health: {playerStats.GetStatDisplayValue("Health")}");
        Console.WriteLine($"Mana: {playerStats.GetStatDisplayValue("Mana")}");
        Console.WriteLine($"Strength: {playerStats.GetStatDisplayValue("Strength")}");
        Console.WriteLine($"Experience: {playerStats.GetStatDisplayValue("Experience")}");
        Console.WriteLine($"Level: {playerStats.GetStatDisplayValue("Level")}");


        // Modify a stat.
        playerStats.SetStatValue("Health", 80);
        Console.WriteLine($"New Health: {playerStats.GetStatDisplayValue("Health")}");

        //Demonstrate the generic GetStatValue
        int currentHealth = playerStats.GetStatValue<int>("Health");
        Console.WriteLine($"Current Health: {currentHealth}");

        // Demonstrate adding experience
        playerStats.AddExperience(20);
        Console.WriteLine($"Updated Experience: {playerStats.GetStatDisplayValue("Experience")}");

        //Demonstrate TakeDamage
        playerStats.TakeDamage(10);
        Console.WriteLine($"Health after damage: {playerStats.GetStatDisplayValue("Health")}");

        // Example of using the comparison operators.
        Health health1 = playerStats.GetStat<Health>("Health");
        Health health2 = new Health(90);
        if (health1 < health2)
        {
            Console.WriteLine("Health1 is less than Health2");
        }
        else
        {
            Console.WriteLine("Health1 is not less than Health2");
        }

        // Example of getting all stats.
        Console.WriteLine("\nAll Stats:");
        foreach (BaseStat stat in playerStats.GetAllStats())
        {
            Console.WriteLine($"{stat.Name}: {stat.GetDisplayValue()}");
        }

        // Example of trying to get a stat that doesn't exist.
        Mana nonExistentMana = playerStats.GetStat<Mana>("NonExistentMana");
        if (nonExistentMana == null)
        {
            Console.WriteLine("Tried to get NonExistentMana, and it was null, as expected.");
        }
        else
        {
            Console.WriteLine("NonExistentMana was found (which is wrong).");
        }
    }
}

// Class to hold a main method for quick testing
public class Program
{
    public static void Main(string[] args)
    {
        StatScript.Run();
    }
}
