
public class Carrot {
	private int has_ready = 0;
	public boolean Dirty;
    public boolean Have_scin;
    public int getHas_ready(){
    	return has_ready;
    };
  

    public void setHave_scin( boolean Have_scin){
    	this.Have_scin=Have_scin;
    	
    }
    public boolean getHave_scin(){
    	return  Have_scin;	
    }
    public boolean getDirty() {
		return Dirty;
	}

	public void setDirty( boolean Dirty) {
		this.Dirty=Dirty;
	}
    public void GetHeat()
    {
        if (has_ready < 10)
        {
            has_ready++;
        }
    }
}
