using System;

public class ComputePayrollAmount
{
    public string PersonName;
    public double payRate = 40.0F;

    enum Payclass
    {
        FullTime = 1,
        PartTime = 2,
        Consultants = 4
    };

    private string _firstName;
    /// <summary>
    /// First name of employee
    /// </summary>
    public string FirstName
    {
        get { return _firstName.ToLower(); }
        set { _firstName = value; }
    }

    private double TaxRate = 0.28F;        // internally used in class

    private string _LastName;
    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
    }

    enum MaritalStatus
    {
        Single = 1,
        Married = 2,
        Seperated = 4
    };

    public void GetWeeklyPay()
    {
        double TotalPay = 40.0 * payRate;
        string checkLine = WriteCheck(PersonName, TotalPay);
    }
    public ComputePayrollAmount()
    {
        // Constructor logic
    }

    public string WriteCheck(string forWhom, double Amount)
    {
        string result = "Pay to the order of " + forWhom + " $" + Amount.ToString();
        return result;
    }
}
