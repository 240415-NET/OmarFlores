namespace miniLegacyRerater;

public class Rating
{
    //fields
    private int PolicyId = 1234567890;
    // private string RiskState="MD";
    private string EffectiveDate = "4/24/2024";
    // private int NumberOfVehicles=1;
    // private int NumberofDrivers=1;
    // private int NumberOfOccurrences=0;
    private int RateGen = 0;
    private double Premium = 100;

    //constructor
    public Rating(int PolicyId, string EffectiveDate)
    {
        setPolicyId(PolicyId);
        // setRiskState(RiskState);
        setEffectiveDate(EffectiveDate);
    }

    public Rating()
    {
    }
    public Rating(int PolicyId, string EffectiveDate, int RateGen, int Premium)
    {
        setPolicyId(PolicyId);
        // setRiskState(RiskState);
        setEffectiveDate(EffectiveDate);
        setRageGen(RateGen);
        setPremium(Premium);

    }
    //properties
    public int getPolicyId()
    {
        return this.PolicyId;
    }
    public void setPolicyId(int PolicyId)
    {
        this.PolicyId = PolicyId;
    }
    public void setEffectiveDate(string EffectiveDate)
    {
        this.EffectiveDate = EffectiveDate;
    }
    public void setRageGen(int RateGen)
    {
        this.RateGen = RateGen;
    }

    public void setPremium(int Premium)
    {
        switch (RateGen)
        {
            case 1:
                this.Premium = Premium * 1.1;
                break;
            case 2:
                this.Premium = Premium * 1.2;
                break;
        }

    }


    //methods
    public override string ToString()
    {
        return ($"PolicyId={PolicyId} - EffectiveDate={EffectiveDate} - RateGen={RateGen} - Premium={Premium}");
    }

    public void Rate()
    {
        for (int i = 0; i < 6; i++)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
    }
}
