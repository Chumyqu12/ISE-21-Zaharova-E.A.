
public class Stove {
	private Pan pan;
    private boolean State;
    public boolean getState(){
    	return State;
    }
    public void setState(boolean State){
    	this.State=State;
    }
    
    public void setPan(Pan value){  pan = value; }
    public Pan getPan() { return pan; } 

    public boolean pan1() {
        if (!pan.ReadyToGo())
        {
            return false;
        }
        else {
            return true;
        }
    }

    public void Cook()
    {
        
        if (State)
        {
            while (pan.Isready())
            {
                pan.Getheat();
            }
        }

    }	
	
	
	
}
