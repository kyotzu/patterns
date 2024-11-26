namespace patterns;

using System;

public abstract class Account
{
    // тип учетной записи
    public string Type { get; protected set; }

    // баланс учетной записи
    public double Balance { get; set; }

    // процентная ставка
    public double Interest { get; protected set; }

    // Метод для расчета процентной ставки (шаблонный метод)
    public abstract void CalculateInterest();
}

// Класс для обычного аккаунта
public class RegularAccount : Account
{
    public RegularAccount()
    {
        Type = "Обычный";
    }

    public override void CalculateInterest()
    {
        Interest = Balance * 0.4;

        if (Balance < 1000)
        {
            Interest -= Balance * 0.2;
        }
        else
        {
            Interest -= Balance * 0.4;
        }
    }
}

// Класс для зарплатного аккаунта
public class SalaryAccount : Account
{
    public SalaryAccount()
    {
        Type = "Зарплатный";
    }

    public override void CalculateInterest()
    {
        Interest = Balance * 0.5;
    }
}

// Класс калькулятора
public static class Calculator
{
    public static void CalculateInterest(Account account)
    {
        account.CalculateInterest();
    }
}

// Пример использования
public class Program
{
    public static void Main()
    {
        Account regularAccount = new RegularAccount { Balance = 1200 };
        Account salaryAccount = new SalaryAccount { Balance = 800 };

        Calculator.CalculateInterest(regularAccount);
        Calculator.CalculateInterest(salaryAccount);

        Console.WriteLine($"Процентная ставка для {regularAccount.Type} аккаунта: {regularAccount.Interest}");
        Console.WriteLine($"Процентная ставка для {salaryAccount.Type} аккаунта: {salaryAccount.Interest}");
    }
}


