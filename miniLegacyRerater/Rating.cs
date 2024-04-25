namespace miniLegacyRerater;

public class Rating{
//fields
private int PolicyId = 1234567890;
// private string RiskState="MD";
private string EffectiveDate="4/24/2024";
// private int NumberOfVehicles=1;
// private int NumberofDrivers=1;
// private int NumberOfOccurrences=0;
private int RateGen=52;
private int Premium=100;

//constructor

//public Rating(int PolicyId, string RiskState, string EffectiveDate, int NumberOfVehicles, int NumberofDrivers, int NumberOfOccurrences, int RateGen){
    public Rating(int PolicyId, string EffectiveDate, int RateGen,int Premium){
    setPolicyId(PolicyId);
    // setRiskState(RiskState);
    setEffectiveDate(EffectiveDate);
    setRageGen(RateGen);
    setPremium(Premium);

}
//properties
public int getPolicyId(){
    return this.PolicyId;
}
public void setPolicyId(int PolicyId){
    this.PolicyId=PolicyId;
}
public void setEffectiveDate(string EffectiveDate){
    this.EffectiveDate=EffectiveDate;
}
public void setRageGen(int RateGen){
    this.RateGen=RateGen;
}

public void setPremium(int Premium){
    this.Premium=Premium*2;
}
// public string getRiskState(){
//     return this.RiskState;
// }
// public void setRiskState(string RiskState){
//     this.RiskState=RiskState;
// }

//methods
public override string ToString()
    {
        return ($"PolicyId={PolicyId}\nEffectiveDate={EffectiveDate}\nRateGen={RateGen}\nPremium={Premium}");
    }

}
